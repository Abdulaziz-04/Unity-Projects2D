using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    [SerializeField] float damage = 100f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Defender>())
        {
            if (collision.tag == "GraveStone")
            {
                GetComponent<Animator>().SetTrigger("Jump");
            }
            else
            {
                GameObject defender = collision.gameObject;
                GetComponent<Attacker>().SetAnimation(defender);
            }
        }
        
        
    }

}
