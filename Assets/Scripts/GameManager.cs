using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource[] soundEffects;
    public AudioSource laserSoundEffect;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreLabelText;

    public float playTime;
    public float seconds;
    public const float soundConstant = 1f;

    public bool isFinished;

    public int dividedScore;

    public CubePath cubePath;
    public MoveBoxes moveBoxes;
    public CheckCollision collisionChecker;
    // Start is called before the first frame update
    void Start()
    {
        moveBoxes = GameObject.FindGameObjectWithTag("Enemy").GetComponent<MoveBoxes>();
        cubePath = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CubePath>();
        collisionChecker = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CheckCollision>();

        InvokeRepeating("PlaySound", 0, 0.04f);

        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        scoreLabelText = GameObject.Find("ScoreLabel").GetComponent<TextMeshProUGUI>();

        soundEffects = GetComponents<AudioSource>();

        InvokeRepeating("ChangeScoreText", 0, 0.2f);
        playTime = 60f;
        seconds = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

        soundEffects[0].pitch = 7.5f - (soundConstant * Mathf.Abs(moveBoxes.errorFloat) * 0.7f);
    }

    void ChangeScoreText()
    { 



        if (cubePath.flag == 0)
        {
            scoreLabelText.text = "Score";
            dividedScore = Mathf.RoundToInt(moveBoxes.totalScore / 10);
            //int roundedInt = Convert.ToInt32(dividedScore);
            
            scoreText.text = moveBoxes.totalScore.ToString("0");
        } else if (cubePath.flag == 1)
        {
            scoreLabelText.text = "Finished.";
        }

        

    }

    void PlaySound()
    {
        if (cubePath.flag == 0)
        {

            if (collisionChecker.laserTriggered)
            {
                soundEffects[1].Play();
            }
            else
            {
                soundEffects[1].Stop();
            }
            soundEffects[0].Play();

        }


    }
}
