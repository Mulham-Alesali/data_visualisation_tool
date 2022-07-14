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
    private Text inputFilePath;
    
    [SerializeField]
    private Text outputFolderPath;





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
        ViewFolderPath(directory);
    }


    public void ViewFilePath(string path)
    {
        inputFilePath.text = path;
        //Debug.Log(path);
    }
    public void ViewFolderPath(string path)
    {
        outputFolderPath.text = path;
        //Debug.Log(path);
    }



}
