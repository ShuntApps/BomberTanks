using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;

public class healthscript : NetworkBehaviour
{
    [Header("Tag for Friendly Bullet")][SerializeField]
    string friendlyBullet;

    [SerializeField]
    private int maxHealth = 10;

    [SyncVar]
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = this.maxHealth;
        friendlyBullet = "Bullet" + GetComponent<NetworkIdentity>().netId;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we hit the bullet or the explosion
        if(collision.GetComponent<bulletScript>().spawnedBy.netId!=GetComponent<NetworkIdentity>().netId|| collision.gameObject.tag == "Explosion")
        {
            this.TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(int amount)
    {
        if (this.isServer)
        {
            this.currentHealth -= amount;

            if (this.currentHealth <= 0)
            {
                Destroy(this.gameObject);   
            }
        }
    }

    [ClientRpc]
    void RpcRespawn()
    {
        //this.transform.position = this.startingPoint;
    }
}
