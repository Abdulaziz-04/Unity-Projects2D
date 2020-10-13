using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float rotate = 30f;
    [SerializeField] float damage = 100f;
    public void Update()
    {
        //Set movement of projectile for each frame
        transform.Translate(Vector2.right* Time.deltaTime * speed,Space.World);
        transform.Rotate(Vector3.forward, -(rotate * Time.deltaTime));

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //on Collision detection deal damage and reduce the health
        var enemy = collision.GetComponent<Health>();
        if (enemy)
        {
            enemy.DealDamage(damage);
            Destroy(gameObject);
        }
    }

}
