using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{

    public GameObject message;
    public GameObject dropOff;

    public float minX = -1500f;
    public float maxX = 1500f;

    public float minY = 50;
    public float maxY = 500f;

    public float minZ = -1500f;
    public float maxZ = 1500f;

    void Start()
    {

        SpawnMessage();
        
    }

    public void SpawnMessage()
    {
        Instantiate(message, new Vector3(Random.Range(minX,maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity, transform);
    }

    public void SpawnDropOff()
    {
        Instantiate(dropOff, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), Quaternion.identity, transform);
    }
}
