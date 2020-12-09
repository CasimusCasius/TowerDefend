using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (!grid.ContainsKey(gridPos))
            {
                grid.Add(gridPos, waypoint);
            }
            else
            {
                Debug.LogWarning("I have that block :" + waypoint.name);
            }
            print("Loaded blocks: " + grid.Count);
        }
    }
}
