using TMPro;
using UnityEngine;

public class GetHighScore : MonoBehaviour
{
    TMP_Text highscore;

    private void Awake()
    {
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        highscore = GetComponent<TMP_Text>();
        highscore.SetText(savedHighScore.ToString());
    }
}
