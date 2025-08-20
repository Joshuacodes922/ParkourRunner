using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    private void Start()
    {
        arrow.gameObject.SetActive(false);
    }

    private void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
       arrow.gameObject.SetActive(true);
    }
}
