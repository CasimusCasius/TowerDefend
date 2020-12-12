using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitpoints = 10;
    [SerializeField] GameObject deathFX;


    private void Start()
    {
        AddBoxCollider();
    }

    private void AddBoxCollider()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.center = new Vector3(0, 5f, 0);
        boxCollider.size = new Vector3(5f, 5f, 5f);
        boxCollider.isTrigger = false;
    }
    private void OnParticleCollision(GameObject other)
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        hitpoints--;
        if (hitpoints < 1)
        {
            deathFX.SetActive(true);
            SendMessage("Death");
            Destroy(gameObject,1f);
        }
    }
}
