using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject FishPrefab;

    public int numFish = 100;
    public float width = 8f;
    public float minY = 0.2f;
    public float maxY = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        // miny and maxy are the maximum distance the next block can be placed up!!
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < Mathf.Ceil(0.25f * numFish); i++)
        {
            spawnPosition.y += Random.Range(minY, 0.8f * maxY);
            spawnPosition.x = Random.Range(-width, width);
            Instantiate(FishPrefab, spawnPosition, Quaternion.identity);
        }

        for (int i = 0; i < Mathf.Ceil(0.25f * numFish); i++)
        {
            spawnPosition.y += Random.Range(minY, 1.5f * maxY);
            spawnPosition.x = Random.Range(-width, width);
            Instantiate(FishPrefab, spawnPosition, Quaternion.identity);
        }

        for (int i = 0; i < Mathf.Ceil(0.25f * numFish); i++)
        {
            spawnPosition.y += Random.Range(minY, 2.7f * maxY);
            spawnPosition.x = Random.Range(-width, width);
            Instantiate(FishPrefab, spawnPosition, Quaternion.identity);
        }
        //for (int i = 0; i < Mathf.Ceil(0.25f * numFish); i++)
        //{
        //    spawnPosition.y += Random.Range(minY, 2.7f * maxY);
        //    spawnPosition.x = Random.Range(-width, width);
        //    Instantiate(FishPrefab, spawnPosition, Quaternion.identity);
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
