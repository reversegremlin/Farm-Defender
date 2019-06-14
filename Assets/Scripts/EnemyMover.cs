using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] float dwellTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 pos = new Vector3(
            waypoint.transform.position.x + 15f,
            waypoint.transform.position.y + 6f,
            waypoint.transform.position.z
            );

            transform.position = pos;
            yield return new WaitForSeconds(dwellTime);
        }
    }
}
