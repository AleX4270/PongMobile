using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("Rigidbodies")]
    public Rigidbody2D ball;
    Rigidbody2D racket;

    [Header("Other controls")]
    public float racketSpeed = 10f;
    public float middleOffset;

    [Header("AI Spawnpoint")]
    public Transform aiSpawn;

    // Start is called before the first frame update
    void Start()
    {
        racket = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ball.position.x < 0.0f + middleOffset)
        {
            
            if (ball.position.y > this.transform.position.y)
            {
                racket.AddForce(Vector2.up * this.racketSpeed);
            }
            else if (ball.position.y < this.transform.position.y)
            {
                racket.AddForce(Vector2.down * this.racketSpeed);
            }
        }
        else
        {
            if (this.transform.position.y < 0.0f + middleOffset)
            {
                racket.AddForce(Vector2.up * this.racketSpeed/4);
            }
            else if (this.transform.position.y > 0.0f)
            {
                racket.AddForce(Vector2.down * this.racketSpeed/4); 
            }
        }
    }

    public Transform getAiStartingPosition()
    {
        return aiSpawn;
    }
}
