using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{

    BallController ball;
    public float addingForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ball = collision.gameObject.GetComponent<BallController>();

        if(ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;

            ball.AddForce(-normal * addingForce);
        }
    }

}
