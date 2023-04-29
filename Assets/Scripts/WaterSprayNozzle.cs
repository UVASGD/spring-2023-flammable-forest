using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSprayNozzle : MonoBehaviour
{
    [SerializeField] WaterTank waterTank;
    [SerializeField] ParticleSystem particleSys;

    [Tooltip("Spray Rate is percentage per second. 100 will depelete entire tank in 1 second. 20 will deplete 20% every second")]
    [Range(1, 100)]
    [SerializeField] float sprayRate = 1;
    public bool nozzleOpen {get; private set;} = false;


    void Update()
    {
        if (nozzleOpen){
            float depletionAmount = (sprayRate/100) * Time.deltaTime;
            if (waterTank.DepleteTank(depletionAmount)) {
                PlayParticles();
            }
            else {
                CloseSprayNozzle();
            }

        }
    }

    public void OpenSprayNozzle() {
        nozzleOpen = true;
    }

    public void CloseSprayNozzle() {
        nozzleOpen = false;
        StopParticles();
    }

    void PlayParticles(){
        particleSys.Play();
    }

    void StopParticles(){
        particleSys.Stop();
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.TryGetComponent<Fuel>(out Fuel fuel)) 
            fuel.putOut();

    }
}
