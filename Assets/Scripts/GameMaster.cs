using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private int playerScore;
    private int aiScore;
    public int finishScore;

    private Vector2 ballVelocity;

    [Header("Player and AI Scripts")]
    public RacketMovement player;
    public AIController computer;
    public RacketMovement secondPlayer;

    [Header("Rigidbodies")]
    public Rigidbody2D AiRig;
    public Rigidbody2D ball;

    [Header("Gameobjects and Managers")]
    public GameObject finishMenu;
    public GameObject pauseMenu;
    public AudioManager audioManager;

    [Header("UI Elements")]
    public Button pauseBtn;
    public TMP_Text playerScoreText;
    public TMP_Text aiScoreText;
    public TMP_Text winnerName;

    public void pauseGame()
    {
        ballVelocity = ball.velocity;
        pauseMenu.SetActive(true);
        player.freezePlayer(true);
        AiRig.constraints = RigidbodyConstraints2D.FreezeAll;
        ball.constraints = RigidbodyConstraints2D.FreezeAll;
        pauseBtn.interactable = false;
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        player.freezePlayer(false);
        AiRig.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        ball.constraints = RigidbodyConstraints2D.FreezeRotation;
        ball.velocity = ballVelocity;
        pauseBtn.interactable = true;
    }

    public void restartGame()
    {
        finishMenu.SetActive(false);
        playerScore = 0;
        aiScore = 0;
        playerScoreText.text = playerScore.ToString();
        aiScoreText.text = aiScore.ToString();

        resetBall();
        resetPlayer();
        player.freezePlayer(false);
        resetAi();
        AiRig.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        defineBallDirection();

        Debug.Log("Rozpoczyna siê nowa gra!");
    }

    public void finishGame(string winner)
    {
        finishMenu.SetActive(true);
        if(winner == "Komputer" && secondPlayer != null)
        {
            winnerName.text = "Wygra³ " + "Gracz 2";
        }
        else if(winner ==  "Komputer" && secondPlayer == null)
        {
            winnerName.text = "Wygra³ " + "Komputer";
        }
        else
        {
            winnerName.text = "Wygra³ " + winner;
        }

        ball.velocity = Vector2.zero;

        player.freezePlayer(true);
        AiRig.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void playerAddPoint()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
        audioManager.PlaySound("pointGained");

        if (playerScore == finishScore)
        {
            finishGame("Gracz 1");
        }
        else
        {
            resetBall();
            defineBallDirection();
        }
    }

    public void aiAddPoint()
    {
        aiScore++;
        aiScoreText.text = aiScore.ToString();
        if (computer == null)
        {
            audioManager.PlaySound("pointGained");
        }
        else if (computer != null)
        {
            audioManager.PlaySound("pointLost");
        }

        if (aiScore == finishScore)
        {
            finishGame("Komputer");
        }
        else
        {
            resetBall();
            defineBallDirection();
        } 
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
        player.gameObject.transform.localPosition = player.getPlayerStartingPosition().localPosition;
    }

    private void resetAi()
    {
        if(computer != null)
        {
            computer.gameObject.transform.localPosition = computer.getAiStartingPosition().localPosition;
        }
        else if(secondPlayer != null)
        {
            secondPlayer.gameObject.transform.localPosition = secondPlayer.getPlayerStartingPosition().localPosition;
        }
    }
}
