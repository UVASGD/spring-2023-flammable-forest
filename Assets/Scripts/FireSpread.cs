using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour
{

    private SpriteRenderer sr;

    public float aReduction = 0.001f;
    public float lifeTime = 3f;
    GameObject tree;

    private float lifeStart;

    bool justLit;
    bool onFire;
    bool putOut;


    // Start is called before the first frame update
    void Start()
    {

        sr = GetComponent<SpriteRenderer>();
        lifeStart = Time.time;
        tree = GameObject.FindGame
    }

    // Update is called once per frame
    void Update()
    {
        void
        if(collision.gameObject.name == "Arsonist"){
            onFire = true;
        }
        if (Time.time >= lifeStart + lifeTime)
        {
            Destroy(gameObject);
        }
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.g, sr.color.a - aReduction);
    }
}
