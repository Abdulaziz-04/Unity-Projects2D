using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    HealthMgmt currentHealth;
    [Header("Player Movement")]
    [SerializeField] float gameSpeed = 10f;
    [SerializeField] float padding=1f;
    [SerializeField] float startHealth = 100f;
    float health;
    [Header("Laser Attributes")]
    [SerializeField] float projectileSpeed=10f;
    [SerializeField] float projectileDelay = 0.1f;
    [SerializeField] GameObject laserProjectile;
    [Header("VFX and SFX")]
    [SerializeField] GameObject deathVfx;
    [SerializeField] AudioClip deathSfx;
    [SerializeField] AudioClip laserSfx;
    [SerializeField] float deathSfxVol=0.7f;
    [SerializeField] float laserSfxVol = 0.5f;



    float xMin,xMax,yMin,yMax;

    Coroutine FiringCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        ClampBoundaries();
        
    }

    // Update is called once per frame
    void Update()
    {
        SetupMovement();
        FireLaser();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage dmg = collision.GetComponent<Damage>();
        health -= dmg.GetDamage();
        FindObjectOfType<HealthMgmt>().SetHealth(health, startHealth);
        dmg.destroyLaser();
        if (health <= 0f)
        {
            Destroy(gameObject);
            GameObject deathExpvfx = Instantiate(deathVfx, transform.position, Quaternion.identity);
            Destroy(deathExpvfx, 1f);
            AudioSource.PlayClipAtPoint(deathSfx, Camera.main.transform.position, deathSfxVol);
            FindObjectOfType<SceneMgmt>().LoadEndscreen();
        }
        
    }
    private void SetupMovement()
    {
        //Get positions of object on basis of axial movement
        //To set the speed frame independent we multiply by time.deltatime to convert movement/frame to movement/second
        //To set a normal speed we multiply by gameSpeed
        var deltaX = Input.GetAxis("Horizontal")*Time.deltaTime*gameSpeed;
        var deltaY = Input.GetAxis("Vertical")*Time.deltaTime*gameSpeed;

        //Add to the current postion
        var xPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        var yPos = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);

        //Set new position
        transform.position = new Vector2(xPos, yPos);
    }
    private void FireLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FiringCoroutine=StartCoroutine(FireCont());
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(FiringCoroutine);

        }

    }
    private void ClampBoundaries()
    {
        Camera mainCam = Camera.main;
        xMin = mainCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+padding;
        xMax = mainCam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-padding;
        yMin = mainCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+padding;
        yMax = mainCam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y-padding;
    }
    IEnumerator FireCont()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserProjectile, transform.position,Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity=new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(laserSfx, Camera.main.transform.position, laserSfxVol);
            yield return new WaitForSeconds(projectileDelay);
        }
   }
}
