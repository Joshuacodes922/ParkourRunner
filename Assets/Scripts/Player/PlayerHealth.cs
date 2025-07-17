using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerHealth : MonoBehaviour
{
    private int health = 100;
    [SerializeField] private int initialHealth = 100;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject gameManager;
    bool isDead;

    private void Start()
    {
        isDead = false;
        health = initialHealth;
        text.SetText("Health:" + health.ToString());
    }

   
    public void decreaseHealth(int amount)
    {
        if (isDead)
        {
            return;
        }
        health -=amount;
        text.SetText("Health:" + health.ToString());

        if(health <= 0)
        {
            gameManager.gameObject.GetComponent<GameOverhandling>().death();
            isDead = true;
        }
    }

    public int getHealth()
    {
        return health;
    }

    
}
