using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private static int score = 0;
    private void OnTriggerEnter(Collider other)
    {
        score++;
        Destroy(gameObject);
        Debug.Log("Score: " + score);
    }
}
