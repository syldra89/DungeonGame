using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDropped : MonoBehaviour
{
    public int gold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            
            collision.GetComponent<PlayerMovement>().UpdateGold(gold);

            Destroy(this.gameObject);
        }
    }

    
}
