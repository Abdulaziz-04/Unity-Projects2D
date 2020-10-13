using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Blockdestroy : MonoBehaviour
{
    Level lev;
    [SerializeField] GameObject sparkleVfx;
    [SerializeField] int maxHits;
    [SerializeField] int currentHit;
    [SerializeField] Sprite[] hitEffects;
    public void Start()
    {
        lev = FindObjectOfType<Level>();  //we could also perform serialize feild of type block and assign blocks to the level script 
        if (tag != "unbreakable")
        {
            lev.BlockPlus(); //this is assigned to the block script so this counts the number of blocks
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //AudioSource.PlayClipAtPoint(anysound, Camera.main.transform.position);
        //If game object gets destroyed sound component also gets destroyed so an independent component is created for 
        //this purpose

       if (tag != "unbreakable")
        {
            currentHit++;
            if (currentHit == maxHits)
            {
                Destroy(gameObject);   //gameobject refers to the object itself
                TriggerEffect();
                lev.BlockMinus();
                lev.AddScore();
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = hitEffects[currentHit- 1]; 

            }
       }
    }
    private void TriggerEffect()
    {
        GameObject sparkles = Instantiate(sparkleVfx, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
