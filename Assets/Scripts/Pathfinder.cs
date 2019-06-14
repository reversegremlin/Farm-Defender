﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    // Breadth-First based waypoint path finding

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    bool isRunning = true;
    Waypoint searchOrigin;

    public List<Waypoint> path = new List<Waypoint>();


    //directions for pathfinding
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorSourceAndDestination();
        BreadthFirstSearch();
        CreatePath();
        ColorPath();

    }

    private void ColorPath()
    {
        foreach (Waypoint waypoint in path)
        {
            waypoint.setTopColor(Color.blue);
        }
        ColorSourceAndDestination();
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        Waypoint previousWaypoint = endWaypoint.exploredFrom;

        while (previousWaypoint != startWaypoint)
        {
            path.Add(previousWaypoint);
            previousWaypoint = previousWaypoint.exploredFrom;
        }

        path.Add(startWaypoint);
        path.Reverse();

        print(path);
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            searchOrigin = queue.Dequeue();
            searchOrigin.isExplored = true;
            CheckIfEndFound();
            ExploreNeighbors();
        }
    }

    private void CheckIfEndFound()
    {
        if (searchOrigin == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbors()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = searchOrigin.GetGridPos() + direction;
            try
            {
                QueueNewNeighbors(neighborCoordinates);
            }
            catch
            {

            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        if (neighbor.isExplored || queue.Contains(neighbor))
        {
            //do nothing
        }
        else 
        {
         //   neighbor.setTopColor(Color.blue);  // move later
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchOrigin;
            print("Queueing " + neighbor + " exploredFrom: " + neighbor.exploredFrom);
        }
    }

    private void ColorSourceAndDestination()
    {
        startWaypoint.setTopColor(Color.green);
        endWaypoint.setTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GetGridPos()))
            { }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}