using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCollider : MonoBehaviour
{
    private char type;
    private Fuel parentFuel;

    // Start is called before the first frame update
    void Start()
    {
        parentFuel = gameObject.GetComponentInParent<Fuel>();

        //set type
        Collider2D col = GetComponent<Collider2D>();
        if (col.GetType() == typeof(BoxCollider2D)) type = 'b';
        else if (col.GetType() == typeof(CircleCollider2D)) type = 'c';
        else type = 'n';
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Fuel") return;
        if (collision.gameObject.transform.parent == transform.parent) return;
        //notify if collided with a fuel collider
        parentFuel.enterCollision(type, collision.gameObject.transform.parent.gameObject.GetComponent<Fuel>(),
            collision.gameObject.GetComponent<FuelCollider>().type);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //same as on enter
        if (collision.gameObject.tag != "Fuel") return;
        if (collision.gameObject.transform.parent == transform.parent) return;
        //notify if collided with a fuel collider
        parentFuel.enterCollision(type, collision.gameObject.transform.parent.gameObject.GetComponent<Fuel>(),
            collision.gameObject.GetComponent<FuelCollider>().type);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Fuel") return;
        if (collision.gameObject.transform.parent == transform.parent) return;
        //notify if collided with a fuel collider
        parentFuel.exitCollision(type, collision.gameObject.transform.parent.gameObject.GetComponent<Fuel>(),
            collision.gameObject.GetComponent<FuelCollider>().type);
    }
}
