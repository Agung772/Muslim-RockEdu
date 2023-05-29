using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
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

    }
}
