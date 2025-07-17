using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        ScoreManager scoreManager = other.gameObject.GetComponent<ScoreManager>();
        scoreManager.IncrementCoins();
        scoreManager.IncrementScore(10);

        Destroy(gameObject);
    }
}
