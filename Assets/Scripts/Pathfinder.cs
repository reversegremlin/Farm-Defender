using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    // Breadth-First based waypoint path finding

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    bool isRunning = true;

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
        FindPath();
       // ExploreNeighbors();

    }

    private void FindPath()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            var searchOrigin = queue.Dequeue();
            searchOrigin.isExplored = true;
            print("Searching from: " + searchOrigin);
            CheckIfEndFound(searchOrigin);
            ExploreNeighbors(searchOrigin);
        }
        print("finished pathfinding?");  //not really, need to actually work out path.
    }

    private void CheckIfEndFound(Waypoint searchOrigin)
    {
        if (searchOrigin == endWaypoint)
        {
            print("Searching from End Node, stopping.");
            isRunning = false;
        }
    }

    private void ExploreNeighbors(Waypoint from)
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = from.GetGridPos() + direction;
            try
            {
                QueueNewNeighbors(neighborCoordinates);
            }
            catch
            {
                print("skipping non-existing neighbor");
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        if (!neighbor.isExplored)
        {
            neighbor.setTopColor(Color.blue);  // move later
            queue.Enqueue(neighbor);
            print("Queueing " + neighbor);
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
