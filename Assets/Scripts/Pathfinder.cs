using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

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
        ExploreNeighbors();

    }

    private void ExploreNeighbors()
    {
        print("Start waypoint: " + startWaypoint.GetGridPos());

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbor = startWaypoint.GetGridPos() + direction;
            grid[neighbor].setTopColor(Color.blue);
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
            {
                Debug.LogWarning("Skipping overlapping Block " + waypoint);
            } else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
        print("Loaded " + grid.Count + " blocks");
    }
}
