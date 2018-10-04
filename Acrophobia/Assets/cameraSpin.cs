//Press O to start spinning, press I to stop spinning

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSpin : MonoBehaviour
{
    [SerializeField] float spinSpeed;
    [SerializeField] float spinRange;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera spinCamera;
    [SerializeField] private GameObject spinCenter;
    [SerializeField] private GameObject spinTarget;

    private float focusDistance;
    private float lerpSpinTime;
    private float spinReachCount;
    private float startTime;
    private float speed;
    private float returnDistance;
    private bool spinReach;  //If spinTarget reaches the position for spinning
    private bool spinReady;  //If spinTarget starts to move up
    private bool spinStart;  //If spinCamera starts to move
    private bool stopSpin;  //Start to recenter the camera and stop spinning
    private bool spinning;  //If spinning
    private Vector3 stopSpinFrom;  //The position of spinTarget when spinning starts to stop

    // Use this for initialization
    void Start()
    {
        focusDistance = 30f;
        lerpSpinTime = 1f;
        spinReach = false;
        spinReady = false;
        spinStart = false;
        stopSpin = false;
        spinning = false;
        spinReachCount = 0;
        speed = spinRange / 2;

        mainCamera.depth = 1;
        spinCamera.depth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spinCenter.transform.position = mainCamera.transform.position + mainCamera.transform.forward * focusDistance;
        //spinTarget.transform.position = spinCenter.transform.position + mainCamera.transform.up * spinRange;
        //spinCenter.transform.Rotate(-Vector3.forward * Time.deltaTime * spinSpeed);
        //spinTarget.transform.position = spinCenter.transform.position;

        if (Input.GetKey(KeyCode.O))  //Start the spin
        {
            startTime = Time.time;
            spinReady = true;
            spinStart = true;
        }
        if (!spinReach && spinReady)  //Get the spinTarget ready for spin in 1 second
        {
            spinTarget.transform.localPosition = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, spinRange, 0), (Time.time - startTime) * speed / spinRange);
            spinReachCount += Time.deltaTime;
            if (spinReachCount >= 1)
            {
                spinReach = true;
                spinReady = false;
                spinning = true;
                spinReachCount = 0;
            }
        }

        if (spinStart)  //If spin starts, switch camera
        {
            mainCamera.depth = 0;
            spinCamera.depth = 1;
            spinCamera.transform.LookAt(spinTarget.transform);
        }

        if (spinReach && spinning)  //Reach the position and start to camera-spin
        {
            spinning = true;
            spinTarget.transform.RotateAround(spinCenter.transform.position, mainCamera.transform.forward, Time.deltaTime * spinSpeed);
        }

        if (Input.GetKey(KeyCode.I) && spinReach)  //Start to stop the spin
        {
            startTime = Time.time;
            stopSpin = true;
            spinning = false;
            stopSpinFrom = spinTarget.transform.localPosition;
            returnDistance = Vector3.Distance(stopSpinFrom, new Vector3(0, 0, 0));
        }

        if (stopSpin)
        {
            spinTarget.transform.localPosition = Vector3.Lerp(stopSpinFrom, new Vector3(0, 0, 0), (Time.time - startTime) * speed / returnDistance);
            spinReachCount += Time.deltaTime;
            if (spinReachCount >= 1)
            {
                stopSpin = false;
                spinReach = false;
                spinStart = false;
                spinCamera.depth = 0;
                mainCamera.depth = 1;
                spinReachCount = 0;
            }
        }
    }
}