using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f,3f)] [SerializeField] float moveSpeed = 1f;
    GameObject target;
    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
        
    }
    private void OnDestroy()
    {
        LevelController lc=FindObjectOfType<LevelController>();
        if (lc != null)
        {
            lc.AttackerKilled();
        }
    }
    private void Update()
    {
        //Set movement for attacker
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        ResetAnimation();
        
    }
    public void ResetAnimation()
    {
        if (!target)
        {
            GetComponent<Animator>().SetBool("Attack", false);
        }
    }
    
   
    public void SetAnimation(GameObject defender)
    {
        GetComponent<Animator>().SetBool("Attack", true);
        target = defender;
    }
    public void Attack(float damage)
    {
        if (!target) 
        {
            return;
        }

        target.GetComponent<Health>().DealDamage(damage);
    }
   
    //Animation events, Enemy doesn't get hurt while jumping/entry point
    public void Invincible()
    {
        GetComponent<Collider2D>().enabled = false;

    }
    public void Ready()
    {
        GetComponent<Collider2D>().enabled = true;
    }
    
    private void ChangeSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
