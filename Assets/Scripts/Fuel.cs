using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;

public class Fuel : MonoBehaviour
{
    public bool burning = false;
    private float timeBurned = 0;
    public bool burnedOut = false;
    public float lifetime = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (burning)
        {
            timeBurned += Time.deltaTime;
            if (timeBurned > lifetime)
            {
                burnedOut = true;
                //burning = false;
            }
        }
    }

    public void catchFire()
    {
        if (burnedOut) return;
        burning = true;
    }

    public void putOut()
    {
        burning = false;
    }

}
