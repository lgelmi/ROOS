using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameRun : MonoBehaviour
{
    public List<GameObject> placeable;

    private GameObject toPlace;
    private GameObject placing;
    private UIController ui;

    // Use this for initialization
    void Start()
    {
        toPlace = placeable[0];
        if (this.GetComponent<UIController>() != null)
        {
            ui = this.GetComponent<UIController>();
            if (toPlace.GetComponent<PlaceableProperties>() != null)
                ui.updateCurrentPlaceable(toPlace.GetComponent<PlaceableProperties>().name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (toPlace)
            {
                var position = Input.mousePosition;
                position = Camera.main.ScreenToWorldPoint(position);
                placing = Instantiate(toPlace);
                placing.transform.position = new Vector3(position.x, position.y, 0);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (placing)
            {
                placing.GetComponent<CollisionScript>().FixInPlace();
            }
            placing = null;
        }

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            toPlace = placeable[0];
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            toPlace = placeable[1];
        }
    }
}
