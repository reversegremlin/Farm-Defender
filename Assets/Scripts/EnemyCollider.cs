using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCollider : MonoBehaviour
{

    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 100;
    [SerializeField] int hits = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] AudioClip enemyDamageSFX;
    [SerializeField] AudioClip enemyDeathFX;

    AudioSource myAudioSource;

    PlayerScore scoreBoard;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<PlayerScore>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        --hits;
        myAudioSource.PlayOneShot(enemyDamageSFX);
        hitParticlePrefab.Play();

        if (hits <= 0)
        {
            scoreBoard.ScoreHit(scorePerHit);
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        AudioSource.PlayClipAtPoint(enemyDeathFX, Camera.main.transform.position);
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }

}
