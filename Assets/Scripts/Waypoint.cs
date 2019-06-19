using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //ok, since this is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;
    public bool hasTower = false;

    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
           Mathf.RoundToInt(transform.position.x / gridSize),
           Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    public void setTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = (transform.Find("Top").GetComponent<MeshRenderer>());
        topMeshRenderer.material.color = color;
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {
                if (hasTower)
                {
                    Debug.Log("Tower already on that cube.");
                } else
                {
                    Debug.Log("Not a waypoint.");
                }
            }
        }
    }
}