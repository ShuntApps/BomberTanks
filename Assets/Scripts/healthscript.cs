using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;

public class healthscript : NetworkBehaviour
{
    [Header("Tag for Enemy Bullet")][SerializeField]
    string EnemyBullet;

    [SerializeField]
    private int maxHealth = 10;

    [SyncVar]
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = this.maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if we hit the bullet or the explosion
        if(collision.gameObject.tag==EnemyBullet|| collision.gameObject.tag == "Explosion")
        {
            this.TakeDamage(1);      
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
