using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayOfFrostEffect : DisplayCard
{
    public override void CardEffect(Deck cardDeck, EnemyController eC)
    {
        //change functional attack component
        eC.enemyData.attack = 0;
        //change visual attack component
        eC.enemyAttack = 0;
        cardDeck.battleEnergy -= energyCost;
    }

}
