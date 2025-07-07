using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProcedurallevelGeneration : MonoBehaviour
{
    [SerializeField] GameObject chunk;
    [SerializeField] Transform chunkParent;
    [SerializeField] int speed=10;
    List<GameObject> chunks = new List<GameObject>();

    int xOffset = 40;
    int zOffest = 15;

    int incrementer;

    private void Start()
    {
        SpawnChunks();
    }

    private void Update()
    {
        move();
        DestroyAndCreate();
    }

    private void SpawnChunks()
    {
        incrementer = 0;
        for (int i = 0; i < 10; i++)
        {
            GameObject chunk1 = Instantiate(chunk, transform.position + new Vector3(incrementer, 0, 0), Quaternion.identity, chunkParent);
            incrementer += xOffset;
            chunks.Add(chunk1);
        }
    }

    public void move()
    {
        foreach (var i in chunks)
        {
            i.transform.Translate(-transform.right * speed * Time.deltaTime);

        }
    }

    public void DestroyAndCreate()
    {
        if (chunks[0].transform.position.x < Camera.main.transform.position.x - 40)
        {
            GameObject firstChunk = chunks[0];

            chunks.RemoveAt(0);
            firstChunk.transform.position = chunks[chunks.Count-1].transform.position+new Vector3(xOffset,0,0);
            chunks.Add(firstChunk);
        }
    }

    
}
