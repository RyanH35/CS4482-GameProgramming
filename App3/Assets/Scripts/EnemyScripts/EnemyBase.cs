using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : ScriptableObject
{
    public string enemyName; 
    public int health = 25;
    public int attack = 1;
    public int maxAttack = 1;
    public abstract void TakeTurn();
}
