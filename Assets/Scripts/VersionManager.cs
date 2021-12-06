using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VersionManager : MonoBehaviour
{
    [Header("Main Version")]
    public string year;
    public string month;
    public string build;

    [Header("Hotfixes")]
    public string hotfixCode;

    [Header("GameVersion Text")]
    public TMP_Text versionText;

    private void Start()
    {
        versionText.text = "v." + year + "." + month + "." + build + (hotfixCode == "0" ? "" : " Hotfix " + hotfixCode);
    }
}
