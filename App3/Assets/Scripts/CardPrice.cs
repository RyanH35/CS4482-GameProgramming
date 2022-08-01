using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPrice : MonoBehaviour
{
    public Card card;
    public Text priceText;
    // Start is called before the first frame update
    void Start()
    {
        priceText.text = "Price: " + card.storeCost.ToString();
    }
}
