using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;

    int towerCount = 0;


    public void AddTower(Waypoint baseWaypoint)
    {
        // hasTower = true;

        if (towerCount < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
        }
    }

    private void MoveExistingTower()
    {
        Debug.Log("Max Towers Reached");
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Vector3 fixedPosition = baseWaypoint.transform.position;
        fixedPosition.y -= 4;
        Instantiate(towerPrefab, fixedPosition, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
        baseWaypoint.hasTower = true;
        towerCount++;
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
