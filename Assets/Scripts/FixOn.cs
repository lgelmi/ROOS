using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixOn : MonoBehaviour
{
    public GameObject toFollow;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (toFollow)
        {
            var pos = toFollow.transform.position;
            this.transform.position = new Vector3(pos.x, pos.y, this.transform.position.z);

            this.GetComponent<Camera>().orthographicSize = toFollow.transform.localScale.x + 5;
        }
    }
}
