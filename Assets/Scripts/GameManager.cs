using RockVR.Video;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;
public class GameManager : MonoBehaviour
{
    private PillarsManager pillarsManager;
    private DataReader dataReader;

    [SerializeField]
    private GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ExitGame()
    {
        UnityEngine.Application.Quit();
    }

    public void FinishStory()
    {
        pillarsManager.Reset();
        Camera.GetComponent<CameraMove>().Reset();
    }

    public void StartStory()
    {

        if (!System.IO.File.Exists(OpenFilePath))
        {
            MessageBox.Show("Please select a valide file to process!","error");
            return;
        }


        GameObject.Find("Start").GetComponent<DisableOrEnable>().SwitchActive();
        GameObject.Find("Finish").GetComponent<DisableOrEnable>().SwitchActive();

        Debug.Log("The Status: " + VideoCaptureCtrl.instance.status);
        if (VideoCaptureCtrl.instance.status 
            == VideoCaptureCtrl.StatusType.NOT_START || VideoCaptureCtrl.instance.status == VideoCaptureCtrl.StatusType.FINISH)
        {
           // string csvFilePath = @"D:\MasterStudium\Interactive Design\CSV Files\template1.txt";
            BuildPillars(OpenFilePath);
            pillarsManager.HidePrefab();
            VideoCaptureCtrl.instance.StartCapture();
        }
        else if (VideoCaptureCtrl.instance.status == VideoCaptureCtrl.StatusType.STARTED)
        {
            VideoCaptureCtrl.instance.StopCapture();
            Debug.Log("status: " + VideoCaptureCtrl.instance.status);
            FinishStory();


        }
        else if (VideoCaptureCtrl.instance.status == VideoCaptureCtrl.StatusType.STOPPED)
        {
            // Waiting processing end.
        }

    }

    public static string OpenFilePath { get; set; }
    public void BuildPillars(string filename)
    {
        //assigning values
        pillarsManager = GetComponent<PillarsManager>();
        dataReader = DataReader.Instance;
        //string csvFilePath = @"D:\MasterStudium\Interactive Design\CSV Files\template1.txt";
        dataReader.ReadFile(OpenFilePath, '\t');


        dataReader.Data.ForEach((el) =>
        {
            pillarsManager.AddPillar(el);
        });

        List<Transform> pillarsTransformList = new();

        PillarsManager.pillarsList.ForEach(el =>
        {
            pillarsTransformList.Add(el.transform.Find("TopPivot").transform);
        });

        Camera.GetComponent<CameraMove>().StartFollow(pillarsTransformList);
    }

    public void DistroyPillars()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if(VideoCaptureCtrl.instance.status == VideoCaptureCtrl.StatusType.FINISH)
        {
            VideoCaptureCtrl.instance.Reset();
        }
    }
}
