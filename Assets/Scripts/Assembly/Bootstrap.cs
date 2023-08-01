using Core.Drone;
using Core.Player;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ClientIO _clientIO;
    [SerializeField] private PlayerBody _playerBody;
    [SerializeField] private DroneInstancer _droneInstancer;

    private DroneFabric _droneFabric;
    private PlayerController _playerController;

    private void Awake()
    {
        _droneFabric = new DroneFabric();
        _playerController = new PlayerController(_clientIO);
        _playerController.SetPlayerBody(_playerBody);

        _playerController.IsAvailable = true;

        // Test.
        var drone = _droneFabric.CreateDron(140f);
        var droneBody = _droneInstancer.Instantiate(drone, new Vector3(0, 1, 0));
        drone.Power(1.0f);
    }

    private void Update()
    {
        _clientIO.Update();
        _playerController.Update();
    }
}
