using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public static StartScene instance;
    public enum NamaScene
    {
        kosong,
        MetaGame,
        Home,
        ConnectingTheDot,
        SpellingBee,
        PilihanGanda,
        BenarSalah,
    }
    public NamaScene namaScene;
    public OpeningTextMiniGame openingTextMiniGame;
    public GameObject scoreUI;

    public GameObject popUpAkhir;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (GameManager.instance.loadingScreenUI.activeInHierarchy)
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                GameManager.instance.loadingScreenUI.GetComponent<Animator>().SetTrigger("Exit");
                yield return new WaitForSeconds(1);
                GameManager.instance.loadingScreenUI.SetActive(false);
                GameManager.instance.cdPindahScene = false;
                print("Selesai pindah scene");
            }
        }





        if (namaScene == NamaScene.ConnectingTheDot)
        {
            openingTextMiniGame.gameObject.SetActive(true);
            openingTextMiniGame.TextOpening("Hubungkan Teks dan Gambarnya!!!", "CTD");

            //AnimasiManager.instance.AnimasiScreenCTD(true);

            //Audio BGM
            AudioManager.instance.BgmConnectTheDots();
        }
        else if (namaScene == NamaScene.SpellingBee)
        {
            openingTextMiniGame.gameObject.SetActive(true);
            openingTextMiniGame.TextOpening("Isi garis yang kosong dengan huruf sesuai gambar!!!", "SB");
        }
        else if (namaScene == NamaScene.PilihanGanda)
        {
            openingTextMiniGame.gameObject.SetActive(true);
            openingTextMiniGame.TextOpening("Pilih Jawaban Yang Benar!!!", "PG");
        }
        else if (namaScene == NamaScene.BenarSalah)
        {
            openingTextMiniGame.gameObject.SetActive(true);
            openingTextMiniGame.TextOpening("Pilih Jawaban Yang Benar!!!", "BS");
        }
        else if (namaScene == NamaScene.MetaGame)
        {
            AudioManager.instance.BgmMetaGame();
        }
        else if (namaScene == NamaScene.Home)
        {
            AudioManager.instance.BgmHome();
        }


        //-------------------------------------------------
        if (scoreUI != null) ButtonManager.instance.scoreUI = scoreUI;

        //-------------------------------------------------

        if (SaveManager.instance.GameSave.scoreBenarSalah >= 2 &&
            SaveManager.instance.GameSave.scoreConnectingTheDot >= 2 &&
            SaveManager.instance.GameSave.scorePilihanGanda >= 2 &&
            SaveManager.instance.GameSave.scoreSpellingBee >= 2 &&
            popUpAkhir != null)
        {
            popUpAkhir.SetActive(true);
            PlayerControllerMGPF.instance.clickUI = true;
        }

        //---------------------------------------------
        if (SaveManager.instance.PemilihanBabUI)
        {
            HomeManager.instance.HomeButton("PilihBab");
            SaveManager.instance.PemilihanBabUI = false;
        }

    }

    public void PemilihanBabUI()
    {
        GameManager.instance.PindahScene("Home");
        SaveManager.instance.PemilihanBabUI = true;
    }

    public void SceneMetagame()
    {
        GameManager.instance.PindahScene("MetaGame");

        AudioManager.instance.SfxClickBS();
    }

    public void RestartGame()
    {
        GameManager.instance.PindahScene(namaScene.ToString());

        AudioManager.instance.SfxClickBS();
    }

    public void SFXClick()
    {
        AudioManager.instance.SfxClickBS();
    }
}
