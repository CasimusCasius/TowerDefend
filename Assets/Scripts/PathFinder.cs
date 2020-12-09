using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startPoint;
    [SerializeField] Waypoint endPoint;
    private void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
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
