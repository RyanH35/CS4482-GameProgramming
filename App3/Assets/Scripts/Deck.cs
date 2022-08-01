using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IListExtensions
{
    public static void Shuffle<T>(this IList<T> ts) {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}

public class Deck : MonoBehaviour
{
    public int maxCoins = 50;
    public int coins;
    public int maxPlayerHealth = 30;
    public int playerHealth;
    public List<DisplayCard> deckList;
    public int fightNumber = 1;
    public int battleEnergy;
    public int maxBattleEnergy = 3;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxPlayerHealth;
        coins = maxCoins;
        battleEnergy = maxBattleEnergy;
        deckList = new List<DisplayCard>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        } 
    }

     private void Awake()
    {
         DontDestroyOnLoad(this.gameObject);
    }

    public void AddCard(DisplayCard cardToAdd)
    {
        deckList.Add(cardToAdd);
    }

    public void Shuffle()
    {
        IListExtensions.Shuffle(deckList);
    }
    
    
    
}
