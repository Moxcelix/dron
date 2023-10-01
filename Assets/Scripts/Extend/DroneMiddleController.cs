using UnityEngine;
using Core.Drone;

public abstract class DroneMiddleController : IControls
{
    protected readonly IControls _controls;
    protected readonly DroneBody _droneBody;

    public bool IsActive { get; protected set; }

    public Vector2 LeftAxes { get; protected set; }

    public Vector2 RightAxes { get; protected set; }

    public DroneMiddleController(IControls controls, DroneBody drone)
    {
        _controls = controls;
        _droneBody = drone;
    }

    public abstract void Update();
}