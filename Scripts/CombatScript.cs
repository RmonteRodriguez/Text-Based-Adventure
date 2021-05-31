using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CombatScript : MonoBehaviour
{
    public Text mainText;

    public string[] enemies;
    public string[] spells;
    private string currentEnemy;

    private bool isFinished;

    public int playerHealth;
    public int enemyHealth;

    public GameObject newLifeButton;
    public GameObject travelButton;
    public GameObject attackButton;
    public GameObject magicButton;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        enemyHealth = 100;

        int t_randomText = Random.Range(0, 2);
        string t_randomEnemy = enemies[Random.Range(0, enemies.Length)];
        currentEnemy = t_randomEnemy;

        if (t_randomText == 0)
        {
            mainText.text = "You choose to fight the " + currentEnemy + " with a sword in one hand and magic in the other, you ready to fight.";
        }
        else if (t_randomText == 1)
        {
            mainText.text = "You make your choice to move past the enemy, so with sword in hand and channeling your magic you take a step towards your foe.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0)
        {
            if (isFinished == true) return;

            int t_randomText = Random.Range(0, 2);

            if (t_randomText == 0)
            {
                mainText.text = "You fall to your knees with no more energy remaining. You begin to lose consciousness and everything fades black...";
            }
            else if (t_randomText == 1)
            {
                mainText.text = "You begin to collapse with many thoughts crossing your mind but no energy left to do anything about it. The next thing you know the world is black...";
            }

            newLifeButton.SetActive(true);
            attackButton.SetActive(false);
            magicButton.SetActive(false);

            isFinished = true;
        }
        
        if(enemyHealth <= 0)
        {
            if (isFinished == true) return;

            int t_possibleEnemy = Random.Range(0, 3);

            if (t_possibleEnemy == 0)
            {
                int t_randomText = Random.Range(0, 2);

                if (t_randomText == 0)
                {
                    mainText.text = "You defeat the " + currentEnemy + " and regain the lost item. You return it to the owner and head back on the road.";
                }
                else if (t_randomText == 1)
                {
                    mainText.text = "You overcame your foe and recovered the lost item. After returing it to it's grateful owner you continue on your journey.";
                }

                travelButton.SetActive(true);
                attackButton.SetActive(false);
                magicButton.SetActive(false);

                isFinished = true;
            }
            else
            {
                int t_randomText = Random.Range(0, 2);

                enemyHealth = 100;

                if (t_randomText == 0)
                {
                    mainText.text = "You defeat the " + currentEnemy + ", however another " + currentEnemy + " appeared. Being too far into the dungeon you have no choice but to fight. You ready yourself and prepare to fight.";
                }
                else if (t_randomText == 1)
                {
                    mainText.text = "You overcame your foe but suddenly you were attacked by another " + currentEnemy + ". Running is not an option you stand tall and prepare to fight.";
                }
            }
        }
    }

    public void Attack()
    {
        int t_randomText = Random.Range(0, 2);
        int t_playerDamage = Random.Range(0, 10);
        int t_enemyDamage = Random.Range(0, 10);
        enemyHealth = enemyHealth - t_playerDamage;
        playerHealth = playerHealth - t_enemyDamage;

        if (t_randomText == 0)
        {
            mainText.text = "You swing your sword slashing the " + currentEnemy + " that stands in front of you. You deal " + t_playerDamage + " damage. Leaving it with " + enemyHealth + " health. The " + currentEnemy + " attacks back dealing " + t_enemyDamage + " leaving you with " + playerHealth + " health.";
        }
        else if (t_randomText == 1)
        {
            mainText.text = "With a swing of your blade  your able to get a good hit in on " + currentEnemy + ". You can tell from their reaction that you dealth " + t_playerDamage + " damage, however it's not enough as they still have " + enemyHealth + " health remaining. Before you can swing again they strike back dealing " + t_enemyDamage + " damage causing you to stagger back with " + playerHealth + " health remaining.";
        }
    }

    public void Magic()
    {
        string t_magicSpell = spells[Random.Range(0, spells.Length)];
        int t_randomText = Random.Range(0, 2);
        int t_magicDamage = Random.Range(0, 10);
        int t_enemyDamage = Random.Range(0, 10);
        playerHealth = playerHealth - t_enemyDamage;
        enemyHealth = enemyHealth - t_magicDamage;

        if (t_randomText == 0)
        {
            mainText.text = "You raise your hand and scream '" + t_magicSpell + "' dealing " + t_magicDamage + " damage. Leaving the " + currentEnemy + " with " + enemyHealth + " health. The " + currentEnemy + " attacks back dealing " + t_enemyDamage + " leaving you with " + playerHealth + " health.";
        }
        else if (t_randomText == 1)
        {
            mainText.text = "You hold your hand in front of your face and shout out " + t_magicSpell + " dealing a remarkable " + t_magicDamage + " damage leaving your oponent with only " + enemyHealth + " remaining. However with the last of their strenght they launch their own attack inflicting " + t_enemyDamage + "damage and leaving you with " + playerHealth + " health.";
        }
    }

    public void NewLife()
    {
        SceneManager.LoadScene(0);
    }
}
