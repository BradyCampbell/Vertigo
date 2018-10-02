using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotat : MonoBehaviour {
    [SerializeField] float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Mouse Y") != 0)
            transform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * speed, Space.Self);
        else
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * speed, Space.Self);
    }
}
