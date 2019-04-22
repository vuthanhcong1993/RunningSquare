using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    public GameObject newHighScore = null;
    public int scoreLevel = 15;
    public GameObject[] emojiCool = null;

    [SerializeField] private GameObject upperTen = null; 
    [SerializeField] private GameObject[] effectBG = new GameObject[4];
    [SerializeField] private List<Sprite> bgColors = new List<Sprite>();
    [SerializeField] private SpriteRenderer bg = null;
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private Animator uiAnim = null;


    private List<Sprite> bgColorsClone = new List<Sprite>();


    
    // Use this for initialization
    void Start () {
       
        ActiveEffectBG();
    }
	
	// Update is called once per frame
	void Update () {
        ScoreLevelEffect();
        NewHighScore();

    }

   public void ActiveEffectBG()
    {
        int rd = Random.Range(0, 4);
        for (int i = 0; i < effectBG.Length; i++)
        {
            effectBG[i].SetActive(false);
        }      
        effectBG[rd].SetActive(true);
        bgColorsClone.Clear();
        EqualBGColors();
        SetBGColor();
    }

    void ScoreLevelEffect()
    {
        if (gameManager.score == scoreLevel && !playerController.isDead)
        {
            upperTen.SetActive(false);
            upperTen.SetActive(true);
            ActiveEmoji(emojiCool);
            SetBGColor();
            scoreLevel += 15;
            uiAnim.Play("RankUp");
            AudioManager.Instance.audioSources[4].Play();
        }
    }

    public void ActiveEmoji(GameObject[] emoji)
    {
      
        if (gameManager.score<=15)
        {
            emoji[0].SetActive(false);
            emoji[0].SetActive(true);
        }
        else if (15<gameManager.score && gameManager.score <=30)
        {
            emoji[1].SetActive(false);
            emoji[1].SetActive(true);
        }
        else if (30 < gameManager.score && gameManager.score <= 45)
        {
            emoji[2].SetActive(false);
            emoji[2].SetActive(true);
        }
        else if (45 < gameManager.score && gameManager.score <= 60)
        {
            emoji[3].SetActive(false);
            emoji[3].SetActive(true);

        }
        else if (60 < gameManager.score && gameManager.score <= 75)
        {
            emoji[4].SetActive(false);
            emoji[4].SetActive(true);
        }
        else if (75 < gameManager.score && gameManager.score <= 90)
        {
            emoji[5].SetActive(false);
            emoji[5].SetActive(true);
        }
        else 
        {
            emoji[6].SetActive(false);
            emoji[6].SetActive(true);
        }
       

    }

    void SetBGColor()
    {
        if (bgColorsClone.Count>0)
        {
            int rd = Random.Range(0, bgColorsClone.Count);
            bg.sprite = bgColorsClone[rd];
            bgColorsClone.RemoveAt(rd);
        }
       
    }

    void EqualBGColors()
    {
        for (int i = 0; i < bgColors.Count; i++)
        {
            bgColorsClone.Add(bgColors[i]);
        }
    }


   public void NewHighScore()
    {
        if (gameManager.score==PlayerPrefs.GetInt("HighScore")+1)
        {
         newHighScore.SetActive(true);
         uiAnim.Play("HighScore");
         AudioManager.Instance.audioSources[6].gameObject.SetActive(true);
        }
    }
}
