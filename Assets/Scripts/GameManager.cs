using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PillarsManager pillarsManager;
    private DataReader dataReader;

    [SerializeField]
    private GameObject Camera;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
