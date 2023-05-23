using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // for food
    private float topBound = 30;
    private float bottomBound = -10;
    private float leftBound = 25;
    private float rightBound = -25;

    public static int lives = 3;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // for projectile
        if(transform.position.z > topBound)
        {
            DetectCollisions.score--;
            Debug.Log("Score: " + DetectCollisions.score);
            Destroy(gameObject);
        }
        else if(transform.position.z < bottomBound)
        {
            MissedAnimal(gameObject);
        }
        else if (transform.position.x > leftBound)
        {
            MissedAnimal(gameObject);
        }
        else if (transform.position.x < rightBound)
        {
            MissedAnimal(gameObject);
        }
    }

    public static void MissedAnimal(GameObject gm)
    {
        lives--;
        if (lives <= 0)
        {
            Debug.Log("Game over!");
        }
        else
        {
            Debug.Log("Lives: " + lives);
        }
        Destroy(gm);
    }
}
