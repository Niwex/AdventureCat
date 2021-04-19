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
       handler.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float volume)
    {
        
        this.volume = volume;
        
    }
}
