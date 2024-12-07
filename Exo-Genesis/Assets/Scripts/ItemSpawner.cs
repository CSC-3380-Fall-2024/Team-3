using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> spawnableItems;  //items to spawn
    public List<GameObject> spawnableEnemies; //enemies to spawn
    public Vector2 spawnZoneCenter; 
    public Vector2 spawnZoneSize; //area where items are going to get spawned
    public float spawnInterval = 3f;  //interval between item spawns
    private List<GameObject> spawnedItems = new List<GameObject>();

    private int maxItems = 4; //maximum number of interactabales
    private int maxEnemies = 2; //initial maximum number of enemies
    private float minSpawnDistance = 2f;

    private float timeElapsed = 0f; //time passed since the start
    private float baseEnemySpawnRate = 5f; // Base spawn rate for enemies (in seconds)
    private float spawnRateIncreaseFactor = 0.1f; // Rate at which spawn rate increases over time

    public LayerMask enemyLayer; //layer mask for enemies


    void Start()
    {
        StartCoroutine(SpawnItems());
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        //the longer the game runs, the faster enemies spawn
        //increase the spawn rate dynamically (faster spawn times as time goes on)
        float adjustedEnemySpawnRate = baseEnemySpawnRate - (timeElapsed * spawnRateIncreaseFactor);
        if (adjustedEnemySpawnRate < 1f)
        {
            adjustedEnemySpawnRate = 1f; // Set a lower limit to prevent spawn rate from becoming too fast
        }
    }

    IEnumerator SpawnItems()
    {
        while (true)
        {
            if (spawnedItems.Count < maxItems)
            {
                SpawnNewItem();
            }
            yield return new WaitForSeconds(spawnInterval); //control the item spawn interval
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnNewEnemy();
            yield return new WaitForSeconds(baseEnemySpawnRate); //control the enemy spawn rate
        }
    }

    void SpawnNewItem()
    {
        Vector2 spawnPosition = GetValidSpawnPosition();
        if (spawnPosition != Vector2.zero)
        {
            int randomIndex = Random.Range(0, spawnableItems.Count);
            GameObject itemToSpawn = spawnableItems[randomIndex];
            GameObject newItem = Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);
            spawnedItems.Add(newItem);
            Destroy(newItem, 3f);  //item still get destroyed after 3 seconds
            StartCoroutine(RespawnWhenDestroyed(newItem));  //respawn item after one is destroyed
        }
    }

    void SpawnNewEnemy()
    {
        Vector2 spawnPosition = GetValidSpawnPosition();
        if (spawnPosition != Vector2.zero)
        {
            int randomIndex = Random.Range(0, spawnableEnemies.Count);
            GameObject enemyToSpawn = spawnableEnemies[randomIndex];
            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
            enemyToSpawn.GetComponent<EnemyController>().target = GameObject.Find("Player1").transform;
        }
    }

    Vector2 GetValidSpawnPosition()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(spawnZoneCenter.x - spawnZoneSize.x / 2, spawnZoneCenter.x + spawnZoneSize.x / 2),
                Random.Range(spawnZoneCenter.y - spawnZoneSize.y / 2, spawnZoneCenter.y + spawnZoneSize.y / 2)
            );

            bool isValid = true;
            foreach (GameObject spawnedItem in spawnedItems)
            {
                if (Vector2.Distance(randomPosition, (Vector2)spawnedItem.transform.position) < minSpawnDistance)
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                return randomPosition;
            }
        }

        return Vector2.zero; //if no valid position valid
    }

    //count the number of enemies currently in the scene using the specified layer mask
    int CountEnemiesInLayer()
    {
        int count = 0;
        //find all colliders in the spawn zone that are on the enemy layer
        Collider2D[] enemies = Physics2D.OverlapBoxAll(spawnZoneCenter, spawnZoneSize, 0f, enemyLayer);
        count = enemies.Length;
        return count;
    }

    IEnumerator RespawnWhenDestroyed(GameObject destroyedItem)
    {
        yield return new WaitForSeconds(3f);

        spawnedItems.Remove(destroyedItem);
        Destroy(destroyedItem);

        SpawnNewItem();
    }
}
