using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class networkMovement : NetworkBehaviour
{
    public KeyCode[] keyCodes;
    [Header("Physics and movement Settings")]
    Rigidbody2D rigidbody;
    [SerializeField]
    private float moveSpeed=1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.isLocalPlayer)
        {
            UpdateMovement();
        }
    }

    public void UpdateMovement()
    {

        //key 0 is front, 1 is back, 2 is left, 3 is right
        if (Input.GetKey(keyCodes[0]))
        {
            //set the speed to the right direction and rotation
            rigidbody.velocity = Vector2.zero;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, moveSpeed);
            transform.rotation = Quaternion.Euler(0, 0, 180);
            transform.position =
               new Vector3(4.51f + (0.64f * Mathf.Round((transform.position.x - 4.51f) / 0.64f)), transform.position.y);

        }
        else if(Input.GetKey(keyCodes[1]))
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, -moveSpeed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position =
                       new Vector3(4.51f + (0.64f * Mathf.Round((transform.position.x - 4.51f) / 0.64f)), transform.position.y);

        }
        else if (Input.GetKey(keyCodes[2]))
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 270);
            transform.position =
                new Vector3(transform.position.x, -0.02f + (0.64f * Mathf.Round((transform.position.y + 0.02f) / 0.64f)));
        }
        else if(Input.GetKey(keyCodes[3]))
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 90);
            transform.position =
                new Vector3(transform.position.x, -0.02f + (0.64f * Mathf.Round((transform.position.y + 0.02f) / 0.64f)));
        }
       
    }
}
