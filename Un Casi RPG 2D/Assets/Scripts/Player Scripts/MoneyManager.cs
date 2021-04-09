using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : FiniteAttribute
{

    [Header("UI references")]
    public TextMeshProUGUI coinDisplay;

    [Header("MoneyCounter")]

    [SerializeField] private FloatValue myMoneyCounter;

    void Start()
    {
        this.currentValue = myMoneyCounter.value;
        UpdateCoinCount();
    }

    public void UpdateCoinCount()
    {
        coinDisplay.text = "" + this.currentValue;
        myMoneyCounter.value = this.currentValue;
    }

    public void AddMoney(FloatValue MoneyToAdd)
    {
        this.Add(MoneyToAdd.value);
        UpdateCoinCount();
    }

    public void SubstractMoney(FloatValue MoneyToSubstract)
    {
        this.Substract(MoneyToSubstract.value);
        UpdateCoinCount();
    }
    public bool CanAfford(int price)
    {
        return (this.currentValue >= price);
    }
}
