using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Crossroads : MonoBehaviour
{
    public Text mainText;

    public string[] locations;
    public string[] possibleNPC;
    public string[] lostItems;
    private string setLocation1;
    private string setLocation2;
    private string setLostItem;

    // Start is called before the first frame update
    void Start()
    {
        string t_randomLocation1 = locations[Random.Range(0, locations.Length)];
        string t_randomLocation2 = locations[Random.Range(0, locations.Length)];
        int t_randomText = Random.Range(0, 3);
        setLocation1 = t_randomLocation1;
        setLocation2 = t_randomLocation2;

        if (t_randomText == 0)
        {
            mainText.text = "You stand at a crossroads to your left there is " + t_randomLocation1 + " and to your right there is " + t_randomLocation2 + ". Which way would you go?";
        }
        else if (t_randomText == 1)
        {
            mainText.text = "A new adventure awaits you! You stand in at a crossroads, on the left path there is " + t_randomLocation1 + " and on the right path there is " + t_randomLocation2 + ". Which path would you take?";
        }
        else if (t_randomText == 2)
        {
            mainText.text = "Before you lies two paths. The left one leads to " + t_randomLocation1 + " while the one to your right leads to " + t_randomLocation2 + ". Which route do you take?";
        }
    }

    public void GoLeft()
    {
        string t_randomNPC = possibleNPC[Random.Range(0, locations.Length)];
        string t_lostItems = lostItems[Random.Range(0, locations.Length)];
        int t_randomText = Random.Range(0, 3);
        setLostItem = t_lostItems;

        if (t_randomText == 0)
        {
            mainText.text = "You decide to go left and arrive at your destination, when you get there you are greeted by " + t_randomNPC + ". They exclaim that they had lost " + t_lostItems + " they would like you to find it for them, Would you?";
        }
        else if (t_randomText == 1)
        {
            mainText.text = "After some thought you head left and upon you're arrival you're immediately approached by " + t_randomNPC + ", they you their story on how they lost " + t_lostItems + " and ask for you're assistance in reclaiming them. Do you accept?";
        }
        else if (t_randomText == 2)
        {
            mainText.text = "You decide to follow the path leading to " + setLocation1 + ". Upon your arrival, a stanger who appears to be " + t_randomNPC + " greets you. They ask you for assistance as they have lost " + t_lostItems + " and need help finding it. What will you do?";
        }
    }

    public void GoRight()
    {
        string t_randomNPC = possibleNPC[Random.Range(0, locations.Length)];
        string t_lostItems = lostItems[Random.Range(0, locations.Length)];
        int t_randomText = Random.Range(0, 2);
        setLostItem = t_lostItems;

        if (t_randomText == 0)
        {
            mainText.text = "You decide to go right and arrive at your destination, when you get there you are greeted by " + t_randomNPC + ". They exclaim that they had lost " + t_lostItems + " they would like you to find it for them, Would you?";
        }
        else if (t_randomText == 1)
        {
            mainText.text = "After some thought you head right and upon you're arrival you're immediately approached by " + t_randomNPC + ", they you their story on how they lost " + t_lostItems + " and ask for you're assistance in reclaiming them. Do you accept?";
        }
        else if (t_randomText == 2)
        {
            mainText.text = "You decide to follow the path leading to " + setLocation2 + ". Upon your arrival, a stanger who appears to be " + t_randomNPC + " greets you. They ask you for assistance as they have lost " + t_lostItems + " and need helo finding it. What will you do?";
        }
    }

    public void SelectYes()
    {
        int t_randomText = Random.Range(0, 2);

        if (t_randomText == 0)
        {
            mainText.text = "You were told that the missing item was in a nearby dungeon. You travel to it and begin to go in the depths. As you traverse the dungeon you come accross an enemy. Would you fight or run?";
        }
        else if (t_randomText == 1)
        {
            mainText.text = "You rememeber them mentioning that the " + setLostItem + " was inside of a dungeon. As you arrice you take a brief moment to compose yourself before venturing down into it's depths. You don't make it far before you spot something, it's an enemy. You make your choice, do you fight or run?";
        }
    }

    public void SelectNo()
    {
        SceneManager.LoadScene(0);
    }

    public void Fight()
    {
        SceneManager.LoadScene(1);
    }
}
