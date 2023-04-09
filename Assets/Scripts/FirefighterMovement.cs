using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirefighterMovement : MonoBehaviour
{
    public float speed;
    public float fireSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dPos = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            dPos += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dPos += new Vector3(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dPos += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dPos += new Vector3(1, 0, 0);
        }

        //movement
        rb.AddForce(dPos.normalized * speed);
        if (dPos == new Vector3(0, 0, 0))
        {
            rb.AddForce(-0.999f * rb.velocity);
        }
        else
        {
            rb.AddForce(rb.velocity * -0.5f);
        }
        //transform.position += dPos.normalized * speed * 0.01f;
    }
}
