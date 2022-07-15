using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PillarController : MonoBehaviour
{

    public DataItem Data { get; set; }
    
    [SerializeField]
    GameObject titleObject;

    [SerializeField]
    GameObject textObject;

    [SerializeField]
    GameObject valueObject;

    [SerializeField]
    GameObject imageObject;

    public void UpdateView()
    {
        titleObject.GetComponent<Text>().text = Data.Name.Trim();
        valueObject.GetComponent<Text>().text = Data.Value + "";
        textObject.GetComponent<Text>().text = Data.Info.Trim();
        string imagePath = Path.GetDirectoryName(FileBrowserUpdate.ReadedFilePath);
        Debug.Log(imagePath + Data.ImagePath);
        ImageUpdater.UpdateTexture(imagePath + "\\" + Data.ImagePath, imageObject.GetComponent<RawImage>());
        //Debug.Log(Data.Value +"/" +  DataItem.minItemValue);

        Scale(float.Parse(Data.Value)/DataItem.minItemValue);
    }

    private void Scale(float factor)
    {
      Transform topPivot = gameObject.transform.Find("TopPivot");
       Transform bottomPivot = gameObject.transform.Find("BottomPivot");
       bottomPivot.localScale = new Vector3(1,2 * factor,1);
/*
*/
       topPivot.position = new Vector3(topPivot.position.x, 2 * factor, topPivot.position.z);

    }

    public void GetFocus(GameObject cameraObject)
    {

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
