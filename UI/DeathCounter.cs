using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class DeathCounter : MonoBehaviour
{
    public int deathEnemyCount = 0;
    public TextMeshProUGUI death_state;
    private void Awake()
    {
        HealAndDamageEnemy.OnEnemyDeath += IncrementDeathEnemyCount;
    }
    private void Update()
    {
        if (deathEnemyCount >= 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void IncrementDeathEnemyCount()
    {
        deathEnemyCount+=1;
        death_state.text = deathEnemyCount.ToString();
    }
}