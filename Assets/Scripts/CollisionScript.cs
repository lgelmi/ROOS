using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public GameObject collisionParticles;

    void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider;
        if (this.gameObject.GetComponent<PlaceableProperties>())
            if (this.gameObject.GetComponent<PlaceableProperties>().delicate && (collider.tag == "Wall" || collider.tag == "Placeable" || collider.tag == "Enemy"))
            {
                Instantiate(collisionParticles).transform.position = collision.GetContact(0).point;
                Destroy(this.gameObject);
                return;
            }

        if (collider.tag == "Wall" || collider.tag == "NoSpawn" || collider.tag == "Placeable" || collider.tag == "Enemy")
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
    }
    public void FixInPlace()
    {
        if (this.GetComponent<Expand>() != null)
            this.GetComponent<Expand>().speed = 0;
        if (this.GetComponent<MouseFollow>() != null)
            this.GetComponent<MouseFollow>().enabled = false;
    }
}
