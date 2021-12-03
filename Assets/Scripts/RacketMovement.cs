using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{

    Vector3 startingPosition;
    Vector3 touchPos;
    Vector2 myPosition;
    Touch touch;
    public Rigidbody2D player;
    public Transform offsetMarker;

    [Range(0, 100)]
    public float force;

    public float touchOffset = 0.2f;
    public float hitOffset;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = this.transform.position;

        adjustOffsetMarker(offsetMarker);
        offsetMarker.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        offsetMarker.position = this.transform.position;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {             
                touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                myPosition = player.position;

                if(Mathf.Abs(player.position.x - touchPos.x) <= 2)
                {
                    myPosition.y = Mathf.Lerp(myPosition.y, touchPos.y, force);
                    myPosition.y = Mathf.Clamp(myPosition.y, (-cam.orthographicSize + touchOffset), (cam.orthographicSize - touchOffset));

                    player.position = myPosition;
                }
            }
        }
        else
        {
            player.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        
    }

    public void adjustOffsetMarker(Transform offsetMarker)
    {
        offsetMarker.localScale = new Vector3(this.transform.localScale.x/2, hitOffset * 2, 1);
    }

    public Vector3 getPlayerStartingPosition()
    {
        return startingPosition;
    }
}
