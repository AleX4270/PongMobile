using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    [Header("FPS Amount")]
    public int fps;
    public bool defaultFps;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        if (defaultFps)
        {
            Application.targetFrameRate = -1;
        }
        else
        {
            Application.targetFrameRate = (fps < 15 || fps > 60 ? 60 : fps);
        }
    }
}
