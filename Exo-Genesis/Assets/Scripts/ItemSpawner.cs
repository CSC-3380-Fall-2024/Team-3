using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject poisonBerryPrefab;
    public GameObject regularBerryPrefab;
    public float spawnInterval = 5f;
    public int maxItemsToSpawn = 10;

    private void Start()
    {
        StartCoroutine(SpawnItems());
    }
    private System.Collections.IEnumerator SpawnItems()
    {
        for (int i = 0; i < maxItemsToSpawn; i++)
        {
            GameObject berryToSpawn = Random.value > 0.5f ? poisonBerryPrefab : regularBerryPrefab;
            Instantiate(berryToSpawn, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}