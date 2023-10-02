using Core.SmoothInput;
using System;
using UnityEngine;

[Serializable]
public class ClientIO :
    Core.Player.IControls,
    Core.Transmitter.IControls
{
    private class PressHelper
    {
        public KeyCode KeyCode { get; }
        public SmoothPressing SmoothPressing { get; }

        public PressHelper(KeyCode keyCode, SmoothPressing smoothPressing)
        {
            KeyCode = keyCode;
            SmoothPressing = smoothPressing;
        }

        public void Update(float deltaTime)
        {
            if (Input.GetKey(KeyCode))
            {
                SmoothPressing.Press(deltaTime);
            }
            else
            {
                SmoothPressing.Release(deltaTime);
            }
        }
    }

    [Header("Character controls")]
    [SerializeField] private KeyCode _forwardKey = KeyCode.W;
    [SerializeField] private KeyCode _backKey = KeyCode.S;
    [SerializeField] private KeyCode _rightKey = KeyCode.D;
    [SerializeField] private KeyCode _leftKey = KeyCode.A;
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _runKey = KeyCode.LeftControl;
    [SerializeField] private KeyCode _leaveKey = KeyCode.LeftShift;
    [SerializeField] private float _mouseSensitivity = 2;

    [Header("Transmitter controls")]
    [SerializeField] private float _transmitterSpeed = 1.0f;
    [SerializeField] private KeyCode _rightHorizontalPositiveKey = KeyCode.L;
    [SerializeField] private KeyCode _rightHorizontalNegativeKey = KeyCode.J;
    [SerializeField] private KeyCode _rightVerticalPositiveKey = KeyCode.I;
    [SerializeField] private KeyCode _rightVerticalNegativeKey = KeyCode.K;
    [SerializeField] private KeyCode _leftHorizontalPositiveKey = KeyCode.H;
    [SerializeField] private KeyCode _leftHorizontalNegativeKey = KeyCode.F;
    [SerializeField] private KeyCode _leftVerticalPositiveKey = KeyCode.T;
    [SerializeField] private KeyCode _leftVerticalNegativeKey = KeyCode.G;

    [Header("Transmitter controls for joystick")]
    [SerializeField] private string _leftAxisX = "LeftAxisX";
    [SerializeField] private string _leftAxisY = "LeftAxisY";
    [SerializeField] private string _rightAxisX = "RightAxisX";
    [SerializeField] private string _rightAxisY = "RightAxisY";

    [Header("Other controls")]
    [SerializeField] private KeyCode _pauseKey = KeyCode.Escape;
    [SerializeField] private KeyCode _interactKey = KeyCode.E;

    // Character controls.
    public float RotationDeltaX { get; private set; }
    public float RotationDeltaY { get; private set; }
    public bool MoveForward { get; private set; }
    public bool MoveBack { get; private set; }
    public bool MoveRight { get; private set; }
    public bool MoveLeft { get; private set; }
    public bool IsRunning { get; private set; }
    public bool IsJumping { get; private set; }
    public bool Leave { get; private set; }

    // Transmitter controls.
    public bool IsActive { get; private set; }
    public Vector2 LeftAxes { get; private set; }
    public Vector2 RightAxes { get; private set; }

    private PressHelper[] _pressHelpers;

    public void Initialize()
    {
        _pressHelpers = new PressHelper[]
        {
            new (_rightHorizontalPositiveKey, new (_transmitterSpeed, _transmitterSpeed)),
            new (_rightHorizontalNegativeKey, new (_transmitterSpeed, _transmitterSpeed)),
            new (_rightVerticalPositiveKey, new (_transmitterSpeed, _transmitterSpeed)),
            new (_rightVerticalNegativeKey, new (_transmitterSpeed, _transmitterSpeed)),
            new (_leftHorizontalPositiveKey, new (_transmitterSpeed, _transmitterSpeed)),
            new (_leftHorizontalNegativeKey, new (_transmitterSpeed, _transmitterSpeed)),
            new (_leftVerticalPositiveKey, new (_transmitterSpeed, _transmitterSpeed)),
            new (_leftVerticalNegativeKey, new (_transmitterSpeed, _transmitterSpeed))
        };
    }

    public void Update()
    {
        HandlePlayerInput();
        HandleTransmitterInput();
    }

    private void HandlePlayerInput()
    {
        RotationDeltaX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        RotationDeltaY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        MoveForward = Input.GetKey(_forwardKey);
        MoveBack = Input.GetKey(_backKey);
        MoveRight = Input.GetKey(_rightKey);
        MoveLeft = Input.GetKey(_leftKey);
        IsRunning = Input.GetKey(_runKey);
        IsJumping = Input.GetKey(_jumpKey);
        Leave = Input.GetKeyDown(_leaveKey);
    }

    private void HandleTransmitterInput()
    {
        foreach (var pressHelper in _pressHelpers)
        {
            pressHelper.Update(Time.deltaTime);
        }

        IsActive = true;

        Vector2 summ(Vector2 a, Vector2 b)
        {
            Vector2 c = a;

            if(Mathf.Abs(a.x) < Mathf.Abs(b.x))
            {
                c.x = b.x;
            }

            if (Mathf.Abs(a.y) < Mathf.Abs(b.y))
            {
                c.y = b.y;
            }

            return c;
        }

        var leftAxesKeyboard = new Vector2(
            _pressHelpers[4].SmoothPressing.Value - 
            _pressHelpers[5].SmoothPressing.Value,
            _pressHelpers[6].SmoothPressing.Value - 
            _pressHelpers[7].SmoothPressing.Value);

        var rightAxesKeyboard = new Vector2(
            _pressHelpers[0].SmoothPressing.Value - 
            _pressHelpers[1].SmoothPressing.Value,
            _pressHelpers[2].SmoothPressing.Value - 
            _pressHelpers[3].SmoothPressing.Value);

        var leftAxesJoystick = new Vector2(
            Input.GetAxis(_leftAxisX), 
            Input.GetAxis(_leftAxisY));

        var rightAxesJoystick = new Vector2(
            Input.GetAxis(_rightAxisX),
            Input.GetAxis(_rightAxisY));

        RightAxes = summ(rightAxesJoystick, rightAxesKeyboard);
        LeftAxes = summ(leftAxesJoystick, leftAxesKeyboard);
    }
}