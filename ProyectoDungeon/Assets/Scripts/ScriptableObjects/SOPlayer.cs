using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "Create Hero/Player")]
public class SOPlayer : ScriptableObject
{
    //Stats
    public float playerMaxHP;
    public float playerDamage;
    public float playerSpeed;
    public int playerGold;
}
