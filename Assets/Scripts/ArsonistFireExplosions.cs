using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArsonistFireExplosions : MonoBehaviour
{

    private ParticleSystem ps;
    private WaterTank gasTank;
    public float depletionRate;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        gasTank = transform.parent.gameObject.GetComponent<WaterTank>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && gasTank.currentTank > 0)
        {
            ps.Play();
            gasTank.DepleteTank(depletionRate);
        }
    }
}
