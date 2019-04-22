using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EasyMobile;

public class UIStart : MonoBehaviour {

     public GameObject startGame = null;
     public GameObject score = null;
    public GameObject playerInputUI = null;

   // [HideInInspector] public bool isStart = false;

    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject tutorial = null;
    [SerializeField] private GameObject map = null;
    


    private MapBuilder createMap = null; 
    private Animator animator = null;
    private bool isGoAnimate = false;
    

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        createMap = map.GetComponent<MapBuilder>();

    }
	
	

    public void PlayBT()
    {
        Invoke("ActivePlayerDelay", 0.4f);
        animator.Play("StartGameUI",2);
        PlayStart();
        Invoke("DeactiveStart", 0.167f); //active then play startgameui anim
        Invoke("ActiveStart", 0.2f); //active then play startgameui anim
    }

    void ActiveStart()
    {
       
        map.SetActive(true);
        GameManager.Instance.playerMotor.speed = 1.5f;     
        score.GetComponent<TextMeshProUGUI>().enabled = true;
        createMap.CreateStart();
        
       
    }

    void PlayStart()
    {
        tutorial.SetActive(true);
        isGoAnimate = true;
    }

    void InteractableTutorialBT()
    {
        tutorial.GetComponent<Button>().interactable  = true;
    }

    void DeactiveStart()
    {
        startGame.SetActive(false);
    }

    void ActivePlayerDelay()
    {
        player.SetActive(true);
        AudioManager.Instance.audioSources[0].gameObject.SetActive(false);
        AudioManager.Instance.audioSources[1].gameObject.SetActive(true);
        player.GetComponent<Animator>().Play("PlayerAppear");
    }

    public void SoundBT(float volume)
    {
        AudioListener.volume = volume;
    }

    public void SetIsPlay()
    {
      //  tutorial.SetActive(false);
        GameManager.Instance.isPlay = true;
        if (isGoAnimate)
        {
            animator.Play("GO", 1);
            AudioManager.Instance.audioSources[8].Play();
            isGoAnimate = false;
            playerInputUI.SetActive(true);
        }
        
    }

    public void ShowLeaderboard()
    {
        if (GameServiceManager.IsInitialized())
        {
            GameServiceManager.ShowLeaderboardUI();
        }
    }

    
    public void RateGameBT()
    {
#if UNITY_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.zunkyu.line.run.endless.fun.mobile.game");
#endif
    }
   



}
