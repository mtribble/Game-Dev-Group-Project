using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_CombatTransition : MonoBehaviour
{
    public Transform winDisplay, loseDisplay;
    public float delay;
    bool hasGameEnded;

    // Start is called before the first frame update
    void Start()
    {
        Transform canvas = GameObject.Find("Canvas").transform;
        winDisplay = canvas.Find("WinDisplay");
        loseDisplay = canvas.Find("LoseDisplay");
        hasGameEnded = false;
    }

    IEnumerator DisplayWinAndLoad()
    {
        winDisplay.gameObject.SetActive(true);
        SceneController.Instance.AddEnemyToManifest(); // despawns enemy upon return to overworld
        yield return new WaitForSecondsRealtime(delay);
        if(PlayerManager.Instance.enemy.isBoss){
            SceneController.Instance.LoadScene("Credits", new Vector3(0,0,0));
        }else{
            SceneController.Instance.ReturnToPrevScene();
        }
        
    }

    IEnumerator DisplayLoseAndLoad()
    {
        loseDisplay.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(delay);
        SceneController.Instance.ReturnToPrevScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGameEnded)
        {
            if (PlayerManager.Instance.player.stat.hp <= 0)
            {
                hasGameEnded = true;
                StartCoroutine(DisplayLoseAndLoad());
            }
            else if (PlayerManager.Instance.enemy.stat.hp <= 0)
            {
                hasGameEnded = true;
                StartCoroutine(DisplayWinAndLoad());
            }
        }
    }
        
}
