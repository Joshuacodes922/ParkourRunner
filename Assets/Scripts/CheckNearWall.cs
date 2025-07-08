using UnityEngine;

public class CheckNearWall : MonoBehaviour
{
    
    Movement movement;

    //private void Start()
    //{
    //    movement=player.GetComponent<Movement>();
    //    Debug.Log(player.gameObject.name);
    //}
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            movement = other.GetComponent<Movement>();
            Debug.Log("Enter Player" + movement.isNearWall);
            movement.checkNearWall(true);
            Debug.Log("Enter Player" + movement.isNearWall);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Exit trigger");
            movement.checkNearWall(false);
        }
    }
}
