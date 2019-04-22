using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIController : MonoBehaviour {

    [SerializeField] private UIShop uiShop = null;
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private  TextMeshProUGUI scoreText = null;
    [SerializeField] private GameObject leftControlIcon = null;
    [SerializeField] private GameObject rightControlIcon = null;


    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
         Screen.SetResolution(1080, 1920, false);
        uiShop.LoadCharacter();
    }
	
	// Update is called once per frame
	void Update () {
        GetScore();
        SetLeftRightIcon();
    }

    void GetScore()
    {
        scoreText.text = (GameManager.Instance.score).ToString();
    }

   public void SetDiamond(TextMeshProUGUI countDiamond)
    {
        
        countDiamond.text = GameManager.Instance.diamonds.ToString();
    }

    public void SetDiamondPlus(TextMeshProUGUI countDiamond)
    {
        countDiamond.text = "+"+GameManager.Instance.diamondsPlus.ToString();
    }

    public void SetLeftRightIcon()
    {
        if (playerController.transform.position.y <0)
        {
            leftControlIcon.SetActive(true);
            rightControlIcon.SetActive(false);
        }
        else
        {
            leftControlIcon.SetActive(false);
            rightControlIcon.SetActive(true);
        }
        
    }

   

    
}
