using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] RectTransform fillTransform;
    [SerializeField] ScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fillTransform.localScale = new Vector3 (scoreKeeper.firemanScore, 1 , 1);
    }

}
