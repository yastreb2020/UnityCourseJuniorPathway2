using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float spawnIntervalStart = 1.0f;
    private float spawnIntervalEnd = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomBall());
    }

    // Spawn random ball at random x position at top of play area
    IEnumerator SpawnRandomBall ()
    {
        while(true)
        {
            // Generate random ball index and random spawn position
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
            GameObject randomBall = ballPrefabs[Random.Range(0, ballPrefabs.Length)];

            // instantiate ball at random spawn location
            Instantiate(randomBall, spawnPos, randomBall.transform.rotation);

            yield return new WaitForSeconds(Random.Range(spawnIntervalStart, spawnIntervalEnd));
        }
    }

}
