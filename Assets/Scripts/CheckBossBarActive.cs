using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBossBarActive : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] BossAlotOfLegs boss;
    [SerializeField] Image image;
    [SerializeField] Image childrenImage;
    void Start()
    {
        player = FindObjectOfType<CharacterControl>().GetComponent<Transform>();
        image = GetComponent<Image>();
        
        boss = FindObjectOfType<BossAlotOfLegs>();
        image.enabled = false;
        childrenImage.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, boss.transform.position) <= boss.followRadius)
        {
            image.enabled = true;
            childrenImage.enabled = true;
        }
        //Debug.Log(Vector3.Distance(player.position, boss.transform.position) + "   " + boss.followRadius);
    }
}
