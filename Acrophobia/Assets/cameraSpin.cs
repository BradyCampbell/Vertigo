using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSpin : MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera spinCamera;
    [SerializeField] private GameObject spinCenter;
    [SerializeField] private GameObject spinTarget;
    

    // Use this for initialization
    void Start () {
        mainCamera.depth = 1;
        spinCamera.depth = 0;
	}

    // Update is called once per frame
    void Update()
    {
        //Testing code for camera moving left and right
        //float mouseX = Input.GetAxis("Mouse X") * 5f;        
        //mainCamera.transform.localRotation = Quaternion.Euler(0, mouseX, 0) * transform.localRotation;

        //Press P to start spining
        if(Input.GetKey(KeyCode.P))
        {
            spinCamera.transform.LookAt(spinTarget.transform);
            spinTarget.transform.RotateAround(spinCenter.transform.position, mainCamera.transform.forward, Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            mainCamera.depth = 0;
            spinCamera.depth = 1;            
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            mainCamera.depth = 1;
            spinCamera.depth = 0;
        }
    }
}
