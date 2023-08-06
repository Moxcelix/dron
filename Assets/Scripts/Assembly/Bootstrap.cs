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

    private void Awake()
    {
        _ether = new Ether<Command>();
        _droneFabric = new DroneFabric();
        _playerController = new PlayerController(_clientIO);
        _droneConnector = new DroneConnector();
        _dronesManager = new DronesManager(
            _ether,
            _transmitterInstancer,
            _droneFabric,
            _droneInstancer,
            _droneConnector);
        _playerController.SetPlayerBody(_playerBody);

        _playerController.IsAvailable = true;

        // Test.
        var channel = 1;
        var power = 140.0f;
        var position = new Vector3(0, 1, 0);

        var transmitterController = 
            _dronesManager.AddDrone(_clientIO, channel, power, position);
    }

    private void Update()
    {
        _clientIO.Update();
        _playerController.Update();
        _dronesManager.Update();
    }
}
