using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine (FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            if (isAlive) {
                transform.position = waypoint.transform.position;
            }
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol...");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Death()
    {
        isAlive = false;
    }
}
