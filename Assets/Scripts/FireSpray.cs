using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpray : MonoBehaviour
{
    // private SpriteRenderer sr;
    // private BoxCollider2D col;
    public bool spraying = false;
    public float waterForce = 10;
    public Sparks sparks;

    // Start is called before the first frame update
    void Start()
    {
        // sr = GetComponent<SpriteRenderer>();
        // col = GetComponent<BoxCollider2D>();
        sprayOff();
        sparks = GetComponent<Sparks>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !spraying)
        {
            sprayOn();
        } 
        if (Input.GetMouseButtonUp(0) && spraying)
        {
            sprayOff();
        }

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mouse - transform.parent.position + new Vector3(0,0,10);
        transform.parent.right = dir;
        if (spraying)
        {
            transform.parent.parent.GetComponent<Rigidbody2D>().AddForce(dir.normalized * waterForce * -1);
        }
    }

    public void sprayOff()
    {
        // sr.enabled = false;
        // col.enabled = false;
        spraying = false;
        sparks.stop();
    }
    public void sprayOn()
    {
        // sr.enabled = true;
        // col.enabled = true;
        spraying = true;
        sparks.play();
    }
}
