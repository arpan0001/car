using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    
    public GameObject chironPrefab;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        Vector3 randomPosition = new Vector3(86, -5, 100);
        PhotonNetwork.Instantiate(chironPrefab.name, randomPosition, Quaternion.identity);

    }
}
