using UnityEngine;

public class Katana : MonoBehaviour
{
    [SerializeField] public WeaponSO weaponSO;
    [SerializeField] public GameObject katana;
    Animator animator;

    private void Start()
    {
        animator = katana.gameObject.GetComponent<Animator>();
    }

    public void Slash()
    {
        //Code to slash
        animator.Play("KatanaSwing");
        Debug.Log("Slash has been called");
    }
}
