using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public static string prevScene = "";
    public static string currentScene = "";

    public Transform player;

    private static SceneController _instance;

    public static SceneController Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public virtual void Start()
    {
        // Meant to be extended/overwritten by a scene script
        currentScene = SceneManager.GetActiveScene().name;
        if (prevScene == "Test_Overworld")
        { 
            player.position = new Vector2(0.5f, 0.5f);
        }
    }

    public void LoadScene(string sceneName)
    {
        prevScene = currentScene;
        SceneManager.LoadScene(sceneName);
    }
}
