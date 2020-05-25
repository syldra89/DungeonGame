using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBat : Treasure
{
    public GameObject goldDropped;

    public int finalGold;

    private void Awake()
    {
        minDrop = soTreasure.minDrop;
        maxDrop = soTreasure.maxDrop;
        finalGold = Random.Range(minDrop, maxDrop);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(finalGold);
    }

    public void KillObject()
    {

        Instantiate(goldDropped, transform.position, Quaternion.identity);
        Debug.Log(finalGold);
        Destroy(this.gameObject);
    }
}
