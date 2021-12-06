using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fpsDisplayer : MonoBehaviour
{
    public TMP_Text fpsDisplay;

    // Update is called once per frame
    void Update()
    {
        //Application.targetFrameRate = 60;
        int fps = (int)(1 / Time.unscaledDeltaTime);
        fpsDisplay.text = fps.ToString();
    }
}
