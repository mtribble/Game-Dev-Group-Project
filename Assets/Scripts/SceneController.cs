using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    //keeps track of which enemies and items have been despawned
    private Dictionary<string ,Dictionary<Vector3, bool>> despawnManifest;

    // holds current enemy id incase player wins
    private (string, Vector3) currentEnemy;

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
        despawnManifest = new Dictionary<string ,Dictionary<Vector3, bool>>();
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
    IEnumerator MovePlayerAfterLoad(string sceneName, Vector3 pos)
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
            Despawn();
        }
    }

    IEnumerator DespawnAfterLoad(string sceneName)
    {
        while (SceneManager.GetActiveScene().name != sceneName)
        {
            yield return new WaitForSeconds(0.001f);
        }
        Despawn();
    }

    public void ReturnToPrevScene()
    {
        if (prevScenes.Count != 0)
        {
            SceneManager.LoadScene(prevScenes.Peek().Item1);
            StartCoroutine(MovePlayerAfterLoad(prevScenes.Peek().Item1, prevScenes.Pop().Item2));
        }
        else
        {
            Debug.Log("Previous scene unknown, loading default spawn location");
            SceneController.Instance.LoadScene("Test_Overworld", Vector2.zero);
        }
    }

    public void LoadScene(string nextScene, Vector3 playerVel)
    {
        string currentScene = SceneManager.GetActiveScene().name;
       
       if (prevScenes.Count != 0 && prevScenes.Peek().Item1 == nextScene)
        {
            SceneManager.LoadScene(nextScene);
            StartCoroutine(MovePlayerAfterLoad(nextScene, prevScenes.Pop().Item2));
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
            else
            {
                //Debug.Log("cannot find player");
            }
            
            SceneManager.LoadScene(nextScene);
        }
        StartCoroutine(DespawnAfterLoad(nextScene));
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

    //despawns any overworld item or overworld enemy with a true flag in the manifest
    private void Despawn(){
        //Debug.Log("calling despawn");
        if(despawnManifest.ContainsKey(SceneManager.GetActiveScene().name)){
            Dictionary<Vector3, bool> sceneManifest = despawnManifest[SceneManager.GetActiveScene().name];
            //Debug.Log(sceneManifest.Count.ToString() + " Objects in scene manifest");
            foreach(OverworldEnemy enemy in FindObjectsOfType<OverworldEnemy>()){
                if(sceneManifest.ContainsKey(enemy.transform.position)){
                    //Debug.Log("despawn enemy");
                    Destroy(enemy.gameObject);
                }
            }
            foreach(OverWorldItem item in FindObjectsOfType<OverWorldItem>()){
                if(sceneManifest.ContainsKey(item.transform.position)){
                    //Debug.Log("despawn item");
                    Destroy(item.gameObject);
                }
            }
        }
        else
        {
            //Debug.Log("cannot find scene manifest");
        }
    }
    public void SetCurrentEnemy(Vector3 location){
        currentEnemy = (SceneManager.GetActiveScene().name, location);
    }

    public void AddToManifest(Vector3 location){
        AddToManifest(location,  SceneManager.GetActiveScene().name);
    }

    public void AddToManifest(Vector3 location, string sceneName){
        if(sceneName != null){
            //Debug.Log("adding to manifest location:" + location.ToString() + " scene: " + sceneName);
            if(!despawnManifest.ContainsKey(sceneName)){
                //Debug.Log("Creating new scene manifest");
                despawnManifest[sceneName] = new Dictionary<Vector3, bool>();
            }
            Dictionary<Vector3, bool> sceneManifest = despawnManifest[sceneName];
            sceneManifest[location] = true;
        }
    }
    public void AddEnemyToManifest(){
        //Debug.Log("Adding enemy to despaning manifest. Scene:" + currentEnemy.Item1);
        AddToManifest(currentEnemy.Item2, currentEnemy.Item1);
    }
}
