using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public SOEnemy soEnemy;
    public float enemyDamage;
    public float knockPower;
    public float knockTime;

    public float attackSpeed;
    public float attackSpeedCountdown;

    private void Awake()
    {
        enemyDamage = soEnemy.enemyDamage;
        attackSpeed = 1f;
        attackSpeedCountdown = 0;
    }

    private void Update()
    {
        if (attackSpeedCountdown > 0) {
            attackSpeedCountdown -= Time.deltaTime;
        }
        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerHitBox"))
        {
            Rigidbody2D hit = collision.GetComponentInParent<Rigidbody2D>();

            if (hit != null)
            {
                //empuja al objeto en la direccion opuesta
                Vector3 difference = hit.transform.position - transform.position;
                difference = difference.normalized * knockPower;
                hit.AddForce(difference, ForceMode2D.Impulse);
            }
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerHitBox"))
        {
            Rigidbody2D hit = collision.GetComponentInParent<Rigidbody2D>();

            if ((hit != null) && attackSpeedCountdown <= 0)
            {
                
                if (collision.gameObject.CompareTag("PlayerHitBox") && collision.isTrigger)
                {
                    if (collision.GetComponentInParent<PlayerMovement>().playerCurrentState != PlayerState.stagger)
                    {
                        hit.GetComponentInParent<PlayerMovement>().playerCurrentState = PlayerState.stagger;
                        collision.GetComponentInParent<PlayerMovement>().KnockBack(knockTime);
                        collision.GetComponentInParent<PlayerMovement>().TakeDamage(enemyDamage);
                        attackSpeedCountdown = attackSpeed;
                    }

                }

            }
        }
    }
}
