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
        this.enabled = false;
        if (this.tAlive > 1)
        {
            FixInPlace();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void FixInPlace()
    {
        this.GetComponent<Expand>().speed = 0;
        this.GetComponent<MouseFollow>().enabled = false;
    }
}
