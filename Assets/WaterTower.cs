using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTower : MonoBehaviour
{
    [Tooltip("Value of 1 will take 1 second to fully fill the tank")]
    [SerializeField] float secondsToFill = 1;
    WaterTank currentWaterTank = null;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<WaterTank>(out WaterTank waterTank))
        {
            currentWaterTank = waterTank;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<WaterTank>(out WaterTank waterTank))
        {
            if (currentWaterTank == waterTank) 
                currentWaterTank = null;
        }
    }

    void Update() {
        if (currentWaterTank != null)
            currentWaterTank.FillTank(Time.deltaTime/secondsToFill);
    }
}
