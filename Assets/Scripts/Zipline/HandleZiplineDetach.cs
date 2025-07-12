using UnityEngine;

public class HandleZiplineDetach : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        Debug.Log("Player has exited the zipline");

        other.gameObject.GetComponent<Movement>().detachFromRope();
    }
}
