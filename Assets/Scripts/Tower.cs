using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] int attackRange = 3;
    [SerializeField] ParticleSystem bullets;

    // Update is called once per frame
    void Update()
    {
        // observe
        objectToPan.LookAt(targetEnemy);
        Fire();

    }

    private void Fire()
    {
        
        if (IsTargetAlive() && CheckDistance(targetEnemy) <= attackRange*10)
        {
            bullets.gameObject.SetActive(true);
        }
        else
        {
            bullets.gameObject.SetActive(false);
        }

    }

    private float CheckDistance(Transform targetEnemy)
    {
        return Vector3.Distance(targetEnemy.position,gameObject.transform.position);
    }

    private bool IsTargetAlive()
    {
        if (targetEnemy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
