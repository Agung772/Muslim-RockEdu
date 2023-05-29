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
        }
        else if (BS)
        {
            ButtonManager.instance.nextPertanyaanBS = GetComponent<Button>();
        }

    }
}
