using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagic : FiniteAttribute
{

    [Header("UI")]
    [SerializeField] private Slider magicSlider;

    [Header("Magic")]
    [SerializeField] private FloatValue myMagic;


    void Start()
    {
        magicSlider.maxValue = this.maxValue;
        this.currentValue = myMagic.value;
        UpdateMagic();
    }

    void UpdateMagic()
    {
        magicSlider.value = this.currentValue;
        myMagic.value = this.currentValue;
    }

    public void UseMagic(FloatValue MagicToModify)
    {
        this.Substract(MagicToModify.value);
        UpdateMagic();
    }

    public void ReceiveMagic(FloatValue MagicToModify)
    {
        this.Add(MagicToModify.value);
        UpdateMagic();
    }

    public void UseMagicPotion()
    {
        this.Add(5);
        UpdateMagic();
    }

}
