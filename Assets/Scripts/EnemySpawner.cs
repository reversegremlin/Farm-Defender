using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] float secondsBetweenSpawns = 3.0f;
    [SerializeField] EnemyMover enemyToSpawn;

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
	{
        while (true)
		{
			print("spawining...");
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
