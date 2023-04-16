using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArsonistMovement : MonoBehaviour
{
    public float rotateSpeed = 1, moveSpeed = 1;
    public float baseRotateSpeed = 160, highRotateSpeed = 250, extraSpeed, decay;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            extraSpeed = highRotateSpeed;
        }


        if (Input.GetKey(KeyCode.A))
        {
            extraSpeed *= decay;
            transform.Rotate((baseRotateSpeed+extraSpeed) * new Vector3(0, 0, 1) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            extraSpeed *= decay;
            transform.Rotate(-1 * (baseRotateSpeed + extraSpeed) * new Vector3(0, 0, 1) * Time.deltaTime);
        }

        transform.position += moveSpeed * transform.up * Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponentInChildren<Fuel>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponentInChildren<Fuel>().enabled = true;
        }




    }
}
