using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimasiButton : MonoBehaviour
{
    RectTransform rectTransform;

    bool start;
    float minX, maxX;
    float minY, maxY;

    public void PointerDown()
    {
        rectTransform = GetComponent<RectTransform>();

        if (!start)
        {
            start = true;

            minX = rectTransform.localScale.x;
            maxX = rectTransform.localScale.x * 1.15f;

            minY = rectTransform.localScale.y;
            maxY = rectTransform.localScale.y * 1.15f;
        }

        rectTransform.localScale = new Vector2(maxX, maxY);
    }
    public void PointerUp()
    {
        rectTransform.localScale = new Vector2(minX, minY);
    }
}
