using Core.Drone;
using UnityEngine;

public class DroneManualController : DroneMiddleController
{
    private PIDController _tiltXController =
        new PIDController(1.0f, 0.2f, 0.2f, 0.2f,
            PIDController.DerivativeMeasurement.Velocity);

    private PIDController _tiltYController =
    new PIDController(1.0f, 0.2f, 0.2f, 0.2f,
        PIDController.DerivativeMeasurement.Velocity);

    private PIDController _heightController =
    new PIDController(1.0f, 0.2f, 0.2f, 0.2f,
        PIDController.DerivativeMeasurement.Velocity);

    private float _prevHeightValue = 0;

    public DroneManualController
        (IControls controls, DroneBody drone)
        : base(controls, drone)
    {
    }

    public override void Update()
    {
        IsActive = _controls.IsActive;
        LeftAxes = _controls.LeftAxes;
        RightAxes = _controls.RightAxes;

        if (Mathf.Abs(_controls.RightAxes.y) <= float.Epsilon)
        {
            var height = _droneBody.transform.position.y;
            var h = _heightController.Update(
                Time.unscaledDeltaTime, height, _prevHeightValue);
            
            RightAxes = new(_controls.RightAxes.x, h);
        }
        else
        {
            _prevHeightValue = _droneBody.transform.position.y;
        }

        if (Mathf.Abs(_controls.LeftAxes.x) <= float.Epsilon)
        {
            var mx = _droneBody.transform.localEulerAngles.z;
            mx = mx > 180 ? mx - 360 : mx;
            var x = _tiltXController.Update(Time.unscaledDeltaTime, mx, 0);
            var sign = Mathf.Sign(RightAxes.y);

            LeftAxes = new Vector2(-x * sign, LeftAxes.y);
        }
        else
        {
            _tiltXController.Reset();
        }

        if (Mathf.Abs(_controls.LeftAxes.y) <= float.Epsilon)
        {
            var my = _droneBody.transform.localEulerAngles.x;
            my = my > 180 ? my - 360 : my;
            var y = _tiltYController.Update(Time.unscaledDeltaTime, my, 0);
            var sign = Mathf.Sign(RightAxes.y);

            LeftAxes = new Vector2(LeftAxes.x, y * sign);
        }
        else
        {
            _tiltYController.Reset();
        }
    }
}
