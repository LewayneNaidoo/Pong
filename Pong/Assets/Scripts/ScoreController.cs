using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    private int scoreP1 = 0;
    private int scoreP2 = 0;

    public GameObject scoreTextP1;
    public GameObject scoreTextP2;

    public int goalToWin;

    void Update()
    {
        if (this.scoreP1 >= this.goalToWin || this.scoreP2 >= this.goalToWin)
        {
            Debug.Log("Game Won");
            SceneManager.LoadScene(2);
        }
    }

    private void FixedUpdate()
    {
        Text uiScoreP1 = this.scoreTextP1.GetComponent<Text>();
        uiScoreP1.text = this.scoreP1.ToString();

        Text uiScoreP2 = this.scoreTextP2.GetComponent<Text>();
        uiScoreP2.text = this.scoreP2.ToString();
    }

    public void GoalPlayer1() { this.scoreP1++; }

    public void GoalPlayer2() { this.scoreP2++; }

}
