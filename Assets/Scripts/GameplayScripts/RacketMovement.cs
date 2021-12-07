using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    //Movement controls
    Vector3 touchPos;
    Vector2 myPosition;
    Touch touch;

    [Header("Player Spawnpoint")]
    public Transform playerSpawn;

    [Header("Touch Clamps")]
    public Transform topBarrier;
    public Transform bottomBarrier;
    
    //Rigidbodies
    Rigidbody2D player;

    [Header("Other Options")]
    bool playerFreezed;
    [Range(0, 100)]
    public float force;
    public bool singlePlayer;


    private void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(singlePlayer)
        {
            movePlayerSolo();
        }
        else
        {
            movePlayerMulti();
        }
    }

    private void movePlayerSolo()
    {
        if (Input.touchCount > 0 && !playerFreezed)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                myPosition = player.position;

                if (Mathf.Abs(player.position.x - touchPos.x) <= 2)
                {
                    myPosition.y = Mathf.Lerp(myPosition.y, touchPos.y, force);
                    myPosition.y = Mathf.Clamp(myPosition.y, bottomBarrier.position.y + this.gameObject.GetComponent<Collider2D>().bounds.size.y / 2,
                                               topBarrier.position.y);

                    player.position = myPosition;
                }
            }
        }
    }

    private void movePlayerMulti()
    {
        if(Input.touchCount > 0 && !playerFreezed)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                touch = Input.touches[i];
                if(touch.phase == TouchPhase.Moved)
                {
                    touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    myPosition = player.position;

                    if(Mathf.Abs(player.position.x - touchPos.x) <= 2)
                    {
                        myPosition.y = Mathf.Lerp(myPosition.y, touchPos.y, force);
                        myPosition.y = Mathf.Clamp(myPosition.y, bottomBarrier.position.y + this.gameObject.GetComponent<Collider2D>().bounds.size.y / 2,
                                                   topBarrier.position.y);

                        player.position = myPosition;
                    }
                }
            }
        }
    }

    public Transform getPlayerStartingPosition()
    {
        return playerSpawn;
    }

    public void freezePlayer(bool freeze)
    {
        this.playerFreezed = freeze;
    }
}
