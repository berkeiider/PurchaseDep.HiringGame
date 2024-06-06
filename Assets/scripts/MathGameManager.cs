using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MathGameManager : MonoBehaviour
{
    int soruAdeti;

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
    public Button submitButton; // Submit butonu

    void Start()
    {
        submitButton.onClick.AddListener(CheckAnswer); // Submit butonuna event listener ekle
        GenerateNewQuestion(); // İlk soruyu oluştur
    }

    void GenerateNewQuestion()
    {
        soruAdeti++;
        if (soruAdeti < 6)
        {
            firstValue = Random.Range(lowFirstValue, highFirstValue);
            SecondValue = Random.Range(lowSecondValue, highSecondValue);
            var i = Random.Range(1, 4);

            isAdd = isSub = isMulti = isDiv = false; // Tüm işlemleri sıfırla

            if (i == 1)
            {
                finalValue = firstValue + SecondValue;
                Debug.Log("Adding");
                isAdd = true;
            }
            else if (i == 2)
            {
                finalValue = firstValue - SecondValue;
                Debug.Log("Subtracting");
                isSub = true;
            }
            else if (i == 3)
            {
                finalValue = firstValue * SecondValue;
                Debug.Log("Multiplying");
                isMulti = true;
            }

            UpdateGameText();
        }
        else
        {
            SceneManager.LoadScene(2);
        }

    }

    void UpdateGameText()
    {
        if (isAdd)
        {
            gameTxt.text = firstValue + " + " + SecondValue.ToString();
        }
        else if (isSub)
        {
            gameTxt.text = firstValue + " - " + SecondValue.ToString();
        }
        else if (isMulti)
        {
            gameTxt.text = firstValue + " * " + SecondValue.ToString();
        }
    }

    public void CheckAnswer()
    {
        string input = answerInputField.text;
        int answerValue;
        int.TryParse(input, out answerValue);

        if (answerValue == finalValue)
        {
            Debug.Log("Correct!");
            ScoreManager.instance.AddScore(10); // Skor artırma
        }
        else
        {
            Debug.Log("Incorrect! " + answerValue);
            ScoreManager.instance.AddScore(-5); // Yanlış cevap için puan düşürme
        }

        answerInputField.text = ""; // Giriş alanını temizle
        GenerateNewQuestion(); // Yeni bir soru oluştur
    }

    // Sahne geçiş fonksiyonu
    public void LoadSoruScene()
    {
        SceneManager.LoadScene("Soru");
    }
}
