using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenFishGenerator : MonoBehaviour
{
    public GameObject BadFishPrefab;

    public int numFish = 100;
    public float width = 8f;
    public float minY = 0.2f;
    public float maxY = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < Mathf.Ceil(0.33f * numFish); i++)
        {
            spawnPosition.y += Random.Range(minY, 10 * maxY);
            spawnPosition.x = Random.Range(-width, width);
            Instantiate(BadFishPrefab, spawnPosition, Quaternion.identity);
        }

        for (int i = 0; i < Mathf.Ceil(0.33f * numFish); i++)
        {
            spawnPosition.y += Random.Range(minY, 3 * maxY);
            spawnPosition.x = Random.Range(-width, width);
            Instantiate(BadFishPrefab, spawnPosition, Quaternion.identity);
        }

        for (int i = 0; i < Mathf.Ceil(0.33f * numFish); i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-width, width);
            Instantiate(BadFishPrefab, spawnPosition, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
