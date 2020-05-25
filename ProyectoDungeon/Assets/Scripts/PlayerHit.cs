using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float knockPower;
    public float knockTime;

    public SOPlayer soPlayer;
    public float playerDamage;
    public float playerSpeed;

    private void Awake()
    {
        playerDamage = soPlayer.playerDamage;
    }
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
        
        if (collision.gameObject.CompareTag("Breakable")) {
            collision.GetComponent<GoldJar>().KillObject();
        }
        if (collision.gameObject.CompareTag("EnemyHitBox"))
        {

            Rigidbody2D hit = collision.GetComponentInParent<Rigidbody2D>();

            if (hit != null)
            {
                //empuja al objeto en la direccion opuesta
                Vector3 difference = hit.transform.position - transform.position;
                difference = difference.normalized * knockPower;
                hit.AddForce(difference, ForceMode2D.Impulse);

                if (collision.gameObject.CompareTag("EnemyHitBox") && collision.isTrigger) {
                    hit.GetComponentInParent<Enemy>().currentEnemyState = EnemyState.stagger;
                    collision.GetComponentInParent<Enemy>().KnockBack(hit,knockTime);
                    collision.GetComponentInParent<Enemy>().TakeDamage(playerDamage, knockTime);
                }
                

            }
        }
    }

    
}
