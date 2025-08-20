using UnityEngine;

public class FollowRigNoRotation : MonoBehaviour
{
    public Transform rig;       // Your rig/root object
    public Vector3 offset;      // Offset from the rig

    void LateUpdate()
    {
        if (rig != null)
        {
            transform.position = rig.position + offset;
            // Don't touch transform.rotation keeps camera's own rotation
        }
    }
}
