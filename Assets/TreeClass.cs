using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClass : MonoBehaviour
{
    public GameObject tree;
    public bool onFire;


    // Start is called before the first frame update
    void Start()
    {
        tree = GameObject.Find("Tree");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
