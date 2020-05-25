using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public float spawnRadius;
    public Transform target;
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if ((Vector3.Distance(target.position, transform.position) > spawnRadius))
        {
            this.GetComponent<EnemySpawner>().enabled = false;
        }
        else {
            this.GetComponent<EnemySpawner>().enabled = true;
        }
    }
}
