using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableOrEnable : MonoBehaviour
{

    public void SwitchActive() 
    {
        Text text = gameObject.GetComponent<Text>();
        text.enabled = !text.enabled;
    }
}
