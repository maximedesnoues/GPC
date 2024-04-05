using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public GameObject slimePrefab; 
    public float spawnRadius = 5f;
    private int entitiesSpawned = 0; 

    void Start()
    {
        StartCoroutine(SpawnSlime());
    }

    IEnumerator SpawnSlime()
    {
        while (entitiesSpawned < 3)
        {            
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            Instantiate(slimePrefab, randomPosition, Quaternion.identity);
            entitiesSpawned++; 
            yield return new WaitForSeconds(2f);
        }
    }
}
