using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //apply a velocity of 7 in the "forwards" direction (dependent on rotation)
        GetComponent<Rigidbody2D>().velocity = 7*(-transform.up);
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
