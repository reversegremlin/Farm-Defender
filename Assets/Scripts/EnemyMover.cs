using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    //[SerializeField] List<Block> enemyPath;
    //[SerializeField] float dwellTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(FollowPath());
    }

    //IEnumerator FollowPath()
    //{
    //    foreach (Block cube in enemyPath)
    //    {
    //        Vector3 pos = new Vector3(
    //        cube.transform.position.x + 15f,
    //        cube.transform.position.y + 6f,
    //        cube.transform.position.z
    //        );

    //        gameObject.transform.position = pos;
    //        yield return new WaitForSeconds(dwellTime);
    //    }
    //}
}
