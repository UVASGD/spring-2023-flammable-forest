using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClass : MonoBehaviour
{
    public GameObject tree;
    public bool alive;
    public bool onFire;
    public bool putOut;
    public bool dead;
    

    public float burnTimer = 0f;
    //public float burnTime = 3f;
    public float aliveTime = 2f;
    //public float deadTime = 2f;

    

    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        tree = GameObject.Find("Tree");
        sr = tree.GetComponent<SpriteRenderer>();
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        burnTimer += Time.deltaTime;
        if (onFire && burnTimer > aliveTime)
        {
            alive = false;
            dead = true;
        }

        if (alive)
        {
            sr.color = Color.green;
            //points go to firefighter
        }


        if (onFire)
        {
            sr.color = Color.red;
        }

        if(dead)
        {
            sr.color = Color.grey;
            //points go to arsonist
        }
    }

}
