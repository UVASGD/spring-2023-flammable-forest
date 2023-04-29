using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFighterJetMovement : MonoBehaviour
{
    public float rotateSpeed = 1, moveSpeed = 1, startLinDrag = 7, maxLinDrag = 9, treeDrag = 15;
    public float baseRotateSpeed = 160, highRotateSpeed = 250;
    private double leftBound = -30.0, rightBound = 180.0, highBound = 50.0, lowBound = -70.0;
    Rigidbody2D rb;
    private bool turned = false;

    [SerializeField] WaterSprayNozzle waterSprayNozzle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

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

        if (position.x < leftBound || position.x > rightBound || position.y < lowBound || position.y > highBound)
        {
            if (!turned)
            {
                turned = true;

                Debug.Log(transform.position);
                Debug.Log(rb.rotation);
                if (position.y < lowBound || position.y > highBound)
                {
                    rb.rotation = 180 - rb.rotation;
                }
                else
                {
                    rb.rotation = -rb.rotation;
                }
                rb.velocity = -1 * rb.velocity;

            }
        }
        else
        {
            rb.AddForce(moveSpeed * transform.up);
            turned = false;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            waterSprayNozzle.OpenSprayNozzle();
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            waterSprayNozzle.CloseSprayNozzle();
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
