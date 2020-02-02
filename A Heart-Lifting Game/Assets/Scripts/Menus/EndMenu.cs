using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{    
    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene("Menu");
    }

    public void ReplayGame()
    {
        Debug.Log("Replaying Game");
        SceneManager.LoadScene("GameScene");
    }
}
