using Core.Ether;
using Core.Transmitter;

public class DroneRemoteControl : Core.Drone.IControls
{
    private readonly Ether<Command> _ether;
    private readonly int _channel;

    public DroneRemoteControl(Ether<Command> ether, int channel)
    {
        _ether = ether;
        _channel = channel;
    }

    public void Update()
    {

    }
}
