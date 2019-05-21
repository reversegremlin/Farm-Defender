using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<Block> enemyPath;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Block cube in enemyPath)
        {
            print(cube.name);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
