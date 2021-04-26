using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject mine;

    public KeyCode fireKey;
    public KeyCode bombKey;

    public Transform muzzle;

    public int ammoCount;
    float timeTilNextShot=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(fireKey))&&ammoCount>1&&(Time.time>timeTilNextShot))
        {
            GameObject newBullet=Instantiate(bullet, muzzle.position, Quaternion.identity);
            newBullet.transform.rotation = transform.rotation;
            Physics2D.IgnoreCollision(newBullet.GetComponent<CapsuleCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
            timeTilNextShot += 2;
        }
        if(Input.GetKeyDown(bombKey))
        {
            Instantiate(mine, new Vector2((Mathf.RoundToInt(transform.position.x/0.64f)*0.64f),
  (Mathf.RoundToInt(transform.position.y/0.64f) * 0.64f)),
  mine.transform.rotation);


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }


}
