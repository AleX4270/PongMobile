using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMaster : MonoBehaviour
{
    private int playerScore;
    private int aiScore;

    public TMP_Text playerScoreText;
    public TMP_Text aiScoreText;

    [Header("Ball")]
    public GameObject ball;

    [Header("Rackets")]
    public GameObject player;
    public GameObject computer;

    public AudioManager audioManager;

    //[Header("Goals")]
    //public GameObject playerGoal;
    //public GameObject aiGoal;

    

    public void playerAddPoint()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
        audioManager.PlaySound("pointGained");
        resetBall();
        defineBallDirection();
        Debug.Log(playerScore);
    }

    public void aiAddPoint()
    {
        aiScore++;
        aiScoreText.text = aiScore.ToString();
        audioManager.PlaySound("pointLost");
        resetBall();
        defineBallDirection();
        Debug.Log(aiScore);
    }

    private void resetBall()
    {
        ball.GetComponent<BallController>().resetBall();
    }

    private void defineBallDirection()
    {
        ball.GetComponent<BallController>().defineDirection();
    }

    private void resetPlayer()
    {
        player.transform.Translate(player.GetComponent<RacketMovement>().getPlayerStartingPosition());
    }

    private void resetAi()
    {
        computer.transform.Translate(computer.GetComponent<AIController>().getAiStartingPosition());
    }
}
