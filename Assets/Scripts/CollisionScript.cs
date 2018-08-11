using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public GameObject collisionParticles;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider;
        if (collider.tag == "Wall" || collider.tag == "NoSpawn" || collider.tag == "Placeable" || collider.tag == "Enemy")
        {
            if (this.tAlive > 1)
            {
                this.enabled = false;
                if (collider.tag == "Wall" || collider.tag == "Placeable")
                {
                    Instantiate(collisionParticles).transform.position = collision.GetContact(0).point;
                    FixInPlace();
                }
                if (collider.tag == "Enemy")
                {
                    Instantiate(collisionParticles).transform.position = collision.GetContact(0).point;
                    Destroy(this.gameObject);
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
        this.GetComponent<Expand>().speed = 0;
        this.GetComponent<MouseFollow>().enabled = false;
    }
}
