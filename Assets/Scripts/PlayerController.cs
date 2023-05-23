using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 20f;
    public float xRange = 20f;
    public float zRangeUp = 20f;
    public float zRangeDown = -5f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lives: 0");
        Debug.Log("Score: 0");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.z > zRangeUp)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeUp);
        if (transform.position.z < zRangeDown)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeDown);
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            // launch projectile
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "animal")
        {
            DestroyOutOfBounds.MissedAnimal(other.gameObject);
        }
    }
}
