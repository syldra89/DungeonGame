using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentEnemyState;
    public GameObject goldDropped;
    //SObjects
    public SOEnemy soEnemy;
    public float enemyMaxHP;
    public string enemyName;
    public float enemyDamage;
    public float enemySpeed;
    public int minDrop;
    public int maxDrop;
    public int finalGold;
    //Variables
    public float currentHP;

    // Pongo awake para que me cargue todos los valores
    private void Awake()
    {
        enemyMaxHP = soEnemy.enemyMaxHP;
        enemyName = soEnemy.enemyName;
        enemyDamage = soEnemy.enemyDamage;
        enemySpeed = soEnemy.enemySpeed;
        //Drops
        minDrop = soEnemy.minDrop;
        maxDrop = soEnemy.maxDrop;
        finalGold = Random.Range(minDrop, maxDrop);

        currentHP = enemyMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KnockBack(Rigidbody2D _enemy, float _knockTime) {
        StartCoroutine(KnockbackCo(_enemy, _knockTime));
    }

    public void TakeDamage(float _playerDamage, float _knockTime)
    {
        StartCoroutine(TakeDamageCo(_playerDamage, _knockTime));
    }
    //Coroutines
    private IEnumerator KnockbackCo(Rigidbody2D _enemy, float _knockTime)
    {
        if (_enemy != null)
        {
            yield return new WaitForSeconds(_knockTime);
            _enemy.velocity = Vector3.zero;
            _enemy.GetComponent<Enemy>().currentEnemyState = EnemyState.idle;
            _enemy.velocity = Vector3.zero;
        }
    }
    private IEnumerator TakeDamageCo(float _playerDamage, float _knockTime)
    {
        currentHP -= _playerDamage;
        if (currentHP <= 0)
        {
            GameObject coins = Instantiate(goldDropped, transform.position, Quaternion.identity) as GameObject;
            coins.GetComponent<ItemDropped>().gold = finalGold;
            Destroy(this.gameObject);
        }
        yield return new WaitForSeconds(_knockTime);
    }
}
