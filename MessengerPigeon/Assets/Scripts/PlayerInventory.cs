using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public bool hasMessage = false;

    public GameObject MessageManager;

    public void GiveMessage()
    {
        if (hasMessage)
        {
            Debug.Log("You already have a message to deliver");
        } else
        {
            Debug.Log("Message aquired");
            hasMessage = true;
            MessageManager.GetComponent<MessageManager>().SpawnDropOff();
        }
    }

    public void DropMessage()
    {
        if (hasMessage)
        {
            Debug.Log("Message Dropped");
            hasMessage = false;
            MessageManager.GetComponent<MessageManager>().SpawnMessage();
        } else
        {
            Debug.Log("You need to pick up a message");
        }
    }
}
