using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public GameObject toPlace;

    public GameObject placing;

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
            placing = Instantiate(toPlace);
            placing.transform.position = position;
        }

        if (Input.GetMouseButtonUp(0) && placing)
        {
            placing.GetComponent<CollisionScript>().FixInPlace();
            placing = null;
        }
    }
}
