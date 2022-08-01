using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinnedAssaultEffect : DisplayCard
{
    public override void CardEffect(Deck cardDeck)
    {
        Fight fight = GameObject.Find("BattleCanvas").GetComponent<Fight>();
        foreach (EnemyController eC in fight.enemyList)
        {
            eC.enemyHealth -= 8;
        }
        cardDeck.battleEnergy -= energyCost;
    }
    public override bool NeedEnemy(){return false;}
}
