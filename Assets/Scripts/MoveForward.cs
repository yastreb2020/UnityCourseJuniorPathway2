using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform smth; // we won't need this actually
        if (this.TryGetComponent<RectTransform>(out smth))
        {
            speed = SpawnManager.animalSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
