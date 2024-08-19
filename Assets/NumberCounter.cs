using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class NumberCounter : MonoBehaviour
{

    public TextMeshProUGUI numberText;
    public float animationTime = 1.5f;

    private float desiredNumber;
    private float initialNumber, currentNumber;

    public void SetNumber(float value)
    {
        initialNumber = currentNumber;
        desiredNumber = value;
    }

    public void AddToNumber(float value)
    {
        initialNumber = currentNumber;
        desiredNumber += value;
    }

    public void Update()
    {
        if(currentNumber != desiredNumber)
        {
            if(initialNumber < desiredNumber)
            {
                currentNumber += (animationTime * Time.deltaTime) * (desiredNumber - initialNumber);
                if(currentNumber >= desiredNumber )
                {
                    currentNumber = desiredNumber;
                }
            }
            else
            {
                currentNumber -= (animationTime * Time.deltaTime) * (initialNumber - desiredNumber);
                if(currentNumber <= desiredNumber)
                {
                    currentNumber = desiredNumber;
                }
            }
            numberText.text = currentNumber.ToString();
        }


    }
    //public TextMeshProUGUI Text;
    //public int countFPS = 30;
    //public float Duration = 1f;
    //public string numberFormat = "N0";
    //private int _value;

    //public int Value
    //{
    //    get
    //    {
    //        return _value;
    //    }
    //    set
    //    {
    //        UpdateText(value);
    //        _value = value;
    //    }
    //}
    //private Coroutine CountingCoroutine;
    //private void Awake()
    //{

    //}

    //private void UpdateText(int newValue)
    //{
    //    if(CountingCoroutine != null)
    //    {
    //        StopCoroutine(CountingCoroutine);
    //    }
    //    CountingCoroutine = StartCoroutine(CountText(newValue));
    //}

    //private IEnumerator CountText(int newValue)
    //{
    //    WaitForSeconds Wait = new WaitForSeconds(1f / countFPS);
    //    int previousValue = _value;
    //    int stepAmount;

    //    if(newValue - previousValue < 0)
    //    {
    //        stepAmount = Mathf.FloorToInt((newValue - previousValue) / (countFPS * Duration));
    //    }
    //    else
    //    {
    //        stepAmount = Mathf.CeilToInt((newValue - previousValue) / (countFPS * Duration));
    //    }

    //    if(previousValue < newValue)
    //    {
    //        while(previousValue < newValue)
    //        {
    //            previousValue += stepAmount;
    //            if(previousValue > newValue)
    //            {
    //                previousValue = newValue;
    //            }

    //            Text.SetText(previousValue.ToString(numberFormat));

    //            yield return Wait;
    //        }
    //    }
    //    else
    //    {
    //        while (previousValue > newValue)
    //        {
    //            previousValue += stepAmount;
    //            if (previousValue < newValue)
    //            {
    //                previousValue = newValue;
    //            }

    //            Text.SetText(previousValue.ToString(numberFormat));

    //            yield return Wait;
    //        }
    //    }
    //}
}
