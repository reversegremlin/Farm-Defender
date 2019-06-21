using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;
    [SerializeField] Transform towerParent;

    int towerCount = 0;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;

        if (towerCount < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

  

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Vector3 fixedPosition = baseWaypoint.transform.position;
        fixedPosition.y -= 4;
        var newTower = Instantiate(towerPrefab, fixedPosition, Quaternion.identity);
        newTower.transform.parent = towerParent;
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        baseWaypoint.hasTower = true;
        towerCount++;
        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;
        oldTower.baseWaypoint.hasTower = false;
        oldTower.baseWaypoint = newBaseWaypoint;
        Vector3 fixedPosition = newBaseWaypoint.transform.position;
        newBaseWaypoint.isPlaceable = false;
        newBaseWaypoint.hasTower = true;
        fixedPosition.y -= 4;
        oldTower.transform.position = fixedPosition; 
        towerQueue.Enqueue(oldTower);
        //set the basewaypoints

        // put the old tower back on the queue

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
