using UnityEngine;
using UnityEngine.SceneManagement;

public class NewCamera : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 6f, -10f);
    //private int deathPlayerCount = 0;
    private Transform target;
    private void Awake()
    {
     //   HealAndDamagePlayer.OnPlayerDeath += IncrementDeathPlayerCount;
    target = GameObject.Find("Player").transform;
    }
    void LateUpdate()
    {
        if (target != null)
        {
            this.transform.position = target.TransformPoint(camOffset);
            this.transform.LookAt(target);
        }
        else
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        /*        if (deathPlayerCount == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }*/
    }
    /*    private void IncrementDeathPlayerCount()
    {
        deathPlayerCount += 1;
        death_state.text = deathEnemyCount.ToString();
    }*/
}
