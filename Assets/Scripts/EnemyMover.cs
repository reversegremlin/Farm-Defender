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
            //print("old position: " + transform.position);
            //print("new position: " + waypoint.transform.position);
            //if (transform.position.x > waypoint.transform.position.x)
            //{
            //    transform.Rotate(0, 90, 0);
            //}
            //else if (transform.position.z > waypoint.transform.position.z)
            //{
            //    transform.Rotate(0, -90, 0);

            //}
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
        //   scoreBoard.ScoreHit(scorePerHit);
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
