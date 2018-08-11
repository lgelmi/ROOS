using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public int tAlive = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.tAlive++;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall" || collider.tag == "NoSpawn" || collider.tag == "Placeable")
        {
            if (this.tAlive > 1)
            {
                this.enabled = false;
                if (collider.tag != "NoSpawn")
                {
                    FixInPlace();
                }
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void FixInPlace()
    {
        if (this.GetComponent<Expand>() != null)
            this.GetComponent<Expand>().speed = 0;
        if (this.GetComponent<MouseFollow>() != null)
            this.GetComponent<MouseFollow>().enabled = false;
    }
}
