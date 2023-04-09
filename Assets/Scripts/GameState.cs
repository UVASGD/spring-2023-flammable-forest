    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    [SerializeField] Timer gameTimer;
    [SerializeField] ScoreKeeper scoreKeeper;

    [SerializeField] TMP_Text roundResultsText;
    // Start is called before the first frame update
    void Start()
    {
        gameTimer.timeUpAction += EndRound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndRound(){
        Time.timeScale = 0;
        DisplayRoundResults();
    }

    void DisplayRoundResults(){
        // Add UI or effects wanted to show when the round ends here
        bool firemanWon = scoreKeeper.FiremanIsWinning();
        roundResultsText.text = (firemanWon) ? "FIREMAN WINS" : "ARSONIST WINS";
        roundResultsText.color = (firemanWon) ? Color.blue : Color.red;
        roundResultsText.gameObject.SetActive(true);
    }
}
