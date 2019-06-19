using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{

    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 100;
    [SerializeField] int hits = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;


  //  ScoreBoard scoreBoard;

    void Start()
    {
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
