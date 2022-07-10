using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int _life;
    public GameObject _ballPrefab;
    public GameObject _restartButton;
    public Button _restart;
    public Text _gameover;
    public Canvas _canvas2;
    private int _score;
    public float _leftTime;
    private Text _textScore;
    private Text _textLife;
    private Text _textTimer;
    public Text _textClear;
    private bool _inGame;

    private AudioSource audioSource;
    public AudioClip overSound;
    public AudioClip clearSound;


    void Start()
    {
        _restart.enabled = false;
        _gameover.enabled = false;
        _textClear.enabled = false;
        _score = 0;
        _textScore = GameObject.Find("Score").GetComponent<Text>();
        _textLife = GameObject.Find("BallLife").GetComponent<Text>();
        _textTimer = GameObject.Find("TimeText").GetComponent<Text>();
        audioSource = gameObject.AddComponent<AudioSource>();
        SetScoreText(_score);
        SetLifeText(_life);
        _inGame = true;
        _restartButton.SetActive(false);
    }

    private void SetScoreText(int score)
    {
        _textScore.text = "Score:" + score.ToString();
    }

    public void AddScore(int point)
    {
        if (_inGame)
        {
            _score += point;
            SetScoreText(_score);
        }
    }

    private void SetLifeText(int life)
    {
        _textLife.text = "Ball :" + life.ToString();
    }

    public bool IsInGame()
    {
        return _inGame;
    }

    void Update()
    {
        if (_inGame)
        {
            GameObject targetObj = GameObject.FindWithTag("Target");
            if (targetObj == null)
            {
                audioSource.PlayOneShot(clearSound);
                _textClear.enabled = true;
                _inGame = false;
            }

            _leftTime -= Time.deltaTime;
            _textTimer.text = "Time :" + (_leftTime > 0f ? _leftTime.ToString("0.00") : "0.00");

            if (_leftTime < 0f)
            {
                audioSource.PlayOneShot(overSound);
                _restartButton.SetActive(true);
                _restart.enabled = true;
                _gameover.enabled = true;
                //canvas1.enabled = true;
                _canvas2.enabled = false;
                _inGame = false;
            }

            GameObject ballObj = GameObject.Find("Ball");
            if (ballObj == null)
            {
                --_life;
                SetLifeText(_life);

                if (_life > 0)
                {
                    GameObject newBall = Instantiate(_ballPrefab);
                    newBall.name = _ballPrefab.name;
                }

                else
                {
                    audioSource.PlayOneShot(overSound);
                    _life = 0;
                    _restartButton.SetActive(true);
                    _restart.enabled = true;
                    _gameover.enabled = true;
                    //canvas1.enabled = true;
                    _canvas2.enabled = false;
                    _inGame = false;
                }
            }
        }
    }
}
