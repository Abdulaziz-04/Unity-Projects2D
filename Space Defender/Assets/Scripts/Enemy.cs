using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Enemy Stats")]
    [SerializeField] float health=500f;
    [SerializeField] int scoreVal = 150;
    [Header("Laser Attributes")]
    [SerializeField] float minTime = 0.3f;
    [SerializeField] float maxTime = 3f;
    [SerializeField] float projectileSpeed=10f;
    [SerializeField] GameObject laserPrefab;
    [Header("VFX and SFX")]
    [SerializeField] float explosionTime=0.7f;
    [SerializeField] GameObject[] explosions;
    [SerializeField] AudioClip deathSfx;
    [SerializeField] AudioClip laserSfx;
    [SerializeField] float deathSfxVol=0.7f;
    [SerializeField] float laserSfxVol = 0.5f;
    [Header("Boss Attributes")]
    [SerializeField] GameObject superLaserPrefab;
    [SerializeField] Vector3 srFactor=new Vector3(1,1,0);
    [SerializeField] Vector3 slFactor = new Vector3(1, 1.2f, 0);
 
 




    int explosionSelector;
    WaveConfig waveType;
    List<Transform> wayPoints;
    float shotCounter;
    int waypointInd = 0;
    void Start()
    {
        //Fill the list with all the waypoints avaialble for current waveConfig
        wayPoints = waveType.GetpathPrefab();
        //Set the enemy to the first inital position
        transform.position = wayPoints[waypointInd].position;
        //Shoot timer
        shotCounter = Random.Range(minTime, maxTime);
    }
    //Assign the waveType to access the paths and speeds for current config
    public void SetWaveConfig(WaveConfig wave)
    {
        this.waveType = wave;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            if (tag == "Boss")
            {
                BossFire();

            }
            else
            {

                EnemyFire();

            }
            shotCounter = Random.Range(minTime, maxTime);
        }
    }
    private void EnemyMove()
    {
        //traverse through waypoints presented as locations on play area
        //if we haven't reached the waypoint set speed and target for the MoveTowards function
        if (waypointInd <= wayPoints.Count - 1)
        {
            var targetPos = wayPoints[waypointInd].position;
            var speed = waveType.GetenemySpeed()* Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);
            //If we have reached the currentPos set the next pos
            if (transform.position == targetPos)
            {
                waypointInd++;
            }
        }
        //If we have traversed through all  waypoints destroy the object
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage dmg = collision.gameObject.GetComponent<Damage>();
        health -= dmg.GetDamage();
        dmg.destroyLaser();
        if (health <= 0)
        {
            explosionSelector = Random.Range(0, explosions.Length);
            Destroy(gameObject);
            GameObject expVFX =Instantiate(explosions[explosionSelector], transform.position, Quaternion.identity);
            Destroy(expVFX, explosionTime);
            AudioSource.PlayClipAtPoint(deathSfx, Camera.main.transform.position, deathSfxVol);
            FindObjectOfType<GameSession>().AddtoScore(scoreVal);

        }
        
    }
    private void EnemyFire()
    {
        
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(laserSfx, Camera.main.transform.position, laserSfxVol);


    }
    private void BossFire()
    {
        GameObject laser1 = Instantiate(laserPrefab, transform.position+slFactor, Quaternion.identity) as GameObject;
        laser1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(laserSfx, Camera.main.transform.position, laserSfxVol);
        GameObject laser2 = Instantiate(superLaserPrefab, transform.position-srFactor, Quaternion.identity) as GameObject;
        laser2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -(projectileSpeed + 5f));
    }

}
