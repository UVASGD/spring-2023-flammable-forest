using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    public float runningSpeed = 2f;
    public Rigidbody2D playerBody;

    void Update ()
    {
        if(Input.GetKey("d"))
        {
            moveRight();
        }
        else if (Input.GetKey("a"))
        {
            moveLeft();
        }
        else if(Input.GetKey("w"))
        {
            moveUp();
        }
        else if (Input.GetKey("s"))
        {
            moveDown();
        }
    }

    private void moveLeft()
    {
        playerBody.AddForce(Vector2.left * (runningSpeed * Time.deltaTime), ForceMode2D.Force);
    }

    private void moveRight()
    {
        playerBody.AddForce(Vector2.right * (runningSpeed*Time.deltaTime), ForceMode2D.Force);
    }

    private void moveUp()
    {
        playerBody.AddForce(Vector2.up * (runningSpeed * Time.deltaTime), ForceMode2D.Force);
    }

    private void moveDown()
    {
        playerBody.AddForce(Vector2.down * (runningSpeed*Time.deltaTime), ForceMode2D.Force);
    }
}
