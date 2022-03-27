using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Mirror;

public class fireScript : NetworkBehaviour
{
    [Header("Prefabs")]
    public GameObject bullet;
    public GameObject mine;
    [Header("Keys to press")]
    public KeyCode fireKey;
    public KeyCode mineKey;
    [Header("Muzzle Location")]
    [SerializeField] Transform muzzle;

    [Header("Shooting Settings")]
    [SyncVar][SerializeField] int ammoCount;
    float timeTilNextShot=0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("netID"+GetComponent<NetworkIdentity>().netId);
    }

    // Update is called once per frame
    void Update()
    {
        //if the fire key we assigned is pressed AND the ammo is greater than 1 AND the time until next shot is past
        if((Input.GetKeyDown(fireKey))&&ammoCount>0&&(Time.time>timeTilNextShot))
        {
            if (this.isLocalPlayer)
            {
                this.CmdShoot(GetComponent<NetworkIdentity>());
            }          
        }
        //if the bomb key we assigned is pressed
        if(Input.GetKeyDown(mineKey))
        {
            if (this.isLocalPlayer)
            {
                this.CmdMine();
            }
        }
    }

    [Command]
    void CmdMine()
    {
        //create a new bomb and snap it to the middle of the square we're in
        GameObject newMine =Instantiate(mine, new Vector2((Mathf.RoundToInt(transform.position.x / 0.64f) * 0.64f),
            (Mathf.RoundToInt(transform.position.y / 0.64f) * 0.64f)), mine.transform.rotation);
        NetworkServer.Spawn(newMine);
    }

    [Command]
    void CmdShoot(NetworkIdentity netId)
    {
        //create a new bullet
        GameObject newBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        //make sure the rotation is right otherwise bullet will just ignore rotation
        newBullet.transform.rotation = transform.rotation;
        //ignore collisions with itself (so we don't shoot ourselves)
        //Physics2D.IgnoreCollision(newBullet.GetComponent<CapsuleCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        //update time til next shot and ammo
        timeTilNextShot += 2;
        ammoCount--;
        newBullet.GetComponent<bulletScript>().spawnedBy = netId;
        //newBullet.tag = "Bullet" + GetComponent<NetworkIdentity>().netId;
        newBullet.GetComponent<Rigidbody2D>().velocity = -transform.up * 7;
        NetworkServer.Spawn(newBullet,connectionToClient);
        Invoke("CmdDestroyThing", 1);
        
    }

    [Command]
    void CmdDestroyThing(GameObject thingToDestroy)
    {
        NetworkServer.Destroy(thingToDestroy);
    }
  


}
