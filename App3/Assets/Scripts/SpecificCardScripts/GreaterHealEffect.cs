using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreaterHealEffect : DisplayCard
{
    public override void CardEffect(Deck cardDeck)
    {
        cardDeck.playerHealth += 12;
        cardDeck.battleEnergy -= energyCost;
    }
    public override bool NeedEnemy(){return false;}
}
