using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EasyMobile;

public class UIFinish : MonoBehaviour
{

    [SerializeField] private GameObject finishGame = null;
    [SerializeField] private GameObject secondChange = null;
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private MapBuilder createMap = null;
    [SerializeField] private EffectManager effectManager = null;
    [SerializeField] private Image rank = null;
    [SerializeField] private Image[] miniBestRank = null;
    [SerializeField] private Sprite[] ranksType = null;
    [SerializeField] private Button restartBT = null;
    [SerializeField] private TextMeshProUGUI highScoreText = null;
    [SerializeField] private TextMeshProUGUI countDiamondStart = null;
    [SerializeField] private TextMeshProUGUI countDiamondFinish = null;
    [SerializeField] private TextMeshProUGUI countDiamondPlus = null;

    private int scoreInit = 15;
    private int scoreAdd = 15;
    private UIStart uIStart = null;
    private Animator animator = null;
    private UIController uiController = null;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        uIStart = GetComponent<UIStart>();
        uiController = GetComponent<UIController>();
        SetDiamondStart();
    }




    public void SecondChange()
    {
        secondChange.SetActive(true);
        animator.Play("SecondChange");
    }

    public void FinishGame(float timeDelayDie)
    {
        AdsManager.Instance.LoadInterstitialAds();
        AdsManager.Instance.LoadRewardAds();
        GameManager.Instance.SetHighScore();
        GameManager.Instance.SetDiamond();
        PlayerDeadDelay(timeDelayDie);
    }

    public void DeletePlayerDead()
    {
        CancelInvoke("PlayerDead");
    }

    public void PlayerDeadDelay(float timeDelayDie)
    {
        if (GameManager.Instance.isNewBest)
        {
            highScoreText.text = "New Best " + PlayerPrefs.GetInt("HighScore");
            GameManager.Instance.isNewBest = false;
        }
        else
        {
            highScoreText.text = "Best " + PlayerPrefs.GetInt("HighScore");
        }
        SetRank();
        SetMiniBestRank();
        ReportScore();
        Invoke("PlayerDead", timeDelayDie);
    }

    void ReportScore()
    {
        if (GameServiceManager.IsInitialized())
        {
            GameServiceManager.ReportScore(GameManager.Instance.score, EM_GameServiceConstants.Leaderboard_leaderboard);
        }
    }

    void SetRank()
    {

        if (GameManager.Instance.score < scoreInit)
        {
            rank.sprite = ranksType[0];
            GameServiceManager.UnlockAchievement(EM_GameServiceConstants.Achievement_one);
        }
        else if (scoreInit <= GameManager.Instance.score && GameManager.Instance.score < scoreInit + scoreAdd)
        {
            rank.sprite = ranksType[1];
            GameServiceManager.UnlockAchievement(EM_GameServiceConstants.Achievement_two);
        }
        else if (scoreInit + scoreAdd <= GameManager.Instance.score && GameManager.Instance.score < scoreInit + scoreAdd * 2)
        {
            rank.sprite = ranksType[2];
            GameServiceManager.UnlockAchievement(EM_GameServiceConstants.Achievement_three);
        }
        else if (scoreInit + scoreAdd * 2 <= GameManager.Instance.score && GameManager.Instance.score < scoreInit + scoreAdd * 3)
        {
            rank.sprite = ranksType[3];
            GameServiceManager.UnlockAchievement(EM_GameServiceConstants.Achievement_four);
        }
        else if (scoreInit + scoreAdd * 3 <= GameManager.Instance.score && GameManager.Instance.score < scoreInit + scoreAdd * 4)
        {
            rank.sprite = ranksType[4];
            GameServiceManager.UnlockAchievement(EM_GameServiceConstants.Achievement_five);
        }
        else if (scoreInit + scoreAdd * 4 <= GameManager.Instance.score && GameManager.Instance.score < scoreInit + scoreAdd * 5)
        {
            rank.sprite = ranksType[5];
            GameServiceManager.UnlockAchievement(EM_GameServiceConstants.Achievement_six);
        }
        else if (scoreInit + scoreAdd * 5 <= GameManager.Instance.score)
        {
            rank.sprite = ranksType[6];
            GameServiceManager.UnlockAchievement(EM_GameServiceConstants.Achievement_seven);
        }

    }

    void SetMiniBestRank()
    {
        int bestScore = PlayerPrefs.GetInt("HighScore");
        if (bestScore < scoreInit)
        {
            miniBestRank[0].sprite = ranksType[0];
            miniBestRank[1].sprite = ranksType[0];
        }
        else if (scoreInit <= bestScore && bestScore < scoreInit + scoreAdd)
        {
            miniBestRank[0].sprite = ranksType[1];
            miniBestRank[1].sprite = ranksType[1];
        }
        else if (scoreInit + scoreAdd <= bestScore && bestScore < scoreInit + scoreAdd*2)
        {
            miniBestRank[0].sprite = ranksType[2];
            miniBestRank[1].sprite = ranksType[2];
        }
        else if (scoreInit + scoreAdd*2 <= bestScore && bestScore < scoreInit + scoreAdd*3)
        {
            miniBestRank[0].sprite = ranksType[3];
            miniBestRank[1].sprite = ranksType[3];
        }
        else if (scoreInit + scoreAdd*3 <= bestScore && bestScore < scoreInit + scoreAdd*4)
        {
            miniBestRank[0].sprite = ranksType[4];
            miniBestRank[1].sprite = ranksType[4];
        }
        else if (scoreInit + scoreAdd*4 <= bestScore && bestScore < scoreInit + scoreAdd*5)
        {
            miniBestRank[0].sprite = ranksType[5];
            miniBestRank[1].sprite = ranksType[5];
        }
        else if (scoreInit + scoreAdd*5 <= bestScore)
        {
            miniBestRank[0].sprite = ranksType[6];
            miniBestRank[1].sprite = ranksType[6];
        }

    }


    void PlayerDead()
    {

        uiController.SetDiamond(countDiamondFinish);
        uiController.SetDiamondPlus(countDiamondPlus);
        uIStart.playerInputUI.SetActive(false);

        restartBT.interactable = true;
        // uIStart.isStart = false;
        AudioManager.Instance.audioSources[0].gameObject.SetActive(true);
        AudioManager.Instance.audioSources[1].gameObject.SetActive(false);
        animator.Play("FinishGameUI");
        // finishGame.SetActive(true);
        NewFunction.Instance.StartCoroutine(NewFunction.Instance.MoveToPoint(createMap.maps[0], (Vector2)createMap.maps[0].transform.position + new Vector2(0, -5), 10));
        NewFunction.Instance.StartCoroutine(NewFunction.Instance.MoveToPoint(createMap.maps[1], (Vector2)createMap.maps[1].transform.position + new Vector2(0, 5), 10));
        
        AdsManager.Instance.ShowInterstitial();
    }



    public void RestartBT()
    {
        animator.Play("Trash", 2);
        GameManager.Instance.isPlay = false;
        animator.Play("FinishGameReverseUI");
        Invoke("StartTitleDelay", 0.5f);
    }

    void StartTitleDelay()
    {
        Vector3 camPos= new Vector3(/*-4.399999f*/0, 0.09f, -10);
        uIStart.score.GetComponent<TextMeshProUGUI>().enabled = false;
        SetDiamondStart();
        finishGame.SetActive(false);
        effectManager.ActiveEffectBG();
        Camera.main.transform.position = camPos;
        uIStart.startGame.SetActive(true);
        animator.Play("StartTitle");
    }

    public void SetDiamondStart()
    {
        uiController.SetDiamond(countDiamondStart);
    }

    public void DeActiveSecondChange()
    {
        secondChange.SetActive(false);
    }

    public void StartNewLife()
    {
        playerController.StartNewLife();
    }

}
