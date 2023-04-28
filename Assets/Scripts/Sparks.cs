using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparks : MonoBehaviour
{
    [SerializeField] float fireProbability = 0.05f;
    private ParticleSystem ps;

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
        if (Random.Range(0f,1f) < fireProbability)  //burnable
        {
            other.GetComponentInChildren<Fuel>().catchFire();
        }

    }


}
