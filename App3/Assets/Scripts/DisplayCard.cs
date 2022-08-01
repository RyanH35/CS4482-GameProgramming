using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayCard : MonoBehaviour, CardInterface, IPointerEnterHandler, IPointerExitHandler
{
    public Card card;

    public Text cardName;
    public Text description;

    public Image art;

    public Text battleCost;
    public int energyCost;

    public int price;

    protected bool mouseOver = false; //used to determine when player has mouse over a card
    public bool selected = false;

    // Start is called before the first frame update
    protected void Start()
    {
        cardName.text = card.cardName;
        description.text = card.description;

        art.sprite = card.art;

        battleCost.text = card.battleCost.ToString();  
        energyCost = card.battleCost; 

        price = card.storeCost; 
    }

    protected void Update()
    {
        if(mouseOver)
        {
            if(Input.GetMouseButtonDown(0))
            {
                selected = true;
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                selected = false;
            }
        }
    }

    //method to be overwritten by child objects
    public virtual void CardEffect(Deck cardDeck){}
    public virtual void CardEffect(Deck cardDeck, EnemyController eC){}
    public virtual bool NeedEnemy(){return true;}

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
    }

}
