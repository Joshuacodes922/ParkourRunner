using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score = 0;

    private void Update()
    {
        Debug.Log("Score: "+score);
    }
    public void IncrementScore(int amount)
    {
        score += amount;
    }
}
