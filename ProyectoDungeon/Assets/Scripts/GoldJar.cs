using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldJar : Treasure
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
        
    }

    public void KillObject() {
        GameObject coins = Instantiate(goldDropped, transform.position, Quaternion.identity) as GameObject;
        coins.GetComponent<ItemDropped>().gold = finalGold;
        
        Destroy(this.gameObject);
    }

}
