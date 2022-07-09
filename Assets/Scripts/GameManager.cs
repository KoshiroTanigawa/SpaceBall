using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int life;
    public GameObject ballPrefab;
    public GameObject restartButton;
    public Button restart;
    public Text gameover;
    //public Canvas canvas1;
    public Canvas canvas2;
    private int score;
    public float leftTime;
    private Text textScore;
    private Text textLife;
    private Text textTimer;
    public Text textClear;
    private bool inGame;

    private AudioSource audioSource;
    public AudioClip overSound;
    public AudioClip clearSound;


    void Start()
    {
        life = 3;
        restart.enabled = false;
        gameover.enabled = false;
        //canvas1.enabled = false;
        textClear.enabled = false;
        score = 0;
        textScore = GameObject.Find("Score").GetComponent<Text>();
        textLife = GameObject.Find("BallLife").GetComponent<Text>();
        textTimer = GameObject.Find("TimeText").GetComponent<Text>();
        audioSource = gameObject.AddComponent<AudioSource>();
        SetScoreText(score);
        SetLifeText(life);
        inGame = true;
        restartButton.SetActive(false);
    }

    private void SetScoreText(int score)
    {
        textScore.text = "Score:" + score.ToString();
    }

    public void AddScore(int point)
    {
        if (inGame)
        {
            score += point;
            SetScoreText(score);
        }
    }

    private void SetLifeText(int life)
    {
        textLife.text = "Ball :" + life.ToString();
    }

    public bool IsInGame()
    {
        return inGame;
    }

    void Update()
    {
        if (inGame)
        {
            GameObject targetObj = GameObject.FindWithTag("Target");
            if (targetObj == null)
            {
                audioSource.PlayOneShot(clearSound);
                textClear.enabled = true;
                inGame = false;
            }

            leftTime -= Time.deltaTime;
            textTimer.text = "Time :" + (leftTime > 0f ? leftTime.ToString("0.00") : "0.00");

            if (leftTime < 0f)
            {
                audioSource.PlayOneShot(overSound);
                restartButton.SetActive(true);
                restart.enabled = true;
                gameover.enabled = true;
                //canvas1.enabled = true;
                canvas2.enabled = false;
                inGame = false;
            }

            GameObject ballObj = GameObject.Find("Ball");
            if (ballObj == null)
            {
                --life;
                SetLifeText(life);

                if (life > 0)
                {
                    GameObject newBall = Instantiate(ballPrefab);
                    newBall.name = ballPrefab.name;
                }

                else
                {
                    audioSource.PlayOneShot(overSound);
                    life = 0;
                    restartButton.SetActive(true);
                    restart.enabled = true;
                    gameover.enabled = true;
                    //canvas1.enabled = true;
                    canvas2.enabled = false;
                    inGame = false;
                }
            }
        }
    }
}
