using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : DisplayCard
{
    public override void CardEffect(Deck cardDeck, EnemyController eC)
    {
        eC.enemyHealth -= 6;
        cardDeck.battleEnergy -= energyCost;
    }
}
