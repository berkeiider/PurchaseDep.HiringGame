using UnityEngine;
using UnityEngine.UI; // UI bileşenlerine erişim için

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score;
    public Text scoreText; // Eski UI Text referansı

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score);
        UpdateScoreText();
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
