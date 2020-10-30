using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public float positionShiftOnExit;
    public static string prevScene = "";
    public static string currentScene = "";

    private Vector3 prev_overworld_pos;

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
        
    }

    //from https://forum.unity.com/threads/stop-a-function-till-scene-is-loaded.546646/
    IEnumerator movePlayerAfterLoad(string sceneName)
    {
        while (SceneManager.GetActiveScene().name != sceneName)
        {
            yield return new WaitForSeconds(0.001f);
        }

        // Do anything after proper scene has been loaded
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            prev_overworld_pos.y += positionShiftOnExit;
            player.transform.position = prev_overworld_pos;
        }
        currentScene = sceneName;
    }

    public void LoadScene(string sceneName)
    {
        currentScene = SceneManager.GetActiveScene().name;
        

        if (prevScene == "Test_Overworld")
        {
            SceneManager.LoadScene(sceneName);
            StartCoroutine(movePlayerAfterLoad(sceneName));
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            prev_overworld_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
            SceneManager.LoadScene(sceneName);
        }
        prevScene = currentScene;

    }
}
