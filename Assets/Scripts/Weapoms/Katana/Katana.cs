using UnityEngine;

public class Katana : MonoBehaviour
{
    [SerializeField] public WeaponSO weaponSO;
    [SerializeField] public GameObject katana;

    Collider collider;


    Animator animator;

    private void Start()
    {
        animator = katana.gameObject.GetComponent<Animator>();
        collider = katana.GetComponent<Collider>();
        collider.enabled = false;

    }

    public void setCollider(bool value)
    {
        collider.enabled = value;
    }
    

    public void Slash()
    {
        //Code to slash
        animator.SetTrigger("Swing Katana");
        collider.enabled = true;
        Debug.Log("Slash has been called");
    }
}
