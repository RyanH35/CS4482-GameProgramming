using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersevereEffect : DisplayCard
{
    public override void CardEffect(Deck cardDeck)
    {
        cardDeck.playerHealth += 3;
        cardDeck.battleEnergy -= energyCost;
    }
    public override bool NeedEnemy(){return false;}
}
