using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject feedBar;
    public GameObject[] animalPrefabs;
    private float spawnZ = 20;
    private float spawnRangeX = 10;

    private float spawnX = 20;
    private float spawnRangeStartZ = 7;
    private float spawnRangeEndZ = 15;

    private float spawnInterval = 1.5f;
    private float spawnDelay = 2;

    public static float animalSpeed;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int increment)
    {
        score += increment;
    }

    void SpawnRandomAnimal()
    {
        // random animal type
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        // random side to appear
        int side = Random.Range(0, 3);
        if (side == 0) //from top
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnZ);
            Quaternion spawnrot = animalPrefabs[animalIndex].transform.rotation;
            Instantiate(animalPrefabs[animalIndex], spawnPos, spawnrot);
            animalSpeed = animalPrefabs[animalIndex].GetComponent<MoveForward>().speed;
            Canvas.Instantiate(feedBar, spawnPos, spawnrot);
        }
        else if (side == 1) // from left
        {
            Vector3 spawnPos = new Vector3(-spawnX, 0, Random.Range(spawnRangeStartZ, spawnRangeEndZ));
            Quaternion spawnrot = Quaternion.Euler(
                animalPrefabs[animalIndex].transform.rotation.x,
                90,
                animalPrefabs[animalIndex].transform.rotation.z);
            Instantiate(animalPrefabs[animalIndex], spawnPos, spawnrot);
            animalSpeed = animalPrefabs[animalIndex].GetComponent<MoveForward>().speed;
            Canvas.Instantiate(feedBar, spawnPos, spawnrot);
        }
        else // from right
        {
            Vector3 spawnPos = new Vector3(spawnX, 0, Random.Range(spawnRangeStartZ, spawnRangeEndZ));
            Quaternion spawnrot = Quaternion.Euler(
                animalPrefabs[animalIndex].transform.rotation.x,
                -90,
                animalPrefabs[animalIndex].transform.rotation.z);
            Instantiate(animalPrefabs[animalIndex], spawnPos, spawnrot);
            animalSpeed = animalPrefabs[animalIndex].GetComponent<MoveForward>().speed;
            Canvas.Instantiate(feedBar, spawnPos, spawnrot);
        }
    }
}
