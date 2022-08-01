using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrutalEffect : DisplayCard
{
    public override void CardEffect(Deck cardDeck, EnemyController eC)
    {
        eC.enemyHealth -= 20;
        cardDeck.battleEnergy -= energyCost;
    }
}
