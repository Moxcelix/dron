using Core.Ether;
using Core.Transmitter;
using UnityEngine;
using Core.Utilities;

public class DroneRemoteControl : Core.Drone.IControls
{
    private readonly Ether<Command> _ether;
    private readonly int _channel;

    public DroneRemoteControl(Ether<Command> ether, int channel)
    {
        _ether = ether;
        _channel = channel;
    }

    public bool IsActive { get; private set; }

    public Vector2 LeftAxes { get; private set; }

    public Vector2 RightAxes { get; private set; }

    public void Update()
    {
        var signal = _ether.CatchSignal(_channel);

        if (signal is null)
        {
            return;
        }

        var command = JsonUtility.FromJson<ArrayWrapper<string>>(signal.Data).array;

        if (command.Length < 3)
        {
            return;
        }

        Debug.Log(command.Length);

        LeftAxes = JsonUtility.FromJson<Vector2>(command[0]);
        RightAxes = JsonUtility.FromJson<Vector2>(command[1]);
        IsActive = JsonUtility.FromJson<bool>(command[2]);
    }
}
