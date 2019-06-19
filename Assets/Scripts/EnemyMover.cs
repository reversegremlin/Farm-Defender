using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] float dwellTime = 1.0f;
    [SerializeField] ParticleSystem deathParticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        //known bug, if there is no path, bad things happen. 

        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(dwellTime);
        }
        KillEnemy();
    }
    public void KillEnemy()
    {
        //   scoreBoard.ScoreHit(scorePerHit);
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
