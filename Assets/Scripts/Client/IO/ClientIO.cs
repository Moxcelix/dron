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
    [SerializeField] private KeyCode _rightHorizontalPositiveKey = KeyCode.L;
    [SerializeField] private KeyCode _rightHorizontalNegativeKey = KeyCode.J;
    [SerializeField] private KeyCode _rightVerticalPositiveKey = KeyCode.I;
    [SerializeField] private KeyCode _rightVerticalNegativeKey = KeyCode.K;
    [SerializeField] private KeyCode _leftHorizontalPositiveKey = KeyCode.H;
    [SerializeField] private KeyCode _leftHorizontalNegativeKey = KeyCode.F;
    [SerializeField] private KeyCode _leftVerticalPositiveKey = KeyCode.T;
    [SerializeField] private KeyCode _leftVerticalNegativeKey = KeyCode.G;

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
            new PressHelper(_rightHorizontalPositiveKey, new SmoothPressing(0.05f, 0.05f)),
            new PressHelper(_rightHorizontalNegativeKey, new SmoothPressing(0.05f, 0.05f)),
            new PressHelper(_rightVerticalPositiveKey, new SmoothPressing(0.05f, 0.05f)),
            new PressHelper(_rightVerticalNegativeKey, new SmoothPressing(0.05f, 0.05f)),
            new PressHelper(_leftHorizontalPositiveKey, new SmoothPressing(0.05f, 0.05f)),
            new PressHelper(_leftHorizontalNegativeKey, new SmoothPressing(0.05f, 0.05f)),
            new PressHelper(_leftVerticalPositiveKey, new SmoothPressing(0.05f, 0.05f)),
            new PressHelper(_leftVerticalNegativeKey, new SmoothPressing(0.05f, 0.05f))
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
        foreach(var pressHelper in _pressHelpers)
        {
            pressHelper.Update(Time.deltaTime);
        }
    }
}