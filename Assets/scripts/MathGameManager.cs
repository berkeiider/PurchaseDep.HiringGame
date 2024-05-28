using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathGameManager : MonoBehaviour
{
    //first value
    private int lowFirstValue = 0;
    private int highFirstValue = 10;
    public int firstValue;
    //second value
    private int lowSecondValue = 0;
    private int highSecondValue = 10;
    public int SecondValue;
    public Text gameTxt;
    public int finalValue;
    private bool isAdd = false;
    private bool isSub = false;
    private bool isMulti = false;
    private bool isDiv = false;

    public InputField answerInputField; // Referansını alacağımız InputField

    void Start()
    {
        firstValue = Random.Range(lowFirstValue, highFirstValue);
        SecondValue = Random.Range(lowSecondValue, highSecondValue);
        var i = Random.Range(1, 5);

        if (i == 1)
        {
            finalValue = firstValue + SecondValue;
            Debug.Log("Adding");
            isAdd = true;
        }
        if (i == 2)
        {
            finalValue = firstValue - SecondValue;
            Debug.Log("Subtracting");
            isSub = true;
        }
        if (i == 3)
        {
            finalValue = firstValue * SecondValue;
            Debug.Log("Multiplying");
            isMulti = true;
        }
        if (i == 4)
        {
            // Check for division by zero
            if (SecondValue != 0)
            {
                finalValue = firstValue / SecondValue;
                Debug.Log("Dividing");
                isDiv = true;
            }
            else
            {
                // If division by zero, default to addition
                finalValue = firstValue + SecondValue;
                Debug.Log("Adding (Division by zero handled)");
                isAdd = true;
            }
        }
    }

    void Update()
    {
        Debug.Log("Value = " + finalValue);
        if (isAdd == true)
        {
            gameTxt.text = firstValue + " + " + SecondValue.ToString();
        }
        if (isSub == true)
        {
            gameTxt.text = firstValue + " - " + SecondValue.ToString();
        }
        if (isMulti == true)
        {
            gameTxt.text = firstValue + " * " + SecondValue.ToString();
        }
        if (isDiv == true)
        {
            gameTxt.text = firstValue + " / " + SecondValue.ToString();
        }
    }

    public void CheckAnswer()
    {
        string input = answerInputField.text; // InputField'den değeri al
        int answerValue;
        int.TryParse(input, out answerValue);
        if (answerValue == finalValue)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Incorrect! " + answerValue);
        }
    }
}
