using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColorPicker : MonoBehaviour
{
    public GameObject colorpick;
    public GameObject disButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void whenbuttonClicked()
    {
        if (colorpick.activeInHierarchy == true)
        {
            colorpick.SetActive(false);
            //RectTransform rt = disButton.GetComponent<RectTransform>();
            //rt.sizeDelta = new Vector2(100, 100);

            disButton.SetActive(true);
        }
        else
        {
            colorpick.SetActive(true);
            //disButton.SetActive(false);
        }
    }

}
