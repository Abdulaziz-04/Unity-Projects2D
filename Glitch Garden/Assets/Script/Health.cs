using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] Vector3 offset;
    [SerializeField] AudioClip deathSFX;
 
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Destroy(gameObject);
            TriggerVFX();
            TriggerSFX();
        }

    }
     private void TriggerVFX()
     {
            GameObject tmpVFX= Instantiate(deathVFX, transform.position-offset, transform.rotation) ;
            Destroy(tmpVFX, 0.5f);

     }
     private void TriggerSFX()
     {
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, 0.4f);
     }

}
