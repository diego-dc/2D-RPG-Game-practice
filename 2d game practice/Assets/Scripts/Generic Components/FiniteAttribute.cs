using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteAttribute : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] public float maxValue;
    [SerializeField] public float currentValue;

    public void SetAmount(float amount)
    {
        currentValue = amount;
    }
    public virtual void Substract(float substractThis)
    {
        currentValue -= substractThis;
        if(currentValue <= 0)
        {
            currentValue = 0;
        }
    }

    public virtual void Add(float addThis)
    {
        currentValue += addThis;
        if(currentValue > maxValue)
        {
            currentValue = maxValue;
        }
    }

    public virtual void LoseEverything()
    {
        currentValue = 0;
    }

    public virtual void getFull()
    {
        currentValue = maxValue;
    }
}