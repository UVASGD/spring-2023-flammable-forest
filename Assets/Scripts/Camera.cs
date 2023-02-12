using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.transform.position + new Vector3(0,0,-10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * (target.transform.position - transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
