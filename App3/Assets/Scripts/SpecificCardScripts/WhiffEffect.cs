using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiffEffect : DisplayCard
{
    public override void CardEffect(Deck cardDeck)
    {
        cardDeck.battleEnergy -= energyCost;
    }
    public override bool NeedEnemy(){return false;}
}
