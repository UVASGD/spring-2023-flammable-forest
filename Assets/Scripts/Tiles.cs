using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    // Start is called before the first frame update
    private double myX;
    private double myY;
    public Tiles(double x, double y){
        myX = x;
        myY = y;
        this.transform.position = new Vector3((float)myX, (float)myY, 0.0f);
        //https://www.youtube.com/watch?v=qJ0-xhxZUJQ&ab_channel=SoomeenHahmDesign
    }

    void Start()
    {
        this.transform.position = new Vector3((float)myX, (float)myY, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
