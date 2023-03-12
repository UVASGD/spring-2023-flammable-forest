using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;

public class Fuel : MonoBehaviour
{
    public bool burning = false;
    private float timeBurned = 0;
    public bool burnedOut = false;
    public float spreadHighChance = 0.2f, spreadMidChance = 0.02f, spreadLowChance = 0.002f;
    public float lifetime = 50;

    //it would be inefficient to use onTriggerStay2D, instead store all contacts in a list
    //only refer to this fuels contacts with other fuels boxes, the other fuels circle doesn't affect transmission
    public ArrayList circleToBoxContacts, boxToBoxContacts, circleToCircleContacts;

    // Start is called before the first frame update
    void Start()
    {
        circleToBoxContacts = new ArrayList();
        boxToBoxContacts = new ArrayList();
        circleToCircleContacts = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        transmitFire();
        if (burning)
        {
            timeBurned += Time.deltaTime;
            if (timeBurned > lifetime)
            {
                burnedOut = true;
            }
        }
    }

    private void transmitFire()
    {
        //only transmit fire if the tree is burning
        if (!burning) return;

        foreach (Fuel f in boxToBoxContacts)
        {
            if (f.burning || f.burnedOut) return;
            if (Random.Range(0f, 1f) < spreadHighChance * Time.deltaTime) f.catchFire();
        }
        foreach (Fuel f in circleToBoxContacts)
        {
            if (f.burning || f.burnedOut) return;
            if (Random.Range(0f, 1f) < spreadMidChance * Time.deltaTime) f.catchFire();
        }
        foreach (Fuel f in circleToCircleContacts)
        {
            if (f.burning || f.burnedOut) return;
            if (Random.Range(0f, 1f) < spreadLowChance * Time.deltaTime) f.catchFire();
        }
    }

    public void enterCollision(char myType, Fuel col, char colType)
    {
        if (myType == 'b' && colType == 'b' && !boxToBoxContacts.Contains(col)) boxToBoxContacts.Add(col);
        if (myType == 'c' && colType == 'b' && !circleToBoxContacts.Contains(col)) circleToBoxContacts.Add(col);
        if (myType == 'c' && colType == 'c' && !circleToCircleContacts.Contains(col)) circleToCircleContacts.Add(col);
    }

    public void exitCollision(char myType, Fuel col, char colType)
    {
        if (myType == 'b' && colType == 'b') boxToBoxContacts.Remove(col);
        if (myType == 'c' && colType == 'b') circleToBoxContacts.Remove(col);
        if (myType == 'c' && colType == 'c') circleToCircleContacts.Remove(col);
    }

    public void catchFire()
    {
        burning = true;
    }

    public void putOut()
    {
        burning = false;
    }
}
