using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    [Range(1,2)]
    public int playerNum;
    public KeyCode[] keyCodes;
    Rigidbody2D rigidbody;
    public float moveSpeed=1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();   
    }

    public void UpdateMovement()
    {
        if(Input.GetKey(keyCodes[0]))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, moveSpeed);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if(Input.GetKey(keyCodes[1]))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, -moveSpeed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(keyCodes[2]))
        {
            rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if(Input.GetKey(keyCodes[3]))
        {
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

    }
}
