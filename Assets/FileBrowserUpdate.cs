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
    private Text inputFilePath;
    
    [SerializeField]
    private Text outputFolderPath;

    public static string ReadedFilePath { get; set; }



    public void OpenFileBrowser()
    {
        var bp = new BrowserProperties();
        bp.filter = "Image files (*.tsv) | *.tsv";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            GameManager.OpenFilePath = path;
            //Load image from local path with UWR
            ViewFilePath(path);
        });

    }
    public void OpenFolderBrowser()
    {
        var bp = new BrowserProperties();
        bp.filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
        bp.filterIndex = 0;
        new FileBrowser().OpenFolderBrowser(bp, path =>
        {
        string directory = path;
        ViewFolderPath(directory);
        });
    }


    public void ViewFilePath(string path)
    {
        inputFilePath.text = path;
        ReadedFilePath = path;
        //Debug.Log(path);
    }
    public void ViewFolderPath(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        outputFolderPath.text = path;
        
        RockVR.Video.PathConfig.SaveFolder = path + "\\";
        Debug.Log(path);
    }



}
