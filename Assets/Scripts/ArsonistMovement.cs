using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArsonistMovement : MonoBehaviour
{
    public float rotateSpeed = 1, moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Fuel>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(rotateSpeed * new Vector3(0, 0, 1) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-1 * rotateSpeed * new Vector3(0, 0, 1) * Time.deltaTime);
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
