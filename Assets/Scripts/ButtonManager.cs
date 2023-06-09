using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    public GameObject scoreUI;

    public GameObject settingHomeUI;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        if (nextPertanyaanPG != null) nextPertanyaanPG.interactable = false;
        if (nextPertanyaanBS != null) nextPertanyaanBS.interactable = false;



        //--------------------------------------------------
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();

        }
    }
    public void SettingUI(bool active)
    {
        if (active) settingHomeUI.SetActive(true);
        else if (!active) settingHomeUI.SetActive(false);

    }



    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PindahScene(string namaScene)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(namaScene);
        }
    }
    public void PindahSceneDelay(string namaScene, float delay)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(namaScene);
        }
    }

    public void SpawnScoreUI(int jumlahBintang)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(1);
            scoreUI.SetActive(true);
            scoreUI.GetComponent<ScoreUI>().CallScoreUI(jumlahBintang);
        }

    }



    public Button nextPertanyaanPG;
    public bool nextPertanyaanPilihanGanda;
    public void NextPertanyaanPilihanGanda()
    {
        if (nextPertanyaanPilihanGanda)
        {
            nextPertanyaanPilihanGanda = false;
            nextPertanyaanPG.interactable = false;
            GameplayPilihanGanda.instance.NextPertanyaan(3);

            AudioManager.instance.SfxClickPG();
        }

    }
    public Button nextPertanyaanBS;
    public bool nextPertanyaanBenarSalah;
    public void NextPertanyaanBenarSalah()
    {
        if (nextPertanyaanBenarSalah)
        {
            //if (BenarSalah.instance.condition == "Benar")
            //{
            //    GameplayBenarSalah.instance.benar++;
            //}
            //else
            //{
            //    GameplayBenarSalah.instance.salah++;
            //}

            nextPertanyaanBenarSalah = false;
            nextPertanyaanBS.interactable = false;
            GameplayBenarSalah.instance.NextPertanyaan(3);

            AudioManager.instance.SfxClickPG();
        }

    }
}
