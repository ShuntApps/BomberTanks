using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthscript : MonoBehaviour
{
    [Header("Tag for Enemy Bullet")]
    public string EnemyBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if we hit the bullet or the explosion
        if(collision.gameObject.tag==EnemyBullet|| collision.gameObject.tag == "Explosion")
        {
            Destroy(gameObject);
            /**
             * This could be changed so that instead of destroying the tank it;
             * 1) spawns an effect to show the hit
             * 2) update a score
             * 3) update health
             * 4) Checks to see if health is dead and sends a game over message
             * 5) ???
             */
        }
    }
}
