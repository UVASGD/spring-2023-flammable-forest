using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArsonMove : MonoBehaviour
{
    public float speed;
    public float fireSpeed;
    private Rigidbody2D rb;
    public float stopdragK, startdragK;

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
            rb.AddForce(-1 * stopdragK * rb.velocity * Mathf.Pow(rb.velocity.magnitude, 0.5f));
        }
        else
        {
            rb.AddForce(rb.velocity * Mathf.Pow(rb.velocity.magnitude,3) / (rb.velocity.magnitude + 1) * -1 * startdragK);
        }
        //transform.position += dPos.normalized * speed * 0.01f;
    }
}
