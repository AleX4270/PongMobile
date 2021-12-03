using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fpsDisplayer : MonoBehaviour
{
    public TMP_Text fpsDisplay;
    // Start is called before the first frame update
    public void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //Application.targetFrameRate = 60;
        int fps = (int)(1 / Time.unscaledDeltaTime);
        fpsDisplay.text = fps.ToString();
    }
}
