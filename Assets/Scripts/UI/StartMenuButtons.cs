using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Test_Overworld");
    }
}
