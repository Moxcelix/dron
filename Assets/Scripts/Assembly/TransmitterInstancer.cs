using Core.Transmitter;
using UnityEngine;

[System.Serializable]
public class TransmitterInstancer
{
    [SerializeField] private TransmitterBody _transmitterBodyPrefab;

    public TransmitterBody Instantiate(Transmitter transmitter)
    {
        _transmitterBodyPrefab.Apply(transmitter);

        return _transmitterBodyPrefab;
    }
}
