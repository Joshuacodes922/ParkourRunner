using UnityEngine;

public class Instantiatetrigger : MonoBehaviour
{
    [SerializeField] GameObject spikeObstacle;
    [SerializeField] float forwardOffset = 6f; // Distance in front of the object
    [SerializeField] Transform spikeObstacleParent;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Vector3 spawnPosition = other.transform.position + other.transform.forward * forwardOffset;
        Instantiate(spikeObstacle, spawnPosition, Quaternion.identity,spikeObstacleParent);
    }
}
