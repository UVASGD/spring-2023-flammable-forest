using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float fireSpeed;

    public GameObject firePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject f = Instantiate(firePrefab, transform.position, Quaternion.identity);
            Rigidbody2D r = f.GetComponent<Rigidbody2D>();
            r.velocity = new Vector3(1, 0.3f + Random.Range(-0.15f,0.15f),0) * fireSpeed;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject f = Instantiate(firePrefab, transform.position, Quaternion.identity);
            Rigidbody2D r = f.GetComponent<Rigidbody2D>();
            r.velocity = new Vector3(1, 0.3f + Random.Range(-0.15f, 0.15f), 0) * fireSpeed;
            SpriteRenderer sr =f.GetComponent<SpriteRenderer>();
            sr.color = new Color(0, 50, 1);
        }

        transform.position += dPos.normalized * speed * 0.01f;
    }
}
