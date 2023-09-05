using Core.Drone;
using Core.Ether;
using Core.Transmitter;
using System.Collections.Generic;
using UnityEngine;

public class DronesManager
{
    private readonly Ether<Command> _ether;
    private readonly TransmitterInstancer _transmitterInstancer;
    private readonly DroneFabric _droneFabric;
    private readonly DroneInstancer _droneInstancer;
    private readonly DroneConnector _droneConnector;

    private readonly List<DroneRemoteControl> _droneRemoteControllers;
    private readonly List<DroneController> _droneControllers;

    public DronesManager(
        Ether<Command> ether,
        TransmitterInstancer transmitterInstancer,
        DroneFabric droneFabric,
        DroneInstancer droneInstancer,
        DroneConnector droneConnector)
    {
        _ether = ether;
        _transmitterInstancer = transmitterInstancer;
        _droneFabric = droneFabric;
        _droneInstancer = droneInstancer;
        _droneConnector = droneConnector;

        _droneRemoteControllers = new List<DroneRemoteControl>();
        _droneControllers = new List<DroneController>();
    }

    public void SpawnDrone(
        TransmitterBody transmitterBody,
        int channel,
        float dronePower,
        Vector3 dronePosition)
    {
        var drone = _droneFabric.CreateDron(dronePower);
        var droneBody = _droneInstancer.Instantiate(drone, dronePosition);
        var droneRemoteController = new DroneRemoteControl(_ether, channel);
        var droneController = new DroneController(droneRemoteController, drone);

        _droneRemoteControllers.Add(droneRemoteController);
        _droneControllers.Add(droneController);
        _droneConnector.Connect(transmitterBody, droneBody);
    }

    public void Update()
    {
        foreach (var controller in _droneRemoteControllers)
        {
            controller.Update();
        }

        foreach (var controller in _droneControllers)
        {
            controller.Update();
        }
    }
}
