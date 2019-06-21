using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrement = 1;
    [SerializeField] ParticleSystem deathParticlePrefab;
    BaseScore baseScore;

    private void Start()
    {
        baseScore = FindObjectOfType<BaseScore>();
        baseScore.SetHealth(health);

    }

    private void OnTriggerEnter(Collider other)
    {
        health -= healthDecrement;
        baseScore.SetHealth(health);

        if (health <= 0)
        {
            SelfDestruct();
        }
    }
     
    public void SelfDestruct()
    {
        Vector3 fixedPosition = transform.position;
        fixedPosition.y += 10;
        var vfx = Instantiate(deathParticlePrefab, fixedPosition, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }

    //todo: stop enemies from spawining
    //todo: make enemies disappear
    //todo: make chicken super

}