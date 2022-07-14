using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField]
    private List<Transform> transformsList;

    [SerializeField] private Vector3 offset = new(0,0.5f, -6);
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed = 0.5f;
    [SerializeField] private float rotationSpeed = 0.5f;


    public void ChangeCameraSpeed(float value)
    {
        translateSpeed = value;
        rotationSpeed = value;
    }


    private bool started = false;
    int targetIndex;  
    private bool paused;
    public void StartFollow(List<Transform> transformsList)
    {
        targetIndex = 0;
        paused = false; //true when on of the target has been reached
        started = true;
        this.transformsList = transformsList; 
        target = transformsList[targetIndex];

    }

    private void FixedUpdate()
    {
        if (!started) return;
        if (paused)
        {
            paused = false;
            targetIndex++;
            if(targetIndex > transformsList.Count)
            {
                started = false;
            }
            target = transformsList[targetIndex];
        }
        bool movementFinished = HandleTranslation();
        bool rotationhandeled = HandleRotation();
       
        
        paused = movementFinished && rotationhandeled;
        

    }

    private bool HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
        if(Vector3.Distance(targetPosition, transform.position) < 0.1)
        {
            return true;
        }
        return false;
    }
    private bool HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        if(Quaternion.Angle(transform.rotation, rotation) < 2)
        {
            return true;
        }
        return false;
    }
}
