using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public bool hasMessage = false;

    public void GiveMessage()
    {
        if (hasMessage)
        {
            Debug.Log("You already have a message to deliver");
        } else
        {
            Debug.Log("Message aquired");
            hasMessage = true;
        }
    }

    public void DropMessage()
    {
        if (hasMessage)
        {
            Debug.Log("Message Dropped");
            hasMessage = false;
        } else
        {
            Debug.Log("You need to pick up a message");
        }
    }
}
