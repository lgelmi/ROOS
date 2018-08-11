using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject canvas;

    private Text current;
    private Text available;

	// Use this for initialization
	void Start () {
        foreach (Transform child in canvas.transform)
        {
            if (child.name == "Available")
                available = child.GetComponent<Text>();
            else if (child.name == "CurrentPlaceable")
                current = child.GetComponent<Text>();
        }

	}

    public void updateCurrentPlaceable(string name) {
        print(name);
        current.text = "Current placeable: " + name;
    }
}
