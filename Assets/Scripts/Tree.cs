using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private int state;
    private Animator anim;
    private Fuel fuel;
    private bool burnedDown;

    public int contacts;

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
        state = 0;
        if (fuel.burning && !burnedDown) state = 1;
        if (fuel.burning && burnedDown) state = 2;
        if (!fuel.burning && burnedDown) state = 3;
        if (state != oldState) anim.SetInteger("State", state);

        contacts = fuel.boxToBoxContacts.Count + fuel.circleToBoxContacts.Count + fuel.circleToCircleContacts.Count;
    }

}
