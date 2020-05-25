using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject goldJar;
    public int randomNumber;

    private void Start()
    {
        randomNumber = Random.Range(1, 10);

        if (randomNumber > 5) {
            Instantiate(goldJar, transform.position, Quaternion.identity);
        }
    }
    
}
