using System.Collections.Generic;
using UnityEngine;

public class StagePlacer : MonoBehaviour
{
    public Transform player;
    public Stage[] stagePrefab;
    public Stage firstStage;

    private List<Stage> spawnedStage = new List<Stage>();
    private void Start()
    {
        spawnedStage.Add(firstStage);
    }
    private void Update()
    {
        if (player != null && (player.position.z > spawnedStage[spawnedStage.Count - 1].end.position.z - 25))
        {
            SpawnStage();
        }
    }
    private void SpawnStage()
    {
        Stage newStage = Instantiate(stagePrefab[Random.Range(0, stagePrefab.Length)]);
        newStage.transform.position = spawnedStage[spawnedStage.Count - 1].end.position - newStage.begin.localPosition;
        spawnedStage.Add(newStage);

        if (spawnedStage.Count >= 4)
        {
            Destroy(spawnedStage[1].gameObject);
            spawnedStage.RemoveAt(0);
        }
    }
}
