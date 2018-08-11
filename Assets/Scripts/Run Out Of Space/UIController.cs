using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public GameObject canvas;

    private Text current;
    private Text available;

    // Use this for initialization
    void Start()
    {
        foreach (Transform child in canvas.transform)
        {
            if (child.name == "Available")
                available = child.GetComponent<Text>();
            else if (child.name == "CurrentPlaceable")
                current = child.GetComponent<Text>();
        }

    }

    public void updateCurrentPlaceable(string name)
    {
        //current.text = "Current placeable: " + name;
        print("?");
    }

    public void updateAvailablePlaceable(List<string> names, List<int> amounts)
    {
        available.text = "Available placeable:";

        if (names.Count <= 0)
        {
            available.text += " None.";
        }
        else
        {
            for (int i = 0; i < names.Count; i++)
            {
                available.text += " " + names[i] + " " + amounts.ToString();
            }
            available.text += ".";
        }
    }
}
