using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_CombatTransition : MonoBehaviour
{
    public Transform winDisplay, loseDisplay;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        Transform canvas = GameObject.Find("Canvas").transform;
        winDisplay = canvas.Find("WinDisplay");
        loseDisplay = canvas.Find("LoseDisplay");
    }

    IEnumerator DisplayWinAndLoad()
    {
        Time.timeScale = 0;
        winDisplay.gameObject.SetActive(true);
        SceneController.Instance.AddEnemyToManifest();
        yield return new WaitForSecondsRealtime(delay);
        SceneController.Instance.LoadScene("Test_Overworld", Vector2.zero);
        Time.timeScale = 1;
    }

    IEnumerator DisplayLoseAndLoad()
    {
        Time.timeScale = 0;
        loseDisplay.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(delay);
        SceneController.Instance.LoadScene("Test_Overworld", Vector2.zero);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerManager.Instance.player.stat.hp <= 0){
            StartCoroutine(DisplayLoseAndLoad());
        }
        else if (PlayerManager.Instance.enemy.stat.hp <= 0)
        {
            StartCoroutine(DisplayWinAndLoad());
        }
    }
}
