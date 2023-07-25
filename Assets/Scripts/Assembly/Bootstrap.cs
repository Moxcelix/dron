using Core.Player;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ClientIO _clientIO;
    [SerializeField] private PlayerBody _playerBody;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = new PlayerController(_clientIO);
        _playerController.SetPlayerBody(_playerBody);

        _playerController.IsAvailable = true;
    }

    private void Update()
    {
        _clientIO.Update();
        _playerController.Update();
    }
}
