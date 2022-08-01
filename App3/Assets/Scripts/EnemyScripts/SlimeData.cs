using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Slime", menuName = "New Slime")]
public class SlimeData : EnemyBase
{
    public override void TakeTurn()
    {
        makeAttack();
    }
    private void makeAttack()
    {
        Deck cardDeck = GameObject.Find("Card Deck").GetComponent<Deck>();
        cardDeck.playerHealth -= attack;
        attack = maxAttack;
    }
}
