using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCommand : MonoBehaviour
{


    [SerializeField]
    private GameObject enemySlime;
    [SerializeField]
    private float enemySpawnTimer = 3.0f;

    public Transform spawnPoint;
    

    void Start()
    {
        StartCoroutine(SpawnEnemy(enemySpawnTimer, enemySlime));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        StartCoroutine(SpawnEnemy(interval,enemy));
    }
}
