using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthscript : MonoBehaviour
{
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
        if(collision.gameObject.tag==EnemyBullet|| collision.gameObject.tag == "Explosion")
        {
            Destroy(gameObject);
        }
    }
}
