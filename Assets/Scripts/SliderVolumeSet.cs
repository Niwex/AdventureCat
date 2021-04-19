using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderVolumeSet : MonoBehaviour
{
    [SerializeField]
    VolumeHandler handler;
    //AudioSource audioSource;
    float volume = 0.1f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        handler.volume = volume;
    }

    public void SetVolume(float volume)
    {
        
        this.volume = volume;
        
    }
}
