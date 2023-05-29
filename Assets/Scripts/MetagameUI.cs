using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MetagameUI : MonoBehaviour
{
    public TextMeshProUGUI namaPlayer;
    public TextMeshProUGUI kelas;
    public TextMeshProUGUI bab;

    public GameObject
        cowokUI,
        cewekUI;
    public GameObject
        DU,
        RK,
        RM,
        RP;
    private void Start()
    {
        namaPlayer.text = SaveManager.instance.GameSave.namaPlayer;
        kelas.text = SaveManager.instance.GameSave.kelas;
        bab.text = "Bab : " + SaveManager.instance.GameSave.bab;

        if (SaveManager.instance.GameSave.karakter == "Cowok")
        {
            cowokUI.SetActive(true);
            cewekUI.SetActive(false);
        }
        else
        {
            cowokUI.SetActive(false);
            cewekUI.SetActive(true);
        }

        //------------------------
        var GS = SaveManager.instance.GameSave;

        int scoreCTD = GS.scoreConnectingTheDot;
        int scoreSB = GS.scoreSpellingBee;
        int scorePG = GS.scorePilihanGanda;
        int scoreBS = GS.scoreBenarSalah;

        if (scoreCTD >= 2)
        {
            RM.gameObject.SetActive(false);
        }
        if (scorePG >= 2)
        {
            RK.gameObject.SetActive(false);
        }
        if (scoreBS >= 2)
        {
            RP.gameObject.SetActive(false);
        }
        if (scoreSB >= 2)
        {
            DU.gameObject.SetActive(false);
        }
    }

    public void UIClick(bool value)
    {
        PlayerControllerMGPF.instance.clickUI = value;
    }
}
