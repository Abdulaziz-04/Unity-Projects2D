using UnityEngine;

public class Initiate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Paddlemovement paddle;
    [SerializeField] float launchxval = 2f;
    [SerializeField] float launchyval = 10f;
    [SerializeField] AudioClip[] collideSounds; //an array to store the audioclips
    [SerializeField] float randomFactor= 10f;
    //Cache data to speed up process
    AudioSource audiostr;
    Rigidbody2D cachedBody2d;
    bool start = false;
    Vector2 offsetVal;
    void Start()
    {
        //Here this object is attached to the ball which calculates the distance between pivots of both objects and 
        // keeps the ball attached to the paddle
        offsetVal = transform.position - paddle.transform.position;
        audiostr = GetComponent<AudioSource>();
        cachedBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            MaintainOffset();
            LaunchBall();
        }
           }
    private void MaintainOffset()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = offsetVal + paddlePos;

    }
    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = true;
            cachedBody2d.velocity = new Vector2(launchxval, launchyval);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (start)
        {
            Vector2 velocityTweak= new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
            AudioClip clip = collideSounds[Random.Range(0, collideSounds.Length)];  //this is private so another object was instantiated
            audiostr.PlayOneShot(clip);  //clip played after previous one is completed
            cachedBody2d.velocity += velocityTweak;
        }
    }
}
