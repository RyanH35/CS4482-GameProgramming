using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class Fight : MonoBehaviour
{
    public Canvas battleCanvas;
    public Canvas gameOverCanvas;

    public List<EnemyController> enemyList;
    Deck cardDeck;
    Deck cardDeckCopy;
    Deck discardDeck;
    public GameObject pauseMenu;

    public List<DisplayCard> handOfCards;
    public DisplayCard handCard1;
    public DisplayCard handCard2;
    public DisplayCard handCard3;
    public DisplayCard handCard4;
    public DisplayCard handCard5;

    private Vector3 cardPosition1;
    private Vector3 cardPosition2;
    private Vector3 cardPosition3;
    private Vector3 cardPosition4;
    private Vector3 cardPosition5;

    public DisplayCard selectedCard;
    public EnemyController selectedEnemy;

    private EnemyController deadEnemy;

    private int cardDeckListIndex = 0;

    private int roundNumber = 1;
    public Text roundNumText;
    public Text playerHealthText;
    public Text battleEnergyText;

    private bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
        pauseMenu.SetActive(false);
        gameOverCanvas.enabled = false;
        cardDeck = GameObject.Find("Card Deck").GetComponent<Deck>();

        cardDeckCopy = GameObject.Find("Copy Deck").GetComponent<Deck>();
        for(int i =0; i < cardDeck.deckList.Count; i++)
        {
            DisplayCard tmpCard = cardDeck.deckList[i];
            tmpCard = Instantiate(tmpCard);
            cardDeckCopy.AddCard(tmpCard);

        }

        cardDeckCopy.Shuffle();

        discardDeck = GameObject.Find("Discard Deck").GetComponent<Deck>();

        battleCanvas = GameObject.Find("BattleCanvas").GetComponent<Canvas>();
        
        handCard1 = cardDeckCopy.deckList[cardDeckListIndex];
        cardPosition1 = new Vector3(60, 90, 0); 
        handCard1 = Instantiate(handCard1, cardPosition1, Quaternion.identity);
        handCard1.transform.SetParent(battleCanvas.transform);
        handOfCards.Add(handCard1);
        cardDeckListIndex++;

        handCard2 = cardDeckCopy.deckList[cardDeckListIndex];
        cardPosition2 = new Vector3(190, 90, 0); //add 130
        handCard2 = Instantiate(handCard2, cardPosition2, Quaternion.identity);
        handCard2.transform.SetParent(battleCanvas.transform);
        handOfCards.Add(handCard2);
        cardDeckListIndex++;

        handCard3 = cardDeckCopy.deckList[cardDeckListIndex];
        cardPosition3 = new Vector3(320, 90, 0); //add 130
        handCard3 = Instantiate(handCard3, cardPosition3, Quaternion.identity);
        handCard3.transform.SetParent(battleCanvas.transform);
        handOfCards.Add(handCard3);
        cardDeckListIndex++;

        handCard4 = cardDeckCopy.deckList[cardDeckListIndex];
        cardPosition4 = new Vector3(450, 90, 0); //add 130
        handCard4 = Instantiate(handCard4, cardPosition4, Quaternion.identity);
        handCard4.transform.SetParent(battleCanvas.transform);
        handOfCards.Add(handCard4);
        cardDeckListIndex++;

        handCard5 = cardDeckCopy.deckList[cardDeckListIndex];
        cardPosition5 = new Vector3(580, 90, 0); //add 130
        handCard5 = Instantiate(handCard5, cardPosition5, Quaternion.identity);
        handCard5.transform.SetParent(battleCanvas.transform);
        handOfCards.Add(handCard5);
        cardDeckListIndex++;
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Your HP: " + cardDeck.playerHealth;
        roundNumText.text = "Round: " + roundNumber;
        battleEnergyText.text = "Energy: " + cardDeck.battleEnergy;

        //check if player has lost
        if(cardDeck.playerHealth <= 0)
        {
            EndGame();
        }

        
        //check if there is a selected card
        foreach (DisplayCard cardInHand in handOfCards)
        {
            if(cardInHand.selected)
            {
                selectedCard = cardInHand;
            }

        }
        //check if card needs an enemy selected, if not then execute effect
        if(selectedCard != null)
        {
            if(selectedCard.NeedEnemy())
            {
                if(selectedEnemy != null)
                {
                    if(cardDeck.battleEnergy - selectedCard.energyCost >= 0)
                    {
                        selectedCard.CardEffect(cardDeck, selectedEnemy);
                        selectedCard.transform.SetParent(null);
                    
                        DisplayCard discardCard =  Instantiate(selectedCard);
                        discardDeck.AddCard(discardCard);

                        Destroy(selectedCard.gameObject);
                        handOfCards.Remove(selectedCard);
                        selectedEnemy.selected = false;
                        selectedEnemy = null;
                        selectedCard = null;
                    }         
                }
            }
            else
            {
                if(cardDeck.battleEnergy - selectedCard.energyCost >= 0)
                {
                    selectedCard.CardEffect(cardDeck);
                    selectedCard.transform.SetParent(null);

                    DisplayCard discardCard =  Instantiate(selectedCard);
                    discardDeck.AddCard(discardCard);

                    Destroy(selectedCard.gameObject);
                    handOfCards.Remove(selectedCard);
                    selectedEnemy = null;
                    selectedCard = null;
                }
            }

        }
        
        //check if there is a selected enemy
        foreach (EnemyController enemy in enemyList)
        {
            if(enemy.selected)
            {
                selectedEnemy = enemy;
            }
            if(enemy.enemyHealth <= 0)
            {
                deadEnemy = enemy;
            }
        }

        //remove enemy from scene if it is dead
        if(deadEnemy != null)
        {
            Destroy(deadEnemy.gameObject);
            enemyList.Remove(deadEnemy);
            deadEnemy = null;
        }

        //check if all enemies are dead
        if(enemyList.Count == 0){
            advanceLevel();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
            
        }
    }
    
    public void Pause()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        pauseMenu.SetActive(true);
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        gamePaused = false;
        pauseMenu.SetActive(false);
    }

    public void EndPlayerTurn()
    {
        selectedCard = null;
        selectedEnemy = null;
        foreach (EnemyController obj in enemyList)
        {
            obj.enemyData.TakeTurn();
            obj.enemyAttack = obj.enemyData.maxAttack;
        }
        DrawCards(5);
        roundNumber++;
        cardDeck.battleEnergy = cardDeck.maxBattleEnergy;
    }

    private void EndGame()
    {
        //DISPLAY A GAMEOVER MENU
        battleCanvas.enabled = false;
        gameOverCanvas.enabled = true;

        Destroy(GameObject.Find("Card Deck"));
        Destroy(GameObject.Find("Copy Deck"));
        Destroy(GameObject.Find("Discard Deck"));
    }

    public void quitToMenu()
    {
        Destroy(GameObject.Find("Card Deck"));
        Destroy(GameObject.Find("Copy Deck"));
        Destroy(GameObject.Find("Discard Deck"));
        SceneManager.LoadScene("MainMenu");
    }

    public void DrawCards(int cardsToDraw)
    {
        while(cardsToDraw > 0)
        {
            try
            {
                if(handCard1 == null)
                {
                    handCard1 = cardDeckCopy.deckList[cardDeckListIndex];
                    handCard1 = Instantiate(handCard1, cardPosition1, Quaternion.identity);
                    handCard1.transform.SetParent(battleCanvas.transform);
                    handOfCards.Add(handCard1);
                    cardDeckListIndex++;
                    
                }
                else if (handCard2 == null)
                {
                    handCard2 = cardDeckCopy.deckList[cardDeckListIndex];
                    handCard2 = Instantiate(handCard2, cardPosition2, Quaternion.identity);
                    handCard2.transform.SetParent(battleCanvas.transform);
                    handOfCards.Add(handCard2);
                    cardDeckListIndex++;

                }
                else if (handCard3 == null)
                {
                    handCard3 = cardDeckCopy.deckList[cardDeckListIndex];
                    handCard3 = Instantiate(handCard3, cardPosition3, Quaternion.identity);
                    handCard3.transform.SetParent(battleCanvas.transform);
                    handOfCards.Add(handCard3);
                    cardDeckListIndex++;
                }
                else if (handCard4 == null)
                {
                    handCard4 = cardDeckCopy.deckList[cardDeckListIndex];
                    handCard4 = Instantiate(handCard4, cardPosition4, Quaternion.identity);
                    handCard4.transform.SetParent(battleCanvas.transform);
                    handOfCards.Add(handCard4);
                    cardDeckListIndex++;   
                }
                else if (handCard5 == null)
                {
                    handCard5 = cardDeckCopy.deckList[cardDeckListIndex];
                    handCard5 = Instantiate(handCard5, cardPosition5, Quaternion.identity);
                    handCard5.transform.SetParent(battleCanvas.transform);
                    handOfCards.Add(handCard5);
                    cardDeckListIndex++;          
                }
                else
                {
                    break;
                }
                cardsToDraw -= 1;
            }
            catch
            {
                //refill the deck
                discardDeck.Shuffle();
                cardDeckCopy.deckList = new List<DisplayCard>(discardDeck.deckList);
                discardDeck.deckList.Clear();
                cardDeckListIndex = 0;
            }
            
        }

    }

    private void advanceLevel()
    {
        //reset decks
        cardDeckCopy.deckList.Clear();
        discardDeck.deckList.Clear();
        cardDeck.battleEnergy = cardDeck.maxBattleEnergy;
        //change fight number to get next scene
        cardDeck.fightNumber++;
        //add coins base on number of rounds passed
        cardDeck.coins += 50 - (5*roundNumber);
    
        if(cardDeck.fightNumber == 3)
        {
            //END GAME
            SceneManager.LoadScene("Victory");
        }
        else
        {
            //load shop scene
            SceneManager.LoadScene("Shop");
        }

    }

}