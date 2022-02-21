using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Pick up message
            player.GetComponent<PlayerInventory>().GiveMessage();
            Destroy(gameObject);
        }
    }
}
