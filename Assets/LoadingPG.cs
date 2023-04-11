using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadingPG : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image image;

    float time;
    void Update()
    {
        Invoke("Loading", 1);
    }

    void Loading()
    {

        if (time < 100)
        {
            time += Time.deltaTime * 42;
            text.text = time.ToString("F0") + "%";
            image.fillAmount = time / 100;
        }
        else
        {
            time = 100;
            text.text = time.ToString("F0") + "%";
            image.fillAmount = time / 100;
        }
    }
}
