using AnotherFileBrowser.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;

public class FileBrowserUpdate : MonoBehaviour
{
    [SerializeField]
    private Text _title;

    public void OpenFileBrowser()
    {
        var bp = new BrowserProperties();
        bp.filter = "Image files (*.csv) | *.csv";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            //Load image from local path with UWR
            ViewData(path);

        });
    }

    public void ViewData(string path)
    {
        _title.text = path;
        //buttonText.GetComponent<Text>().text = path;
        //buttonText.GetComponentInChildren(Text).text = path;
        Debug.Log(path);
    }
}
