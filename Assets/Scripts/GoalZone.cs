using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoalZone : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallController ball = collision.gameObject.GetComponent<BallController>();

        if(ball != null)
        {
            BaseEventData data = new BaseEventData(EventSystem.current);
            this.scoreTrigger.Invoke(data);
        }
    }
}
