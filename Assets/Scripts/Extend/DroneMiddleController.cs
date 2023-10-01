using UnityEngine;
using Core.Drone;

public class DroneMiddleController : IControls
{
    private const float sensitivity = 0.02f;
    private const float dropCofficient = 0.02f;
    private const float liftCofficient = 1.0f;
    private const float tiltPIDSpeed = 50.0f;
    private const float dropResistanceCofficient = 0.5f;

    private readonly IControls _controls;
    private readonly DroneBody _droneBody;

    private readonly PIDController _tiltXController =
        new PIDController(1.0f, 0.2f, 0.2f, 0.2f,
            PIDController.DerivativeMeasurement.Velocity);

    private readonly PIDController _tiltYController =
        new PIDController(1.0f, 0.2f, 0.2f, 0.2f,
            PIDController.DerivativeMeasurement.Velocity);

    private readonly PIDController _heightController =
        new PIDController(1.0f, 0.2f, 0.2f, 0.2f,
            PIDController.DerivativeMeasurement.ErrorRateOfChange);

    private float _targetHeight = 0;

    public bool IsActive { get; private set; }

    public Vector2 LeftAxes { get; private set; }

    public Vector2 RightAxes { get; private set; }

    public DroneMiddleController(IControls controls, DroneBody drone)
    {
        _controls = controls;
        _droneBody = drone;
    }

    public void Update()
    {
        IsActive = _controls.IsActive;
        LeftAxes = _controls.LeftAxes;
        RightAxes = _controls.RightAxes;

        ControlHeight();
        ControlTilt();
    }

    private void ControlTilt()
    {
        if (Mathf.Abs(_controls.LeftAxes.x) <= sensitivity)
        {
            var mx = MakeAngleSymmetric(_droneBody.transform.localEulerAngles.z);
            var x = _tiltXController.Update(Time.unscaledDeltaTime * tiltPIDSpeed, mx, 0);
            var sign = Mathf.Sign(RightAxes.y);

            LeftAxes = new Vector2(-x * sign, LeftAxes.y);
        }
        else
        {
            _tiltXController.Reset();
        }

        if (Mathf.Abs(_controls.LeftAxes.y) <= sensitivity)
        {
            var my = MakeAngleSymmetric(_droneBody.transform.localEulerAngles.x);
            var y = _tiltYController.Update(Time.unscaledDeltaTime * tiltPIDSpeed, my, 0);
            var sign = Mathf.Sign(RightAxes.y);

            LeftAxes = new Vector2(LeftAxes.x, y * sign);
        }
        else
        {
            _tiltYController.Reset();
        }
    }

    private void ControlHeight()
    {
        if (_controls.RightAxes.y > sensitivity)
        {
            var targetHeight =
                _droneBody.transform.position.y +
                RightAxes.y * liftCofficient;

            if (targetHeight > _targetHeight)
            {
                _targetHeight = targetHeight;
            }
        }
        else if (_controls.RightAxes.y < -sensitivity)
        {
            _targetHeight =
                _droneBody.transform.position.y +
                RightAxes.y * dropCofficient;
        }

        var height = _droneBody.transform.position.y;
        var forceDirection = _heightController.Update(
            Time.unscaledDeltaTime, height, _targetHeight);

        Debug.Log(_targetHeight);

        var dropSupport = 0.0f;

        if (_droneBody.Velocity.y < 0)
        {
            dropSupport = 
                _droneBody.Velocity.y * 
                _droneBody.Velocity.y * 
                dropResistanceCofficient;
        }

        RightAxes = new(_controls.RightAxes.x, forceDirection + dropSupport);
    }

    private float MakeAngleSymmetric(float angle)
    {
        return angle > 180 ? angle - 360 : angle;
    }
}