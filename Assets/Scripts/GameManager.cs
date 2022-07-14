using RockVR.Video;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PillarsManager pillarsManager;
    private DataReader dataReader;

    [SerializeField]
    private GameObject Camera;

    [SerializeField]
    private string FilePath;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void FinishStory()
    {

    }

    public void StartStory()
    {
        if (VideoCaptureCtrl.instance.status == VideoCaptureCtrl.StatusType.NOT_START)
        {
            string csvFilePath = @"D:\MasterStudium\Interactive Design\CSV Files\template1.txt";
            BuildPillars(csvFilePath);
            pillarsManager.HidePrefab();
            VideoCaptureCtrl.instance.StartCapture();
        }
        else if (VideoCaptureCtrl.instance.status == VideoCaptureCtrl.StatusType.STARTED)
        {
            VideoCaptureCtrl.instance.StopCapture();
        }
        else if (VideoCaptureCtrl.instance.status == VideoCaptureCtrl.StatusType.STOPPED)
        {
            // Waiting processing end.
        }
        else if (VideoCaptureCtrl.instance.status == VideoCaptureCtrl.StatusType.FINISH)
        {

        }

    }


    public void BuildPillars(string filename)
    {
        //assigning values
        pillarsManager = GetComponent<PillarsManager>();
        dataReader = DataReader.Instance;
        string csvFilePath = @"D:\MasterStudium\Interactive Design\CSV Files\template1.txt";
        dataReader.ReadFile(csvFilePath, '\t');


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

    }
}
