using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject notifTextUI;


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
    }

    public void NotifTextUI(string text)
    {
        notifTextUI.SetActive(true);
        notifTextUI.transform.GetChild(1).gameObject.GetComponent<Text>().text = text;
    }

    public GameObject loadingScreenUI;
    [SerializeField] Image loadingBar;
    [SerializeField] LoadingScreen loadingScreen;

    public bool cdPindahScene;
    public void PindahScene(string namaScene)
    {
        if (!cdPindahScene)
        {
            cdPindahScene = true;

            StartCoroutine(SceneCoroutine());
            IEnumerator SceneCoroutine()
            {
                print("PindahScene");
                loadingScreenUI.SetActive(true);
                loadingScreenUI.GetComponent<Animator>().SetTrigger("Start");

                loadingBar.fillAmount = 0;
                loadingScreen.value = 0;
                LoadingScreen();

                yield return new WaitForSeconds(2);

                var loadScene = SceneManager.LoadSceneAsync(namaScene);
                loadScene.allowSceneActivation = false;


                while (!loadScene.isDone)
                {
                    float loading = loadScene.progress / 0.9f;
                    loadingBar.fillAmount = loading;

                    loadingScreen.value = loading;
                    LoadingScreen();


                    if (loading >= 1)
                    {
                        loadScene.allowSceneActivation = true;
                    }
                    yield return null;
                }
            }
        }

    }
    bool cd;
    void LoadingScreen()
    {
        loadingScreen.jarakPosisi = loadingScreen.posisiAkhir - loadingScreen.posisiAwal;
        loadingScreen.roket.localPosition = loadingScreen.posisiAwal + loadingScreen.jarakPosisi * loadingScreen.value;

        if (!cd)
        {
            cd = true;

            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(0.5f);
                loadingScreen.textLoading.text = "Memuat Roket.";
                yield return new WaitForSeconds(0.5f);
                loadingScreen.textLoading.text = "Memuat Roket..";
                yield return new WaitForSeconds(0.5f);
                loadingScreen.textLoading.text = "Memuat Roket...";
                cd = false;

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
