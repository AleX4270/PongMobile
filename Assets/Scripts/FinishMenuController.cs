using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenuController : MonoBehaviour
{
    public GameMaster gm;

    public void returnToMenu()
    {
        gm.loadMainMenu();
    }

    public void createNewGame()
    {
        gm.restartGame();
    }
}
