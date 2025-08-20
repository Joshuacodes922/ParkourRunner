using UnityEngine;

public class KatanaHolder : MonoBehaviour
{
    [SerializeField] public GameObject katana;

    public void disableCollider()
    {
        katana.GetComponent<Katana>().setCollider(false);
    }
}
