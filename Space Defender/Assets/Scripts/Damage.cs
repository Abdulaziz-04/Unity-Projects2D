using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage = 100f;
    public float GetDamage()
    {
        return damage;
    }
    public void destroyLaser()
    {
        Destroy(gameObject);
    }
}
