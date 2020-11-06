using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour
{
    Charater enemy;
    int enemyHealth;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        enemy = PlayerManager.Instance.enemy;
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        enemyHealth = enemy.hp;
        text.text = "Enemy HP: " + enemyHealth.ToString();
    }
}
