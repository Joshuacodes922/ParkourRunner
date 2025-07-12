using UnityEngine;

public class ChunkScoreHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        other.GetComponent<ScoreManager>().IncrementScore(100);
    }
}
