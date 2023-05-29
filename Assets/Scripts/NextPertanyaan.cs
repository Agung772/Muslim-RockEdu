using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPertanyaan : MonoBehaviour
{
    public bool PG, BS;
    private void Start()
    {
        if (PG)
        {
            ButtonManager.instance.nextPertanyaanPG = GetComponent<Button>();
            GetComponent<Button>().onClick.AddListener(ButtonManager.instance.NextPertanyaanPilihanGanda);
        }
        else if (BS)
        {
            ButtonManager.instance.nextPertanyaanBS = GetComponent<Button>();
            GetComponent<Button>().onClick.AddListener(ButtonManager.instance.NextPertanyaanBenarSalah);
        }

    }
}
