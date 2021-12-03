using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballSpeed = 10f;
    public float addingForce;
    public float bounceDir;
    Rigidbody2D ball;
    public RacketMovement racketController;
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        defineDirection();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        //Racket hit
        if(collision.gameObject.CompareTag("Racket"))
        {
            //Calculate new vector and bounce type + add the force
            Vector2 collisionPoint = collision.GetContact(0).point;
            calculateBounce(collision, racketController.hitOffset);
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
            Debug.Log("RelVel: " + relVel);

            ball.velocity = new Vector2(relVel.x * -1, relVel.y);
            Debug.Log("Ball Vel: " + ball.velocity);

            audioManager.PlaySound("wallHit");
        }
    }

    private void calculateBounce(Collision2D collision, float offset)
    {
        
        Vector2 contactPoint = collision.GetContact(0).point;
        Vector2 racketPosition = collision.gameObject.transform.localPosition;
        Vector2 relVel = collision.GetContact(0).relativeVelocity;

        float offsetUp = racketPosition.y + offset;
        float offsetDown = racketPosition.y - offset;
        //Middle Hit
        if(collision.collider.CompareTag("MiddleHit"))
        {
            Debug.Log("Trafiono w œrodek!");
            ball.velocity = new Vector2(relVel.x < 0 ? relVel.x - addingForce : relVel.x + addingForce, 0);
        }
        
        if(collision.collider.CompareTag("TopHit"))
        {
            Debug.Log("Trafiono w górn¹ czêœæ!");
            ball.velocity = new Vector2(relVel.x < 0 ? relVel.x - addingForce : relVel.x + addingForce, 
                                        bounceDir + addingForce);
        }

        if (collision.collider.CompareTag("BottomHit")) 
        {
            Debug.Log("Trafiono w doln¹ czêœæ!");
            ball.velocity = new Vector2(relVel.x < 0 ? relVel.x - addingForce : relVel.x + addingForce, 
                                        -bounceDir - addingForce);
        }  
    }
}
