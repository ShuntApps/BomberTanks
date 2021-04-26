using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineScript : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        GameObject bang= Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        StartCoroutine(MoreExplosions(Vector3.up * 0.64f));
        StartCoroutine(MoreExplosions(Vector3.right * 0.64f));
        StartCoroutine(MoreExplosions(Vector3.down * 0.64f));
        StartCoroutine(MoreExplosions(Vector3.left * 0.64f));
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(bang, .3f);
        Destroy(gameObject, .3f);
    }

    public IEnumerator MoreExplosions(Vector3 direction)
    {
        for (int i = 1; i < 3; i++)
        {
            RaycastHit2D hit=Physics2D.Raycast(transform.position,  direction, i * 0.64f,wallLayer);

            if (!hit.collider)
            {
                GameObject bang = Instantiate(ExplosionPrefab, transform.position + (i * direction),
                  ExplosionPrefab.transform.rotation);
                Destroy(bang, .3f);
            }
            else
            { 
                break;
            }
            yield return new WaitForSeconds(.05f);
        }
    }
}
