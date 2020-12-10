using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startPoint, endPoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();


    bool isRunning = true; //todo private
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.left,
        Vector2Int.down,
        Vector2Int.right
    };
    Waypoint searchCenter;

    List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
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


    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbours();
        }

        print("is that all?");
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endPoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordninates = searchCenter.GetGridPos() + direction;
            QueueNewNeighbour(neighbourCoordninates);
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourCoordninates)
    {
        if (grid.ContainsKey(neighbourCoordninates) && !grid[neighbourCoordninates].isExplored)
        {
            queue.Enqueue(grid[neighbourCoordninates]);
            UpdateWaypointData(neighbourCoordninates);
        }
    }

    private void UpdateWaypointData(Vector2Int neighbourCoordninates)
    {
        grid[neighbourCoordninates].exploredFrom = searchCenter;
        grid[neighbourCoordninates].isExplored = true;
    }

    private void CreatePath()
    {
        path.Add(endPoint);
        Waypoint previous = endPoint.exploredFrom;
        while (previous != startPoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startPoint);
        path.Reverse();
    }


}
