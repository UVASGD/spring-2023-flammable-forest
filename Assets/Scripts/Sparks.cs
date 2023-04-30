using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparks : MonoBehaviour
{
    [SerializeField] float fireProbability;
    private ParticleSystem ps;
    public GameObject explosion;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void play()
    {
        ps.Play();
    }

    public void stop()
    {
        ps.Stop();
    }

    private void OnParticleCollision(GameObject other)
    {
        // filters in particle settings
        if (other.layer == 6 && Random.Range(0f,1f) < fireProbability)  //burnable
        {
            other.GetComponentInChildren<Fuel>().catchFire();
        }

        Debug.Log(other.tag);

        if (other.layer == 9)  //gasoline
        {
            Debug.Log("here");
            Instantiate(explosion);
        }

    }


}
