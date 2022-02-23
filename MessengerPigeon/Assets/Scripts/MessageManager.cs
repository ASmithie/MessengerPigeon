using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{

    public GameObject message;
    public GameObject dropOff;

    void Start()
    {

        SpawnMessage();
        
    }

    public void SpawnMessage()
    {
        Instantiate(message, new Vector3(50f, 50f, 50f), Quaternion.identity, transform);
    }

    public void SpawnDropOff()
    {
        Instantiate(dropOff, new Vector3(-50f, 50f, -50f), Quaternion.identity, transform);
    }
}
