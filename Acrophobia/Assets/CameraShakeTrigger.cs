using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class CameraShakeTrigger : MonoBehaviour
{

    [SerializeField] PostProcessingBehaviour post;
    [SerializeField] Material[] skyboxes;
    [SerializeField] AudioClip cheer, ringing;

    AudioSource say;

    int sky = 0;


    // Use this for initialization
    void Start()
    {
        say = gameObject.AddComponent<AudioSource>();
        post.profile.vignette.enabled = false;
    }

    // Update is called once per frame
    public void VignetteMe()
    {

        post.profile.vignette.enabled = true;

    }

    public void Shake()
    {
        CameraShaker.Instance.ShakeOnce(5f, 1f, 60f, 30f);
    }

    public void IncrementSkybox()
    {
        sky++;
        RenderSettings.skybox = skyboxes[sky%skyboxes.Length];
    }

    public void Restort()
    {
        SceneManager.LoadScene(0);
    }

    public void Cheer()
    {
        say.PlayOneShot(cheer);
    }

    public void EarRing()
    {
        say.PlayOneShot(ringing);
    }
}   