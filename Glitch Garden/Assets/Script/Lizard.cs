using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    [SerializeField] float damage = 100f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Defender>()) 
        {
            GameObject defender= collision.gameObject;
            GetComponent<Attacker>().SetAnimation(defender);
        }
        
    }

}
