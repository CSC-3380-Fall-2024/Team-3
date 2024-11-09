using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> spawnableItems;  //items to spawn
    public Vector2 spawnZoneCenter;  
    public Vector2 spawnZoneSize;
    public float spawnInterval = 3f;  //interval btw spawns (how long after an item is destroyed to spawn a new one)
    private List<GameObject> spawnedItems = new List<GameObject>(); 

    private int maxItems = 4;  
    private float minSpawnDistance = 2f;

    void Start()
    {
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (true)
        {
            if (spawnedItems.Count < maxItems)
            {
                SpawnNewItem();
            }
            yield return null;
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
            Destroy(newItem, 3f);  
            StartCoroutine(RespawnWhenDestroyed(newItem));  //respawn item after one is destroyed
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

        return Vector2.zero; //if no valid pos
    }

    IEnumerator RespawnWhenDestroyed(GameObject destroyedItem)
    {
        yield return new WaitForSeconds(3f);

        spawnedItems.Remove(destroyedItem);
        Destroy(destroyedItem);

        SpawnNewItem();
    }
}

