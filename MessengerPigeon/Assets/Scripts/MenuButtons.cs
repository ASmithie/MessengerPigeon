using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitButton()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
