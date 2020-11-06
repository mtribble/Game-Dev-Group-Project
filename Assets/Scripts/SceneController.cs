using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    private Stack<(string,Vector3)> prevScenes;
    private Vector3 prev_overworld_pos;
    public float nudgeAmount;

    public delegate void UIUpdate();
    public UIUpdate onPauseDisplay, onPauseDisplayClear;
    public UIUpdate onInventoryDisplay, onInventoryClear;
    public UIUpdate onDialogDisplayClear;

    public delegate void UIUpdateString(string str);
    public UIUpdateString onDialogDisplay;

    private bool isPaused, isInvDisplayed;

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
        isPaused = false;
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            if (isInvDisplayed)
            {
                ClearInventoryDisplay();
                Unpause();
            }
            else
            {
                Pause();
                DisplayInvenory();
            }
        }

        if (Input.GetKeyDown("p"))
        {
            //pausing
            if (isPaused)
            {
                ClearPauseDisplay();
                Unpause();
                if (isInvDisplayed)
                {
                    ClearInventoryDisplay();
                }
            }
            //unpausing 
            else
            {
                Pause();
                DisplayPause();
                
            }
            
        }

    }

    private void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    private void DisplayPause()
    {
        onPauseDisplay?.Invoke();
    }

    private void ClearPauseDisplay()
    {
        onPauseDisplayClear?.Invoke();
    }

    private void DisplayInvenory()
    {
        isInvDisplayed = true;
        ClearPauseDisplay();
        onInventoryDisplay?.Invoke();
    }

    private void ClearInventoryDisplay()
    {
        isInvDisplayed = false;
        onInventoryClear?.Invoke();
    }


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
            player.transform.position = pos;
        }
    }

    public void LoadScene(string nextScene, Vector3 playerVel)
    {
        string currentScene = SceneManager.GetActiveScene().name;
       
       if (prevScenes.Count != 0 && prevScenes.Peek().Item1 == nextScene)
        {
            SceneManager.LoadScene(nextScene);
            StartCoroutine(movePlayerAfterLoad(nextScene, prevScenes.Pop().Item2));
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Vector3 returnPos = player.transform.position;
                returnPos.x += playerVel.x * nudgeAmount * -1;
                returnPos.y += playerVel.y * nudgeAmount * -1;
                prevScenes.Push((currentScene, returnPos));
            }
            
            SceneManager.LoadScene(nextScene);
        }
    }

    public void DisplayDialog(string dialog)
    {
        ClearDialog();
        onDialogDisplay?.Invoke(dialog);
    }

    public void ClearDialog()
    {
        onDialogDisplayClear?.Invoke();
    }

}
