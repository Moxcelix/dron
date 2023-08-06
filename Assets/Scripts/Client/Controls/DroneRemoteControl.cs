using Core.Ether;
using Core.Transmitter;

public class DroneRemoteControl : Core.Drone.IControls
{
    private readonly Ether<Command> _ether;
    private readonly float _freequency;

    public DroneRemoteControl(Ether<Command> ether, float freequency)
    {
        _ether = ether;
        _freequency = freequency;
    }

    public void Update()
    {

    }
}
