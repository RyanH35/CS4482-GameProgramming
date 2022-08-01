using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public EnemyBase enemyData;

    public Text attackText;
    public int enemyAttack;

    public Text enemyName; 

    public Text health;
    public int enemyHealth;

    protected bool mouseOver = false; //used to determine when player has mouse over the enemy
    public bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        //setup visual components
        attackText.text = "Attack: " + enemyData.attack.ToString();
        enemyName.text = enemyData.enemyName;
        health.text = "Health: " + enemyData.health.ToString();

        enemyHealth = enemyData.health;
        enemyAttack = enemyData.attack;
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + enemyHealth.ToString();
        attackText.text = "Attack: " + enemyAttack.ToString();
        

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
    }
}
