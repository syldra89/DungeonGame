using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{

    public float knockPower;
    public float knockTime;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();

            if (hit != null)
            {
                //empuja al objeto en la direccion opuesta
                Vector3 difference = hit.transform.position - transform.position;
                difference = difference.normalized * knockPower;
                hit.AddForce(difference, ForceMode2D.Impulse);

                if (collision.gameObject.CompareTag("Enemy"))
                {
                    hit.GetComponent<Enemy>().currentEnemyState = EnemyState.stagger;
                    collision.GetComponent<Enemy>().KnockBack(hit, knockTime);
                }
                if (collision.gameObject.CompareTag("Player"))
                {
                    Debug.Log("asdasd");
                    hit.GetComponent<PlayerMovement>().playerCurrentState = PlayerState.stagger;
                    collision.GetComponent<PlayerMovement>().KnockBack(knockTime);
                }

            }
        }
    }
}
