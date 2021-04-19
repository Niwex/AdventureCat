using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField] CharacterControl player;
    private Image image;
    float fillBarPercent;
    void Start()
    {
        image = GetComponent<Image>();        
    }

    // Update is called once per frame
    void Update()
    {
        fillBarPercent = player.getHealth / player.maxHealth;
        image.fillAmount = fillBarPercent;
    }
}
