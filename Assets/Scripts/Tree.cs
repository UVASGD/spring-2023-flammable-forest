using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private int state;
    private Animator anim;
    private Fuel fuel;
    private Sparks sparks1, sparks2;

    bool sparksOn = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fuel = GetComponent<Fuel>();
        sparks1 = GetComponentsInChildren<Sparks>()[0];
        sparks2 = GetComponentsInChildren<Sparks>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        int oldState = state;
        if (fuel.burning && !fuel.burnedOut) state = 1;
        else if (fuel.burning && fuel.burnedOut) state = 2;
        else if (!fuel.burning && fuel.burnedOut) state = 3;
        else state = 0;
        if (state != oldState) anim.SetInteger("State", state);

        checkSparkState();

    }

    private void checkSparkState()
    {
        if (fuel.burning && !sparksOn)
        {
            sparks1.play();
            sparks2.play();
            sparksOn = true;
        }
        else if (!fuel.burning && sparksOn)
        {
            sparks1.stop();
            sparks2.stop();
            sparksOn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 4)
            {
                fuel.putOut();
            }
    }

}
