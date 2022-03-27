using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class bulletScript : NetworkBehaviour
{

    [SyncVar]
    public NetworkIdentity spawnedBy;

    // Set collider for all clients.
    public override void OnStartClient()
    {
       // Physics2D.IgnoreCollision(GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(hasAuthority);
        //apply a velocity of 7 in the "forwards" direction (dependent on rotation)
        //GetComponent<Rigidbody2D>().velocity = 7*(-transform.up);
        //NetworkServer.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 8)
        {
            if (hasAuthority)
                CmdDestroyThing(gameObject);
        }
    }

    [Command]
    void CmdDestroyThing(GameObject thingToDestroy)
    {
        NetworkServer.Destroy(thingToDestroy);
    }
}
