using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCollider : MonoBehaviour
{

    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 100;
    [SerializeField] int hits = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] Text score;

    int enemiesKilled = 0;


  //  ScoreBoard scoreBoard;

    void Start()
    {
        score.text = enemiesKilled.ToString();

        AddNonTriggerBoxCollider();
     //   scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        --hits;
        hitParticlePrefab.Play();

        if (hits <= 0)
        {
            ++enemiesKilled;
            score.text = enemiesKilled.ToString();
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        //   scoreBoard.ScoreHit(scorePerHit);
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }

}
