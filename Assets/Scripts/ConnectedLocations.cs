using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConnectedLocations : MonoBehaviour
{
    [SerializeField] private GameObject[] connectedCities;

    public GameObject[] GetLocations()
    {
        return connectedCities;
    }
}
