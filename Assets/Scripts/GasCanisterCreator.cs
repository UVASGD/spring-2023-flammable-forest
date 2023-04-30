using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCanisterCreator : MonoBehaviour
{
    public int maxGasCanisters = 7;
    public GameObject gasCan;
    public float top = 115f, bottom = 0f, left = 0f, right = 193f;
    public float spawnChance = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentsInChildren<Transform>().Length < maxGasCanisters && Random.Range(0f,1f) < spawnChance)
        {
            Vector3 rand = new Vector3(0,0,0);
            rand.y = Random.Range(bottom, top);
            rand.x = Random.Range(left, right);
            GameObject g = Instantiate(gasCan, gameObject.transform.position + rand, Quaternion.identity);
            g.transform.parent = gameObject.transform;
        }
    }
}
