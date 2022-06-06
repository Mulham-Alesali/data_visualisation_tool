using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float distanceBetweenPillars = 4;

    [SerializeField]
    private GameObject pillarsContainer;

    public static List<GameObject> pillarsList = new();

    private Vector3 scaleChange, positionChange;


    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(0f, 0.20f, 0f);

    }

    public void AddPillar(DataItem pillarData = null)
    {
        GameObject pillarObject = Instantiate(prefab, new Vector3(pillarsList.Count * distanceBetweenPillars, 0, 0), Quaternion.identity);
        pillarObject.transform.SetParent(pillarsContainer.transform);
        pillarsList.Add(pillarObject);

        if(pillarData != null)
        {
            PillarController pk = pillarObject.GetComponent<PillarController>();
            pk.Data = pillarData;
            pk.UpdateView();
            
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
