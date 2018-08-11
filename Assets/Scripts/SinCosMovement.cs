using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinCosMovement : MonoBehaviour
{
    public Vector2 origin = Vector2.zero;
    public Vector2 amplitude = Vector2.zero;
    public Vector2 speed = Vector2.zero;

    // Use this for initialization
    void Start()
    {
        origin = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var sin = Mathf.Sin(Time.time * speed.x);
        var cos = Mathf.Cos(Time.time * speed.y);
        this.transform.position = origin + new Vector2(sin * amplitude.x, cos * amplitude.y);
    }
}
