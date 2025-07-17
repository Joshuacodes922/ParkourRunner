using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProcedurallevelGeneration : MonoBehaviour
{
    [SerializeField] GameObject chunk;
    [SerializeField] GameObject zipline;
    [SerializeField] Transform chunkParent;
    [SerializeField] float speed=10;
    List<GameObject> chunks = new List<GameObject>();
    int numberOfChunks = 0;
    [SerializeField] int chunksBeforeZipline = 10;

    int levelsCounter = 0;
    

    [SerializeField] GameObject player;


    int xOffset = 40;
    int zOffest = 25;

    int incrementer;

    private void Start()
    {
        SpawnChunks();
    }

    private void Update()
    {
        
        IncrementSpeed();
        move();
        DestroyAndCreate();
    }

    private void SpawnChunks()
    {
        incrementer = 0;
        for (int i = 0; i < chunksBeforeZipline; i++)
        {
            GameObject chunk1 = Instantiate(chunk, transform.position + new Vector3(incrementer, 0, 0), Quaternion.identity, chunkParent);
            incrementer += xOffset;
            numberOfChunks++;
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

    public void IncrementSpeed()
    {
        if (player.gameObject.GetComponent<Movement>().getJumpedOnZipline())
        {
            speed *= player.gameObject.GetComponent<Movement>().speedMultiplier;
            player.gameObject.GetComponent<Movement>().animationMultiplier *= player.gameObject.GetComponent<Movement>().speedMultiplier;
        }
    }

    public void DestroyAndCreate()
    {
        int chunkDestructionDistance = 40;
        

        if (chunks[0].GetComponent<Zipline>())
        {
            chunkDestructionDistance *= 5;
        }

        if (chunks[0].transform.position.x < Camera.main.transform.position.x - chunkDestructionDistance)
        {
            float offsetToUse = xOffset;
            GameObject firstChunk = chunks[0];
            chunks.RemoveAt(0);
            numberOfChunks++;

            if (numberOfChunks >= chunksBeforeZipline)
            {
                GameObject destroyedChunk = firstChunk;
                firstChunk = Instantiate(zipline, Vector3.zero, Quaternion.identity, chunkParent);
                numberOfChunks = 0;
                offsetToUse = xOffset / 2;
                Destroy(destroyedChunk);
            }

            Zipline zipline1 = chunks[chunks.Count - 1].GetComponent<Zipline>();

            if (zipline1)
            {
                firstChunk.transform.position = zipline1.endMarker.transform.position + new Vector3(xOffset / 2f, 0, 0);
                chunks.Add(firstChunk);
                return;
            }

            firstChunk.transform.position = chunks[chunks.Count - 1].transform.position + new Vector3(offsetToUse, 0, 0);
            chunks.Add(firstChunk);
        }
    }




}
