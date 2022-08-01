using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CardInterface
{
    void CardEffect(Deck cardDeck);
    void CardEffect(Deck cardDeck, EnemyController eC);
}
