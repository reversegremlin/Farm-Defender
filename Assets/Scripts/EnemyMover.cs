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
            Vector3 fixedPosition = waypoint.transform.position;
            fixedPosition.y -= 5;

           // transform.position = waypoint.transform.position;
            transform.position = fixedPosition;
            yield return new WaitForSeconds(dwellTime);
        }
        SelfDestruct();
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
}
