using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotOfGreedEffect : DisplayCard
{
    public override void CardEffect(Deck cardDeck)
    {
        Fight fight = GameObject.Find("BattleCanvas").GetComponent<Fight>();
        fight.DrawCards(2);
    }
    public override bool NeedEnemy(){return false;}
}
