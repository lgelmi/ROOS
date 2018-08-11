using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public GameObject toPlace;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var position = Input.mousePosition;
            position = Camera.main.ScreenToWorldPoint(position);
            if (CanPlace(position))
            {
                Instantiate(toPlace).transform.position = position;
            }
        }
    }

    bool CanPlace(Vector2 position)
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(position);

        return !Physics.Raycast(ray, out hit);
    }
}
