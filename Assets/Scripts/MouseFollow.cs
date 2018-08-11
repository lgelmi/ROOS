using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public Vector3 mousePosition = Vector3.zero;
    public float moveSpeed = 0.1f;

    // Use this for initialization
    void Start()
    {
        this.FixedUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
}
