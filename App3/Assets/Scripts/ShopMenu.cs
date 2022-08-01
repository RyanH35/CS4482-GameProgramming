using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{

    public Deck playerDeck;
    public GameObject homeMenu;
    public GameObject offenseMenu;
    public GameObject defenseMenu;
    public GameObject utilityMenu;
    public Text playerCoins;
    public DisplayCard whiffCard;

    // Start is called before the first frame update
    void Start()
    {   
        //find the deck
        playerDeck = GameObject.Find("Card Deck").GetComponent<Deck>();
        ShopHome();
    }

    //Functions to access the different submenus of the shop
    public void ShopHome()
    {
        homeMenu.SetActive(true);
        offenseMenu.SetActive(false);
        defenseMenu.SetActive(false);
        utilityMenu.SetActive(false);   
    }

    public void OffenseShop()
    {
        homeMenu.SetActive(false);
        offenseMenu.SetActive(true);
        defenseMenu.SetActive(false);
        utilityMenu.SetActive(false); 
    }
    public void DefenseShop()
    {
        homeMenu.SetActive(false);
        offenseMenu.SetActive(false);
        defenseMenu.SetActive(true);
        utilityMenu.SetActive(false); 
    }
    public void UtilityShop()
    {
        homeMenu.SetActive(false);
        offenseMenu.SetActive(false);
        defenseMenu.SetActive(false);
        utilityMenu.SetActive(true); 
    }

    public void Purchase(DisplayCard displayCard)
    {
        //determine if player has enough money for card
        if(playerDeck.coins >= displayCard.price)
        {
            //purchase card and add to deck
            playerDeck.coins -= displayCard.price;
            playerDeck.AddCard(displayCard);
        }
        else
        {
            Debug.Log("can't afford");
        }
    }

    void Update(){
        playerCoins.text = "Coins: " + playerDeck.coins.ToString();
    }

    public void exitShop()
    {
        //check deck size, deck must contain at least 10 cards
        while(playerDeck.deckList.Count < 10)
        {
            //if deck has less than 10 cards, add useless cards to fill deck/hand
            playerDeck.AddCard(whiffCard);
        }
        SceneManager.LoadScene("Fight"+playerDeck.fightNumber);
    }
}
