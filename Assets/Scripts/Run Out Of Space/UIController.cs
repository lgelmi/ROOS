using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public GameObject canvas;

    private Text current;
    private Text available;
    private Text score;

    void Awake()
    {
        foreach (Transform child in canvas.transform)
        {
            if (child.name == "Available")
                available = child.GetComponent<Text>();
            else if (child.name == "CurrentPlaceable")
                current = child.GetComponent<Text>();
            else if (child.name == "Score")
                score = child.GetComponent<Text>();
        }
    }

    public void updateCurrentPlaceable(string name)
    {
        current.text = "Current placeable: " + name;
    }

    public void updateAvailablePlaceable(List<string> names, List<int> amounts)
    {
        string text = "";

        for (int i = 0; i < names.Count; i++)
        {
            if (amounts[i] > 0)
                text += " " + amounts[i].ToString() + " " + names[i];
        }
        if (string.Compare(text, "") == 0)
        {
            text = " None";
        }

        available.text = "Available placeable:" + text;
    }

    public void updateScore(float currentScore, float winScore)
    {
        score.text = "Score: " + currentScore.ToString() + "/" + winScore.ToString();

    }

    
}
