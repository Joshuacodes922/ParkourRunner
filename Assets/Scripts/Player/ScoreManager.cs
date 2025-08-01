using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    
    int coinsPickedUp;

    [SerializeField] TMP_Text text;
    [SerializeField] TMP_Text highscore;

    private void Start()
    {
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        highscore.SetText("High Score: " + savedHighScore.ToString());
    }

    private void Update()
    {
        
    }
    public void IncrementScore(int amount)
    {
        score += amount;
        text.SetText("Score:"+score.ToString());
        if(score> PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscore.SetText("HighScore: "+score.ToString());
        }
       
    }

    public void IncrementCoins()
    {
        coinsPickedUp++;
    }
}
