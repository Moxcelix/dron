using UnityEngine;
using Core.Drone;

[System.Serializable]
public class DroneInstancer
{
    [SerializeField] private DroneBody _dronBodyPrefab;

    public DroneBody Instantiate(Drone drone, Vector3 position)
    {
        var droneBody = Object.Instantiate(_dronBodyPrefab, position, Quaternion.identity);

        droneBody.Apply(drone);

        return droneBody;
    }
}
