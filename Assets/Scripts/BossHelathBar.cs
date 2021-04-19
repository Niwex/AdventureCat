using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHelathBar : MonoBehaviour
{

    [SerializeField] BossAlotOfLegs boss;
    private Image image;
    float fillBarPercent;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        fillBarPercent = boss.currentHealth / boss.maxHealth;
        image.fillAmount = fillBarPercent;
    }
}
