using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float timer = 0;
    private bool canSpawnDog = false;
    private float betweenSpawnTime = 1;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > betweenSpawnTime) canSpawnDog = true;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canSpawnDog)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            canSpawnDog = false;
            timer = 0;
        }
    }
    IEnumerator SpawnDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        yield return new WaitForSeconds(10.0f);
    }
}
