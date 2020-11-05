using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public float positionShiftOnExit;
    public static string prevScene = "";
    private static string currentScene = "";

    private Stack<(string,Vector3)> prevScenes;

    private Vector3 prev_overworld_pos;

    #region Singleton
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
        prevScenes = new Stack<(string, Vector3)>();
    }
    #endregion

    //from https://forum.unity.com/threads/stop-a-function-till-scene-is-loaded.546646/
    IEnumerator movePlayerAfterLoad(string sceneName, Vector3 pos)
    {
        while (SceneManager.GetActiveScene().name != sceneName)
        {
            yield return new WaitForSeconds(0.001f);
        }

        // Do anything after proper scene has been loaded
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            pos.y += positionShiftOnExit;
            player.transform.position = pos;
        }
        currentScene = sceneName;
    }


    public void LoadScene(string nextScene)
    {
        if (prevScenes.Count != 0){
            Debug.Log("Prev scene: " + prevScenes.Peek().Item1+ ":" + prevScenes.Peek().Item1.Length.ToString());
        }
        Debug.Log("next scene: " + nextScene+ ":" + nextScene.Length.ToString());

        currentScene = SceneManager.GetActiveScene().name;
        

        if (prevScenes.Count != 0 && prevScenes.Peek().Item1 == nextScene)
        {
            Debug.Log("Moving to prev pos");
            SceneManager.LoadScene(nextScene);
            StartCoroutine(movePlayerAfterLoad(nextScene, prevScenes.Pop().Item2));
        }
        else
        {
            Debug.Log("pushing scene: " + currentScene + ":" + currentScene.Length.ToString());
            prevScenes.Push((currentScene, GameObject.FindGameObjectWithTag("Player").transform.position));
            SceneManager.LoadScene(nextScene);
        }
    }
}
