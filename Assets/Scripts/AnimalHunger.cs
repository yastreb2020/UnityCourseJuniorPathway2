using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    public Slider hungerslider;
    [SerializeField] private int amountToBeFed;

    private int currentFedAmount = 0;
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        hungerslider.maxValue = amountToBeFed;
        hungerslider.value = 0;
        hungerslider.fillRect.gameObject.SetActive(false);

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FeedAnimal(int amount)
    {
        currentFedAmount += amount;
        hungerslider.fillRect.gameObject.SetActive(true);
        hungerslider.value = currentFedAmount;

        if(currentFedAmount >= amountToBeFed)
        {
            spawnManager.AddScore(amountToBeFed);
            Destroy(gameObject, 0.1f);
        }
    }
}
