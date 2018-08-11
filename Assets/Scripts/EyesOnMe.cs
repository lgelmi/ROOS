using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesOnMe : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FixOn>().toFollow = this.gameObject;
    }
}
