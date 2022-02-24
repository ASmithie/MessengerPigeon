using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

    public bool hasMessage = false;

    public GameObject MessageManager;

    public int score = 0;

    public GameObject scoreText;

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
            score++;
            scoreText.GetComponent<Text>().text = "Messages Delivered: " + score.ToString();
            MessageManager.GetComponent<MessageManager>().SpawnMessage();
            if(score == 10)
            {
                WinCon();
            }
        } else
        {
            Debug.Log("You need to pick up a message");
        }
    }

    void WinCon()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
