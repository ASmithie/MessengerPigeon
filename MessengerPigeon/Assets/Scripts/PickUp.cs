using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Pick up message
            col.gameObject.GetComponent<PlayerInventory>().GiveMessage();
            Destroy(gameObject);
        }
    }
}
