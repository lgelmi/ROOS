using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public GameObject toSpawn;
    public float respawnTime = 0;
    public GameObject spawned;

    private bool _respawning = false;

    void Start()
    {
        DoRespawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned && !_respawning)
        {
            _respawning = true;
            StartCoroutine(StartRespawning());
        }
    }

    IEnumerator StartRespawning()
    {
        yield return new WaitForSeconds(respawnTime);
        DoRespawn();
    }

    void DoRespawn()
    {
        spawned = Instantiate(toSpawn);
        spawned.transform.position = this.transform.position;
        if (spawned.GetComponent<PlaceableProperties>())
            spawned.GetComponent<PlaceableProperties>().delicate = true;
        if (spawned.GetComponent<MouseFollow>())
        { 
            spawned.GetComponent<MouseFollow>().minimumDistance = 2;
            spawned.GetComponent<MouseFollow>().maxSpeed = 0.1f;
        }
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FixOn>().toFollow = spawned;
        _respawning = false;
    }
}
