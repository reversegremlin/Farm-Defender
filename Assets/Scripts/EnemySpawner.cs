using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 3.0f;
    [SerializeField] EnemyMover enemyToSpawn;
    [SerializeField] Transform enemyParent;

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
	{
        while (true)
        {
            var newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
			yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
