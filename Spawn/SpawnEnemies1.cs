using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesOne : MonoBehaviour
{
    public Transform[] enemiesSide;
    public GameObject enemyPrefab;
    private List<GameObject> spawnedEnemies1 = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < enemiesSide.Length; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, enemiesSide[i].position, enemiesSide[i].rotation);
            spawnedEnemies1.Add(newEnemy);
        }
    }
    private void OnDestroy()
    {
        foreach (GameObject enemy in spawnedEnemies1)
        {
            Destroy(enemy);
        }
    }
}