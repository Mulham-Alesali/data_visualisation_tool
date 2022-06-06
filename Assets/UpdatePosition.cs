using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePosition : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

        parent = gameObject.transform.parent.gameObject;
    }
    public float FixeScale = 2;
    public GameObject parent;
    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(FixeScale / parent.transform.localScale.x, FixeScale / parent.transform.localScale.y, FixeScale / parent.transform.localScale.z);

    
    }
}
