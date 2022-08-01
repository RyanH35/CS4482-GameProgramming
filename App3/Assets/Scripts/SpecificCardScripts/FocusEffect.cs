using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusEffect : DisplayCard
{
    public override void CardEffect(Deck cardDeck)
    {
        cardDeck.battleEnergy += 1;
    }
    public override bool NeedEnemy(){return false;}
}
