using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    Character player;
    int playerHealth;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.Instance.player;
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        playerHealth = player.stat.hp;
        text.text = "Player HP: " + playerHealth.ToString();
    }
}
