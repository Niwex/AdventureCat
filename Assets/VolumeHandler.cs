using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="VolumeHandler")]
public class VolumeHandler : ScriptableObject
{
    public float volume;
    void OnEnable()
    {
        volume = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
