using UnityEngine;

public class MoveTestLevel : MonoBehaviour
{
    public float speed = 15f;

    void Update()
    {
        // Move the object forward (along its local Z axis) at speed units per second
        transform.Translate(-Vector3.left * speed * Time.deltaTime);
    }
}
