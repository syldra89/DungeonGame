using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    private Rigidbody2D enemyRB;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;

    // Start is called before the first frame update
    void Start()
    {
        currentEnemyState = EnemyState.idle;
        enemyRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckRadius();
    }

    void CheckRadius() {
        if ((Vector3.Distance(target.position, transform.position) <= chaseRadius) && (Vector3.Distance(target.position, transform.position) > attackRadius))
        {
            if (currentEnemyState == EnemyState.idle || currentEnemyState == EnemyState.walk && currentEnemyState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime); //Vector que se mueve desde si mismo hasta el personaje a tal velocidad
                enemyRB.MovePosition(temp); //muevo el cuerpo rigido a ese vector
                ChangeState(EnemyState.walk);
            }
        }
        else {
            if(currentEnemyState != EnemyState.stagger)
            {
                ChangeState(EnemyState.idle);
            }
            
        }
    }

    private void ChangeState(EnemyState _newState) {
        if (currentEnemyState != _newState) {
            currentEnemyState = _newState;
        }
    }
}
