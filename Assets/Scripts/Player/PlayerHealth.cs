using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 100;
    public void decreaseHealth(int amount)
    {
        health-=amount;
    }

    public int getHealth()
    {
        return health;
    }

    
}
