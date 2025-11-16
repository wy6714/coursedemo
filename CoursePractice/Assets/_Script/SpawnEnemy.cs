using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    //public Transform spawnPoint1;
    public GameObject enemyPrefab;
    public float spawnRate;

    [Header ("spwanposition")]
    public Vector2 xRange = new Vector2(-9f, -3f);
    public Vector2 yRange = new Vector2(-2f, 2f);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(spawnRate);

        }
    }

    void SpawnEnemies()
    {
        float randomX = Random.Range(xRange.x, xRange.y);
        float randomY = Random.Range(yRange.x, yRange.y);

        Vector2 spawnPos = new Vector2(randomX, randomY);
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
