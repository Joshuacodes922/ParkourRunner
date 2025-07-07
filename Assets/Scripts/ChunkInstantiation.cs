using UnityEngine;

public class ChunkInstantiation : MonoBehaviour
{
    [SerializeField] GameObject level;

    void createChunk()
    {
        Instantiate(level);
    }
}
