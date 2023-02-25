using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClass : MonoBehaviour
{
    public GameObject tree;
    public bool onFire;
    public bool putOut;

    public float burnTimer = 0f;
    public float burnTime = 2f;

    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        tree = GameObject.Find("Tree");
        sr = tree.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        burnTimer += Time.deltaTime;
        if (burnTimer > burnTime)
        {
            extinguish();
        }

        if (onFire)
        {
            sr.color = Color.red;
        }

        if(putOut)
        {
            sr.color = Color.blue;
        }
    }

    private void extinguish()
    {
        if (burnTimer > burnTime)
        {
            onFire = false;
            putOut = true;
        }
    }
}
