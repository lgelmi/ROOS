using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 0.1f;

    // Use this for initialization
    void Start()
    {
        this.FixedUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var translation = Vector2.zero;
        translation.x += Input.GetAxis("Horizontal") * moveSpeed * this.transform.localScale.x;
        translation.y += Input.GetAxis("Vertical") * moveSpeed * this.transform.localScale.y;
        transform.position += new Vector3(translation.x, translation.y, 0);
    }
}
