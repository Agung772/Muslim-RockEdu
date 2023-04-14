using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMetagame : MonoBehaviour
{
    public GameObject popUpAkhirUI;
    private void Start()
    {
        int cTD = PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScoreConnectingTheDot + SaveManager.instance.GameSave.bab + SaveManager.instance.GameSave.codeSave);
        int sB = PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScoreSpellingBee + SaveManager.instance.GameSave.bab + SaveManager.instance.GameSave.codeSave);
        int pG = PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScorePilihanGanda + SaveManager.instance.GameSave.bab + SaveManager.instance.GameSave.codeSave);
        int bS = PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScoreBenarSalah + SaveManager.instance.GameSave.bab + SaveManager.instance.GameSave.codeSave);

        int totalBintang = cTD + sB + pG + bS;

        if (totalBintang == 12)
        {
            popUpAkhirUI.SetActive(true);
            PlayerControllerMGPF.instance.clickUI = true;
        }
    }
}
