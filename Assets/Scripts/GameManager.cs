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

    [SerializeField] GameObject loadingScreenUI;
    [SerializeField] Image loadingBar;

    bool cdPindahScene;
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

                yield return new WaitForSeconds(2);

                var loadScene = SceneManager.LoadSceneAsync(namaScene);
                loadScene.allowSceneActivation = false;


                while (!loadScene.isDone)
                {
                    float loading = loadScene.progress / 0.9f;
                    loadingBar.fillAmount = loading;

                    if (loading >= 1)
                    {
                        loadScene.allowSceneActivation = true;
                        yield return new WaitForSeconds(1);
                        loadingScreenUI.GetComponent<Animator>().SetTrigger("Exit");
                        yield return new WaitForSeconds(1);
                        loadingScreenUI.SetActive(false);
                        cdPindahScene = false;
                        print("Selesai pindah scene");

                    }
                    yield return null;
                }
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
