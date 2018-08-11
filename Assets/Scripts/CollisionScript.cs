using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public GameObject collisionParticles;

    void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider;
        if (collider.tag == "Wall" || collider.tag == "Placeable" || collider.tag == "Enemy")
        {
            Instantiate(collisionParticles).transform.position = collision.GetContact(0).point;
            Destroy(this.gameObject);
        }
    }
}
