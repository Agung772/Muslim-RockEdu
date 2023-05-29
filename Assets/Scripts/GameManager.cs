using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
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

    public static GameManager instance;
    public GameObject notifTextUI;
    public OpeningTextMiniGame openingTextMiniGame;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }



    }

    private void Start()
    {
        Application.targetFrameRate = 60;

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
    }

    public void NotifTextUI(string text)
    {
        notifTextUI.SetActive(true);
        notifTextUI.transform.GetChild(1).gameObject.GetComponent<Text>().text = text;
    }

    [SerializeField] GameObject loadingScreenUI;
    [SerializeField] Image loadingBar;
    public void PindahScene(string namaScene)
    {
        StartCoroutine(SceneCoroutine());
        IEnumerator SceneCoroutine()
        {
            print("PindahScene");
            loadingScreenUI.SetActive(true);
            loadingScreenUI.GetComponent<Animator>().SetTrigger("Start");

            loadingBar.fillAmount = 0;

            yield return new WaitForSeconds(2);

            var loadScene = SceneManager.LoadSceneAsync(namaScene);
            loadScene.allowSceneActivation = false;

            while (!loadScene.isDone)
            {
                float loading = loadScene.progress / 0.9f;
                loadingBar.fillAmount = loading;

                if (loading >= 1)
                {
                    yield return new WaitForSeconds(2);
                    loadScene.allowSceneActivation = true;
                    loadingScreenUI.GetComponent<Animator>().SetTrigger("Exit");
                    print("Selesai pindah scene");

                }
                yield return null;
            }
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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClickUI(bool click)
    {
        if (!click)
        {
            PlayerControllerMGPF.instance.clickUI = false;
        }
        else if (click)
        {
            PlayerControllerMGPF.instance.clickUI = true;
        }
    }


}
