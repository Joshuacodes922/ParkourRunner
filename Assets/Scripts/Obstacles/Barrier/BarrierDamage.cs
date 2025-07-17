using UnityEngine;

public class BarrierDamage : MonoBehaviour
{
    [SerializeField] ObstacleDamageSO obstacleDamageSO;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        other.gameObject.GetComponent<PlayerHealth>().decreaseHealth(obstacleDamageSO.damage);
    }
}
