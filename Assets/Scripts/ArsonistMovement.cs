using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArsonistMovement : MonoBehaviour
{
    public float rotateSpeed = 1, moveSpeed = 1, startLinDrag = 7, maxLinDrag = 9, treeDrag = 15;
    public float baseRotateSpeed = 160, highRotateSpeed = 250;

    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //more linear drag while turning
        rb.drag = (maxLinDrag) - (maxLinDrag-startLinDrag) / (Mathf.Abs(rb.angularVelocity) + 1);


        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(rotateSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-1*rotateSpeed);
        }

        rb.AddForce(moveSpeed * transform.up);

        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<Fuel>().burning = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Fuel>().burning = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tree")
        {
            rb.AddForce(-1 * rb.velocity.normalized * treeDrag);
        }
    }

}
