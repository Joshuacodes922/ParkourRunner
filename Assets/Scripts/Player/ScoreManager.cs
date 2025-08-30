using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    int coinsPickedUp;

    [SerializeField] TMP_Text text;

    int health;

    [SerializeField] int pointsPerSecond = 2; // score increase per second
    float scoreAccumulator = 0f; // temporarily holds fractional score

    private void Awake()
    {
        health = GetComponent<PlayerHealth>().getHealth();
    }
    private void Update()
    {
        if (health <= 0) return;
        // Add the fractional part to accumulator
        scoreAccumulator += pointsPerSecond * Time.deltaTime;

        // Only convert to int when >= 1
        if (scoreAccumulator >= 1f)
        {
            int increment = Mathf.FloorToInt(scoreAccumulator);
            IncrementScore(increment);
            scoreAccumulator -= increment; // keep remaining fraction
        }
    }

    public void IncrementScore(int amount)
    {
        score += amount;
        text.SetText(score.ToString());

        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }

    public void IncrementCoins()
    {
        coinsPickedUp++;
    }
}
