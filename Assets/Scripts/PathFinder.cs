using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] Waypoint startPoint, endPoint;

    [SerializeField]bool isRunning = true; //todo private
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
        PathFind();


        // ExploreNeighbours();
    }

    private void PathFind()
    {
        queue.Enqueue(startPoint);

        while (queue.Count>0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            print(searchCenter);
            HaltIfEndFound(searchCenter);
        }


    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter.GetGridPos() == endPoint.GetGridPos())
        {
            print("I found endPoint");
            isRunning = false;

        }
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
