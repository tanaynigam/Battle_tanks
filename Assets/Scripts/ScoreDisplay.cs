using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {
    public static int score1;
    public static int score2;
    
    private float RemainingTime;
    private bool gameover = false;
    
    // Use this for initialization
    void Start () {
        score1 = 0;
        score2 = 0;
        RemainingTime = 120f;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameover == false)
        {
            TextMesh score1_display = GameObject.Find("Score1").GetComponent<TextMesh>();
            score1_display.text = "Red Tank's\nScore:\n  " + score1 + "\nTime:\n  " + Mathf.Ceil(RemainingTime);

            TextMesh score2_display = GameObject.Find("Score2").GetComponent<TextMesh>();
            score2_display.text = "Blue Tank's\nScore:\n  " + score2 + "\nTime:\n  " + Mathf.Ceil(RemainingTime);

            RemainingTime -= Time.deltaTime;

            if (RemainingTime < 0)
            {
                gameover = true;
                GameOver();
            }
        }
    }

    void GameOver()
    {
        if (score1 > score2)
        {
            TextMesh score1_display = GameObject.Find("Score1").GetComponent<TextMesh>();
            score1_display.text = "Red Tank\nWins!!";

            TextMesh score2_display = GameObject.Find("Score2").GetComponent<TextMesh>();
            score2_display.text = "Red Tank\nWins";
        }
        else if (score1 < score2)
        {
            TextMesh score1_display = GameObject.Find("Score1").GetComponent<TextMesh>();
            score1_display.text = "Blue Tank\nWins!!";

            TextMesh score2_display = GameObject.Find("Score2").GetComponent<TextMesh>();
            score2_display.text = "Blue Tank\nWins";
        }
        else
        {
            TextMesh score1_display = GameObject.Find("Score1").GetComponent<TextMesh>();
            score1_display.text = "Its a\nDraw!!";

            TextMesh score2_display = GameObject.Find("Score2").GetComponent<TextMesh>();
            score2_display.text = "Its a\nDraw!!";
        }
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
       

        yield return new WaitForSeconds(5f);
        gameover = false;
        score1 = 0;
        score2 = 0;
        RemainingTime = 120f;
        GameObject tank1 = GameObject.Find("tank_1");
        GameObject tank2 = GameObject.Find("tank_2");
        tank1.transform.position = new Vector3(0, 0.5f, -10f);
        tank1.transform.eulerAngles = new Vector3(0, 180, 0);
        tank2.transform.position = new Vector3(0, 0.5f, 10f);
        tank2.transform.eulerAngles = new Vector3(0, 0, 0);
        
    }
}
