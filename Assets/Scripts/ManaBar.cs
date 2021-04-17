using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] CastSpells spells;
    Image image;
    float fillBarPercent;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        fillBarPercent = spells.currentMana / spells.maxMana;
        image.fillAmount = fillBarPercent;
    }
}
