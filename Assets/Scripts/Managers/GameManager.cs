using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{

    public int score = 0;
    public int diamonds = 0;
    public int diamondsPlus = 0;
    public int highScore = 0;
    public bool isSecondChance = true;
    public int isRemoveAds = 0;
    public PlayerMotor playerMotor = null;

    [HideInInspector] public bool isNewBest = false;
   /* [HideInInspector]*/ public bool isPlay = false;
 
    [SerializeField] private bool deleteSave = false;



    // Use this for initialization
    void Start()
    {
        if (deleteSave)
        {
            PlayerPrefs.DeleteAll();
        }
        AdsManager.Instance.LoadInterstitialAds();
        AdsManager.Instance.LoadRewardAds();
        if (diamonds==0)
        {
            diamonds = PlayerPrefs.GetInt("Diamond", 0);
        }
        else
        {
            diamonds = PlayerPrefs.GetInt("Diamond", 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
       // ChangeSpeed();

    }

    void ChangeSpeed()
    {
        int scoreInit = 10;
        int scoreAdd = 10;
        float speedInit = 3.0f;
        float speedAdd = 1.0f;
        //playerMotor.speed = 3.0f;
        if (score < scoreInit)
        {
            playerMotor.speed = speedInit;

        }
        else if (scoreInit <= score && score < scoreInit+ scoreAdd)
        {
            playerMotor.speed = speedInit+speedAdd;
        }
        else if (scoreInit + scoreAdd <= score && score < scoreInit + scoreAdd*2)
        {
            playerMotor.speed = speedInit + speedAdd*2;
        }
        else if (scoreInit + scoreAdd * 2 <= score && score < scoreInit + scoreAdd * 3)
        {
            playerMotor.speed = speedInit + speedAdd*3;
        }
        else if (scoreInit + scoreAdd * 3 <= score && score < scoreInit + scoreAdd * 4)
        {
            playerMotor.speed = speedInit + speedAdd*4;
        }
        else if (scoreInit + scoreAdd * 4 <= score && score < scoreInit + scoreAdd * 5)
        {
            playerMotor.speed = speedInit + speedAdd*5;
        }
        else if (scoreInit + scoreAdd * 5 <= score)
        {
            playerMotor.speed = speedInit + speedAdd*5.5f;

        }

    }

    public void SetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);  
            isNewBest = true;
        }
    }

    public void SetDiamond()
    {
        PlayerPrefs.SetInt("Diamond", diamonds);
    }

    





}
