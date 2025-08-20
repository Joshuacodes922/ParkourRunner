using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int health = 100;
    [SerializeField] private int initialHealth = 100;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject gameManager;
    [SerializeField] Image damageHealthUI;
    Animator damageUI;
    [SerializeField] RectTransform healthUISlider;
    HealthSlider healthSlider;
    public GameActionAudio gameActionAudio;
    bool isDead;
    private void Awake()
    {
        damageUI = damageHealthUI.GetComponent<Animator>();
        healthSlider = healthUISlider.GetComponent<HealthSlider>();
    }
    private void Start()
    {
        isDead = false;
        health = initialHealth;
        //text.SetText("Health:" + health.ToString());
        healthSlider.setMaxValue(health);
        if (damageHealthUI.GetComponent<Animator>())
        {
            Debug.Log("found");
        }
        //damageUI = damageHealthUI.GetComponent<Animator>();
    }

 

    public void decreaseHealth(int amount)
    {
        damageUI.Play("Health Damage Animation");
        if (isDead)
        {
            return;
        }
        health -=amount;
        healthSlider.decrementHealthSlider(health);
        //text.SetText("Health:" + health.ToString());

        if(health <= 0)
        {
            gameActionAudio.gameNotOver = false;
            gameManager.gameObject.GetComponent<GameOverhandling>().death();
            isDead = true;
        }
    }

    public int getHealth()
    {
        return health;
    }

    
}
