using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startPoint, endPoint;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };
    private void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explore=startPoint.GetGridPos()+direction;
            if (grid.ContainsKey(explore))
            {
                print("exploring: " + explore);
            }
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (!grid.ContainsKey(gridPos))
            {
                grid.Add(gridPos, waypoint);
                waypoint.SetTopColor(Color.gray);
            }
            else
            {
                Debug.LogWarning("I have that block :" + waypoint.name);
            }

        }
        startPoint.SetTopColor(Color.green);
       
    }

    private void ColorStartAndEnd()
    {
        endPoint.SetTopColor(Color.red);
        print("Loaded blocks: " + grid.Count);
    }
}
