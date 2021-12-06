using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenuController : MonoBehaviour
{
    public GameMaster gm;
    public LevelController lc;

    public void returnToMenu()
    {
        lc.loadMainMenu();
    }

    public void createNewGame()
    {
        gm.restartGame();
    }
}
