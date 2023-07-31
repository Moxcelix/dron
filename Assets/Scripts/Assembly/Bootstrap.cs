using Core.Dron;
using Core.Player;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ClientIO _clientIO;
    [SerializeField] private PlayerBody _playerBody;
    [SerializeField] private DronFabric _dronFabric;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = new PlayerController(_clientIO);
        _playerController.SetPlayerBody(_playerBody);

        _playerController.IsAvailable = true;

        // Test.
        var dronBody = _dronFabric.CreateDron(1, new Vector3(0,1,0));
        dronBody.Dron.Power(1);
    }

    private void Update()
    {
        _clientIO.Update();
        _playerController.Update();
    }
}
