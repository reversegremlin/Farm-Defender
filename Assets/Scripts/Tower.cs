using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;


    //public class ExampleClass : MonoBehaviour
    //{
    //    public Transform target;

    //    void Update()
    //    {
    //        // Rotate the camera every frame so it keeps looking at the target
    //        transform.LookAt(target);
    //    }
    //}

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        objectToPan.LookAt(targetEnemy);
    }
}
