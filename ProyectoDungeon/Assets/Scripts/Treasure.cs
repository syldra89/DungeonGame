using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{

    public SOTreasure soTreasure;
    public int minDrop;
    public int maxDrop;

    private void Awake()
    {
        minDrop = soTreasure.minDrop;
        maxDrop = soTreasure.maxDrop;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
