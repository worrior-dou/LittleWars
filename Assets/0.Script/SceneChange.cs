using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{    public void OnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnGame()
    {
        SceneManager.LoadScene("Game");
    }
}
