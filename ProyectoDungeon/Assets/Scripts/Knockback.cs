using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();

            if (enemy != null)
            {
                enemy.GetComponent<Enemy>().currentEnemyState = EnemyState.stagger;
                
                //empuja al objeto en la direccion opuesta
                Vector3 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockPower;
                enemy.velocity = Vector3.zero; //le quito la velocidad al objeto antes de hacer los calculos
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockbackCo(enemy));
            }
        }
    }

    private IEnumerator KnockbackCo(Rigidbody2D _enemy) {
        if (_enemy != null) {
            yield return new WaitForSeconds(knockTime);
            _enemy.velocity = Vector3.zero;
            _enemy.GetComponent<Enemy>().currentEnemyState = EnemyState.idle;
        }
    }
}
