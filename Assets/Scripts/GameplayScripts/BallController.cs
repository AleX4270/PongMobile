using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Other controls")]
    public float ballSpeed = 10f;
    public float addingForce;
    public float bounceDir;
    private bool hitBlock;

    [Header("Rigidbodies")]
    Rigidbody2D ball;

    [Header("Script References")]
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        defineDirection();
        hitBlock = false;
    }

    public void defineDirection()
    {
        ball = GetComponent<Rigidbody2D>();

        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        ball.AddForce(new Vector2(x, y) * this.ballSpeed);
    }

    public void resetBall()
    {
        ball = GetComponent<Rigidbody2D>();
        ball.position = Vector2.zero;
        ball.velocity = Vector2.zero;
    }

    public void AddForce(Vector2 addedForce)
    {
        ball.AddForce(addedForce);
    }

    IEnumerator waitSeconds(float seconds)
    {
        Debug.Log(hitBlock);
        yield return new WaitForSecondsRealtime(seconds);
    }

    private void Update()
    {
        StartCoroutine(waitSeconds(0.3f));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Racket hit
        if(collision.gameObject.CompareTag("Racket"))
        {
            calculateBounce(collision);
            audioManager.PlaySound("racketHit");
            
        }

        if(collision.gameObject.CompareTag("AIRacket"))
        {
            Vector2 relVel = collision.GetContact(0).relativeVelocity;
            ball.velocity = new Vector2(relVel.x, relVel.y * -1);
            audioManager.PlaySound("racketHit");
                
        }

        //Wall hit
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 relVel = collision.GetContact(0).relativeVelocity;
            ball.velocity = new Vector2(relVel.x * -1, relVel.y);
            //audioManager.PlaySound("wallHit");
                
        }
    }

    private void calculateBounce(Collision2D collision)
    {
        Vector2 relVel = collision.GetContact(0).relativeVelocity;

        if(collision.collider.CompareTag("MiddleHit"))
        {
            Debug.LogWarning("Œrodek");
            ball.velocity = new Vector2(relVel.x - addingForce, 0);

        }
        else if(collision.collider.CompareTag("TopHit"))
        {
            Debug.LogWarning("Góra");

            ball.velocity = new Vector2(relVel.x - addingForce, bounceDir + addingForce);
            
        }
        else if (collision.collider.CompareTag("BottomHit")) 
        {
            Debug.LogWarning("Dó³");

            ball.velocity = new Vector2(relVel.x - addingForce, -bounceDir - addingForce);
            
        }  
    }
}
