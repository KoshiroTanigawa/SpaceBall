using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int _life;
    private int _score;
    public float _leftTime;
    static int _highScore = 0;

    public GameObject _ballPrefab;
    public GameObject _restartButton;
    public GameObject _menuButton;
    public GameObject _NextButton;

    public Button _restart;

    [SerializeField] Text _textGameover;
    [SerializeField] Text _textClear;

    [SerializeField] Text _textScore;
    [SerializeField] Text _textLife;
    [SerializeField] Text _textTimer;

    [SerializeField] Text _textResultScore;
    [SerializeField] Text _textResultBall;
    [SerializeField] Text _textResultTime;
    [SerializeField] Text _textResultTotal;
    [SerializeField] Text _textHighScore;

    bool _inGame;

    private AudioSource audioSource;
    public AudioClip overSound;
    public AudioClip clearSound;


    void Start()
    {
        _inGame = true;

        _restart.enabled = false;
        _textGameover.enabled = false;
        _textClear.enabled = false;
        _textResultScore.enabled = false;
        _textResultBall.enabled = false;
        _textResultTime.enabled = false;
        _textResultTotal.enabled = false;
        _textHighScore.enabled = false;

        _score = 0;

        audioSource = gameObject.AddComponent<AudioSource>();

        SetScoreText(_score);
        SetLifeText(_life);
        SetHighScoreText(_highScore);

        _restartButton.SetActive(false);
        _NextButton.SetActive(false);

        _textScore = GameObject.Find("Score").GetComponent<Text>();
        _textLife = GameObject.Find("BallLife").GetComponent<Text>();
        _textTimer = GameObject.Find("TimeText").GetComponent<Text>();
        _textResultScore = GameObject.Find("ResultScore").GetComponent<Text>();
        _textResultBall = GameObject.Find("ResultBall").GetComponent<Text>();
        _textResultTime = GameObject.Find("ResultTime").GetComponent<Text>();
        _textResultTotal = GameObject.Find("ResultTotal").GetComponent<Text>();
        _textHighScore = GameObject.Find("HighScore").GetComponent<Text>();

    }

    private void SetHighScoreText(int highScore)
    {
        _textHighScore.text = "High Score:" + highScore.ToString();
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

                int scorePoint = _score * 2;
                int scoreBall = _life * 1000; // スコア計算
                int scoreTime = (int)(_leftTime * 100f); // 少数値を整数型に直します ( スコア計算
                _textResultScore.text = "Score * 2 = " + scorePoint.ToString(); // 表示
                _textResultBall.text = "Ball * 1000 = " + scoreBall.ToString(); // 表示
                _textResultTime.text = "Time * 100 = " +scoreTime.ToString(); // 表示

                int totalScore = scorePoint + scoreBall + scoreTime; // トータル計算
                _textResultTotal.text = "Total Score :" + totalScore.ToString();

                if (_highScore < totalScore) // 過去のハイスコアの値を上回っていたら
                {
                    _highScore = totalScore; // ハイスコアを更新します（表示は次回のプレイ時から）
                }

                _NextButton.SetActive(true);
                _restartButton.SetActive(true);
                _restart.enabled = true;
                _textClear.enabled = true;
                _textResultScore.enabled = true;
                _textResultBall.enabled = true;
                _textResultTime.enabled = true;
                _textResultTotal.enabled = true;
                _textHighScore.enabled = true;
                _inGame = false;
            }

            _leftTime -= Time.deltaTime;
            _textTimer.text = "Time :" + (_leftTime > 0f ? _leftTime.ToString("0.00") : "0.00");

            if (_leftTime < 0f)
            {
                audioSource.PlayOneShot(overSound);
                _restartButton.SetActive(true);
                _restart.enabled = true;
                _textGameover.enabled = true;
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
                    _textGameover.enabled = true;
                    _inGame = false;
                }
            }
        }
    }

    public void OnClickMenuButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnClickRetryButton()
    {
        SceneManager.LoadScene("MainScene1");
    }

    public void OnClickNextButton()
    {
        SceneManager.LoadScene("MainScene1");
    }
}
