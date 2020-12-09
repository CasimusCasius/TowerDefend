﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class EditorSnap : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;
    [SerializeField] bool isHeight = false;
    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x/ gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        if (isHeight)
        {
            snapPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;
        }
        else
        {
            snapPos.y = 0;
        }

        transform.position = new Vector3(snapPos.x, snapPos.y, snapPos.z);


    }
}