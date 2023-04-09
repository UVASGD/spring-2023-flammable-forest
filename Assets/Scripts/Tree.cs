using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private int state;
    private Animator anim;
    private Fuel fuel;
    public int contacts;

    public bool burning => fuel.burning; 


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fuel = GetComponentInChildren<Fuel>();
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

        contacts = fuel.boxToBoxContacts.Count + fuel.circleToBoxContacts.Count + fuel.circleToCircleContacts.Count;
    }

}
