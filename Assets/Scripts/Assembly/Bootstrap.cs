using Core.Drone;
using Core.Ether;
using Core.Player;
using Core.Transmitter;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ClientIO _clientIO;
    [SerializeField] private PlayerBody _playerBody;
    [SerializeField] private DroneInstancer _droneInstancer;
    [SerializeField] private TransmitterInstancer _transmitterInstancer;

    private DroneFabric _droneFabric;
    private PlayerController _playerController;
    private Ether<Command> _ether;
    private DroneConnector _droneConnector;
    private DronesManager _dronesManager;
    private TransmitterController _transmitterController;

    private void Awake()
    {
        // Player.
        _playerController = new PlayerController(_clientIO);
        _playerController.SetPlayerBody(_playerBody);
        _playerController.IsAvailable = true;

        // To create drone.
        _ether = new Ether<Command>();
        _droneFabric = new DroneFabric();
        _droneConnector = new DroneConnector();
        _dronesManager = new DronesManager(
            _ether,
            _transmitterInstancer,
            _droneFabric,
            _droneInstancer,
            _droneConnector);
        _clientIO.Initialize();

        var channel = 1;
        var power = 20.0f;
        var position = new Vector3(1, 1, 0);

        var transmitter = new Transmitter(_ether, channel, new Joystick[] { new(), new() });
        var transmitterBody = _transmitterInstancer.Instantiate(transmitter);

        _transmitterController = new TransmitterController(_clientIO, transmitter);
        _dronesManager.SpawnDrone(transmitterBody, channel, power, position);
    }

    private void Update()
    {
        _clientIO.Update();
        _transmitterController.Update();
        _playerController.Update();
        _dronesManager.Update();
    }
}
