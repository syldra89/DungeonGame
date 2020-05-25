using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Create Enemy/Normal")]
public class SOEnemy : ScriptableObject
{
    //Stats
    public float enemyMaxHP;
    public string enemyName;
    public float enemyDamage;
    public float enemySpeed;

    //Drops
    public int minDrop;
    public int maxDrop;
}
