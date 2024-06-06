using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

// Define the ExtensionOfNativeClassAttribute with the correct access modifier
public class ExtensionOfNativeClassAttribute : Attribute
{
    // You can define properties or methods here if needed
}

[System.Serializable]
[ExtensionOfNativeClass]
public class Soru
{
    public string soru; // Soru metni
    public bool dogrumu; // Sorunun doğru cevabı
}

public class GameManager : MonoBehaviour // Make sure to inherit from MonoBehaviour
{
    public Soru[] sorular; // Soruların listesi
    public static List<Soru> cevaplanmamissorular; // Cevaplanmamış soruların listesi
    private Soru gecerlisoru; // Geçerli soru

    [SerializeField] private Text soruText; // Unity Editor üzerinden atama yapılacak
    [SerializeField] private GameObject bitisPanel; // Bitiş paneli

    ScoreManager scoreManager; // ScoreManager örneği

    void Start()
    {
        // ScoreManager'ı oluştur
        scoreManager = new ScoreManager();

        if (soruText == null)
        {
            Debug.LogError("soruText alanı atanmamış!");
            return;
        }

        if (sorular == null || sorular.Length == 0)
        {
            Debug.LogError("sorular dizisi boş!");
            return;
        }

        // Bitiş panelini başta inaktif yap
        if (bitisPanel != null)
        {
            bitisPanel.SetActive(false);
        }

        // Cevaplanmamış sorular listesi null ise, soruları listeye dönüştür
        if (cevaplanmamissorular == null)
        {
            cevaplanmamissorular = sorular.ToList();
        }

        RastgeleSoruSec();
        if (gecerlisoru != null)
        {
            Debug.Log("Şu anki soru: " + gecerlisoru.soru + " ve cevabı: " + gecerlisoru.dogrumu);
        }
        else
        {
            Debug.LogError("Geçerli soru atanamadı!");
        }
    }

    void RastgeleSoruSec()
    {
        if (cevaplanmamissorular.Count == 0)
        {
            Debug.LogError("Cevaplanmamış sorular listesi boş!");
            return;
        }

        int randomSoruIndex = UnityEngine.Random.Range(0, cevaplanmamissorular.Count); // Use UnityEngine.Random
        gecerlisoru = cevaplanmamissorular[randomSoruIndex];

        if (gecerlisoru != null)
        {
            soruText.text = gecerlisoru.soru;
        }
        else
        {
            Debug.LogError("Geçerli soru null!");
        }
    }

    public void dogruButonaBasildi()
    {
        if (gecerlisoru.dogrumu)
        {
            Debug.Log("doğru cevapladınız");
            scoreManager.AddScore(10); // Doğru cevap için 10 puan ekleyin
        }
        else
        {
            Debug.Log("yanlış cevapladınız");
            scoreManager.AddScore(-5); // Yanlış cevap için 5 puan çıkarın
        }
        LoadNextQuestion();
    }

    public void yanlisButonaBasildi()
    {
        if (!gecerlisoru.dogrumu)
        {
            Debug.Log("doğru cevapladınız");
            scoreManager.AddScore(10); // Doğru cevap için 10 puan ekleyin
        }
        else
        {
            Debug.Log("yanlış cevapladınız");
            scoreManager.AddScore(-5); // Yanlış cevap için 5 puan çıkarın
        }
        LoadNextQuestion();
    }

    public void LoadNextQuestion()
    {
        cevaplanmamissorular.Remove(gecerlisoru);
        if (cevaplanmamissorular.Count > 0)
        {
            RastgeleSoruSec();
        }
        else
        {
            Debug.Log("Tüm sorular cevaplandı!");
            SceneManager.LoadScene(3);
            ShowEndPanel();
        }
    }

    void ShowEndPanel()
    {
        if (bitisPanel != null)
        {
            bitisPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Bitiş paneli atanmamış!");
        }
    }
}
