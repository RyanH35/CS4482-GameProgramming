using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : DisplayCard
{
    public override void CardEffect(Deck cardDeck)
    {
        cardDeck.playerHealth += 5;
        cardDeck.battleEnergy -= energyCost;
    }
    public override bool NeedEnemy(){return false;}
}
