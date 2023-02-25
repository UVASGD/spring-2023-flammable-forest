using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireSpread : MonoBehaviour
{

    //private SpriteRenderer sr;

    public float aReduction = 0.001f;
    public float lifeTime = 3f;

    

    private float lifeStart;


    // Start is called before the first frame update
    void Start()
    {

        //sr = GetComponent<SpriteRenderer>();
        lifeStart = Time.time;
        
  
    }

    // Update is called once per frame
    void Update()
    {
        
        
        /*if (Time.time >= lifeStart + lifeTime)
        {
            Destroy(gameObject);
        }*/
        //sr.color = new Color(sr.color.r, sr.color.g, sr.color.g, sr.color.a - aReduction);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        setFire(collider);  
    }


    private void setFire(Collider2D collider)
    {
        if (collider.gameObject.tag == "Tree")
        {
            collider.gameObject.GetComponent<TreeClass>().onFire = true;
            collider.gameObject.GetComponent<TreeClass>().burnTimer = 0;
        }
    }
    
}
