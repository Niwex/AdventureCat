using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    [SerializeField]
    private VolumeHandler handler;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = handler.volume;
    }
}
