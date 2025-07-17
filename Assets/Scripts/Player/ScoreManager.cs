using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    int coinsPickedUp;

    [SerializeField] TMP_Text text;

    public void IncrementScore(int amount)
    {
        score += amount;
        text.SetText("Score:"+score.ToString());
    }

    public void IncrementCoins()
    {
        coinsPickedUp++;
    }
}
