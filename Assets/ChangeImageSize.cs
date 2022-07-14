using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImageSize : MonoBehaviour
{

    public void ChangeHeight(string height)
    {
        float fHeight;
        if (float.TryParse(height,out fHeight))
        {
            ChangeHeight(fHeight);
        }
    }

    public void ChangeWidth(string width)
    {
        float fWidth;
        if (float.TryParse(width,out fWidth))
        {
            ChangeWidth(fWidth);
        }
    }

    public void ChangeHeight(float height)
    {
        RectTransform rt = gameObject.GetComponent<RectTransform>();
        Vector2 currentSize = rt.sizeDelta;

        rt.sizeDelta = new Vector2(currentSize.x, height);
    }

    public void ChangeWidth(float width)
    {
        RectTransform rt = gameObject.GetComponent<RectTransform>();
        Vector2 currentSize = rt.sizeDelta;

        rt.sizeDelta = new Vector2(width, currentSize.y);
    }
    
}
