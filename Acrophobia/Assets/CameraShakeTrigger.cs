using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraShakeTrigger : MonoBehaviour
{
    
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            CameraShaker.Instance.ShakeOnce(5f, 1f, 60f, 30f);
            
        }
        

        
    }
}   