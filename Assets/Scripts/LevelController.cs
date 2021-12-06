using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public AudioManager am;

    public void loadFirstGame()
    {
        am.PlaySound("btnClick");
        StartCoroutine(loadScene("MainGameplay"));
    }

    public void loadSecondGame()
    {
        am.PlaySound("btnClick");
        StartCoroutine(loadScene("SecondGameplay"));
    }

    public void loadMainMenu()
    {
        am.PlaySound("btnClick");
        StartCoroutine(loadScene("MainMenu"));
    }

    IEnumerator loadScene(string sceneName)
    {
        yield return new WaitForSecondsRealtime(0.1f);
        SceneManager.LoadScene(sceneName);
    }

    public void quitGame()
    {
        am.PlaySound("btnClick");
        Application.Quit();
    }
}
