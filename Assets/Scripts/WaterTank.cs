using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTank : MonoBehaviour
{
    [SerializeField] RectTransform waterFillTransform;
    // LOGIC
    public float tankCapacity = 1f;
    public float currentTank = 0;
    float percentageFilled => currentTank / tankCapacity;

    void Start(){
        UpdateTankUI();
    }
    
    public void FillTank(float fillAmount) {
        currentTank = Mathf.Min(tankCapacity, currentTank + fillAmount);
        UpdateTankUI();
    }

    public bool DepleteTank(float depletionAmount) {
        if (currentTank == 0) return false;

        currentTank = Mathf.Max(0, currentTank - depletionAmount);
        UpdateTankUI();
        return true;
    }

    // UI
    public void UpdateTankUI(){
        waterFillTransform.localScale = new Vector3 (1,  percentageFilled, 1);
    }

}
