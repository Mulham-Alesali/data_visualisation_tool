using AnotherFileBrowser.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class FileBrowserUpdate : MonoBehaviour
{
    [SerializeField]
    private Text filePath;
    [SerializeField]
    private Text folderPath;


    public void OpenFileBrowser()
    {
        var bp = new BrowserProperties();
        bp.filter = "Image files (*.tsv) | *.tsv";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            //Load image from local path with UWR
            ViewFilePath(path);

        });
    }
    public void OpenFolderBrowser()
    {
        string directory = EditorUtility.OpenFolderPanel("Select Directory", "", "");
        //Load image from local path with UWR
        ViewFolderPath(directory);
    }


    public void ViewFilePath(string path)
    {
        filePath.text = path;
        //Debug.Log(path);
    }
    public void ViewFolderPath(string path)
    {
        folderPath.text = path;
        //Debug.Log(path);
    }



}
