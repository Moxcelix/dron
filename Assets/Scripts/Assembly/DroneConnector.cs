using Core.Drone;
using Core.Transmitter;

public class DroneConnector
{
    public void Connect(
        TransmitterBody transmitterBody, 
        DroneBody droneBody)
    {
        transmitterBody.SetTranslation(droneBody.Camera);
    }
}
