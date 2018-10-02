using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ChangeTunnelVision : MonoBehaviour {

    [SerializeField]PostProcessingBehaviour post;


	// Use this for initialization
	void Start () {

        post.profile.vignette.enabled = false;		
	}
	
	// Update is called once per frame
	public void ChangeProfileAtRuntime () {

        post.profile.vignette.enabled = true;
		
	}
}
