using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadingScreen : MonoBehaviour
{
    public Vector2 posisiAwal;
    public Vector2 posisiAkhir;
    public Vector2 jarakPosisi;
    public RectTransform roket;

    public TextMeshProUGUI textLoading;
    bool cd;

    [Range(0f, 1f)]
    public float value;
}
