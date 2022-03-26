using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class mineScript : NetworkBehaviour
{
    //Prefab for the explosion
    public GameObject ExplosionPrefab;
    //layer for the wall to stop explosions going through
    public LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
        //run explode code after 2 seconds
        Invoke("Explode", 2);
    }

    void Explode()
    {
        // create an explosion
        GameObject bang= Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        //run code to check the direction for the explosion
        StartCoroutine(MoreExplosions(Vector3.up * 0.64f));
        StartCoroutine(MoreExplosions(Vector3.right * 0.64f));
        StartCoroutine(MoreExplosions(Vector3.down * 0.64f));
        StartCoroutine(MoreExplosions(Vector3.left * 0.64f));
        //hide the mine
        GetComponent<SpriteRenderer>().enabled = false;
        //destroy explosion and gameobject after .3 of a second
        Destroy(bang, .3f);
        Destroy(gameObject, .3f);
    }

    public IEnumerator MoreExplosions(Vector3 direction)
    {
        // loop around each square in a direction you want it to go (in this case 2)
        for (int i = 1; i < 3; i++)
        {
            //raycast out from middle in direction, i number of squares and only hitting a particular layer
            RaycastHit2D hit=Physics2D.Raycast(transform.position,  direction, i * 0.64f,wallLayer);
            //if we don't hit anything
            if (!hit.collider)
            {
                // create an explosion at the position we've checked
                GameObject bang = Instantiate(ExplosionPrefab, transform.position + (i * direction),ExplosionPrefab.transform.rotation);
                Destroy(bang, .3f);
            }
            else
            { 
                //otherwise, if we hit a wall, stop
                break;
            }
            //wait for .05 seconds so it's not an instant explosion
            yield return new WaitForSeconds(.05f);
        }
    }
}
