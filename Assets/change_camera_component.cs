using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_camera_component : MonoBehaviour
{
    GameObject cameraToFollow;


    // Start is called before the first frame update
    void Start()
    {
        cameraToFollow = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = cameraToFollow.transform.position;
        gameObject.transform.rotation = cameraToFollow.transform.rotation;
    }
}
