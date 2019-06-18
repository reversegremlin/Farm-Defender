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

       // print("enemy hit points remaining: " + hits);
        if (hits <= 0)
        // todo: consider hit effect
        {
            KillEnemy();
           // StartCoroutine(Die());

        }
    }

    private void KillEnemy()
    {
        //   scoreBoard.ScoreHit(scorePerHit);
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
       // Destroy(vfx, 1f);
        Destroy(gameObject);
    }
    //private IEnumerator Die()
    //{
    //    var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
    //    vfx.Play();
    //    yield return new WaitForSeconds(1.0f);
    //    Destroy(vfx); // this is for 2 second delay
    //    Destroy(gameObject);

    //}

}
