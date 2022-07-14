using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMaterial : MonoBehaviour
{

    [SerializeField]
    Material[] materials = new Material[7];


    public void ChangeTiling()
    {
        gameObject.GetComponent<Renderer>().material.mainTextureScale = new Vector2(10, 10);
    }
    public void ChangeMaterial(int materialIndex)
    {
        Debug.Log("Material Index: " + materialIndex);
        if(materialIndex < materials.Length)
        {
            gameObject.GetComponent<Renderer>().material = materials[materialIndex];
           
        }
        else
        {
            Debug.LogError("Material Index outrange the materials array");
        }
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
