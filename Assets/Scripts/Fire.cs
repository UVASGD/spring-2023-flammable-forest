using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    private SpriteRenderer sr;

    public float aReduction = 0.001f;
    public float lifeTime = 3f;

    private float lifeStart;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        lifeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lifeStart + lifeTime)
        {
            Destroy(gameObject);
        }
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.g, sr.color.a - aReduction);
    }
}
