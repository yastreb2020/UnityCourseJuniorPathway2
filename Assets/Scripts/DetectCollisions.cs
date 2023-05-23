using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // when the projectile hits the target
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "animal")
        {
            score++;
            Debug.Log("Score: " + score);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
