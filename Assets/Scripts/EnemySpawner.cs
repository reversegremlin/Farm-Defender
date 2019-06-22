using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 3.0f;
    [SerializeField] int maxEnemies = 5;
    [SerializeField] EnemyMover enemyToSpawn;
    [SerializeField] Transform enemyParent;

    [SerializeField] AudioClip spawnEnemySFX;

    [SerializeField] Text score;

    int enemiesKilled = 0;



    // Start is called before the first frame update
    void Start()
    {
        score.text = enemiesKilled.ToString();
        StartCoroutine(SpawnEnemies());
    }

    public void EnemyKilled()
    {
        ++enemiesKilled;
        score.text = enemiesKilled.ToString();
    }

    IEnumerator SpawnEnemies()
	{
        while (maxEnemies > 1)
        {
            GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX);
            var newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
			yield return new WaitForSeconds(secondsBetweenSpawns);
            maxEnemies--;
        }
    }
}
