using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public GameObject restartUI, quitUI, optionUI;
    bool restart, quit;

    public Slider sliderBgm;
    public Slider sliderSfx;

    public TMP_Dropdown grafikDropdown;
    private void Start()
    {
        RefrensBgm(sliderBgm);
        RefrensSfx(sliderSfx);

        grafikDropdown.value = QualitySettings.GetQualityLevel();
    }
    public void RestartUI()
    {
        restartUI.SetActive(true);
        optionUI.SetActive(false);
        restart = true;

        AudioManager.instance.SfxClickBS();
    }
    public void QuitUI()
    {
        quitUI.SetActive(true);
        optionUI.SetActive(false);
        quit = true;

        AudioManager.instance.SfxClickBS();
    }
    public void No()
    {
        if(restart == true)
        {
            restartUI.SetActive(false);
            optionUI.SetActive(true);
            restart = false;

            AudioManager.instance.SfxClickBS();
        }
        if(quit == true)
        {
            quitUI.SetActive(false);
            optionUI.SetActive(true);
            quit = false;

            AudioManager.instance.SfxClickBS();
        }

    }


    public void VolumeValueBgm(float value)
    {
        if (gameObject.activeInHierarchy)
        {
            AudioManager.instance.VolumeValueBgm(value);
        }

    }
    public void RefrensBgm(Slider slider)
    {
        AudioManager.instance.RefrensBgm(slider);
    }
    public void VolumeValueSfx(float value)
    {
        if (gameObject.activeInHierarchy)
        {
            AudioManager.instance.VolumeValueSfx(value);
        }

    }
    public void RefrensSfx(Slider slider)
    {
        AudioManager.instance.RefrensSfx(slider);
    }
    public void SetGrafik(int value)
    {
        QualitySettings.SetQualityLevel(value);
    }
    public void BgmTester() { if (gameObject.activeInHierarchy) AudioManager.instance.BgmTester(); }
    public void SfxTester() { if (gameObject.activeInHierarchy) AudioManager.instance.SfxTester(); }

}
