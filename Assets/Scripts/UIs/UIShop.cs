using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UIShop : MonoBehaviour {

    [SerializeField] private UIFinish uiFinish = null;
    [SerializeField] private TextMeshProUGUI countBuyedText = null;
    [SerializeField] private Transform allCharacters = null;
    [SerializeField] private SpriteRenderer playerBody = null;
    [SerializeField] private ParticleSystem playerBehind = null;


    private int countCharacter = 0;
    private int countBuyed = 0;


    // Use this for initialization
    void Start () {
        
        countCharacter = allCharacters.childCount;
        CountBuyed();    
    }
	
	

    public void Buy()
    {
        Transform currentClick = EventSystem.current.currentSelectedGameObject.transform;
        SlotShop slotShop = currentClick.parent.GetComponent<SlotShop>();
        Transform bgBot = currentClick.parent.GetChild(1);
        if (slotShop.isBuyed)
        {
            DeactiveAllChacracter();
            slotShop.isActive = true;
            slotShop.buyed.isOn = true;
            GetCharacterSelected(ref SaveManager.Instance.buySave.characterSelected);

            SaveManager.Instance.Save();
            SetPlayer(slotShop);
            return;
        }
        if (GameManager.Instance.diamonds >= slotShop.price)
        {
            GameManager.Instance.diamonds -= slotShop.price;
            bgBot.GetChild(0).gameObject.SetActive(false);
            bgBot.GetChild(1).gameObject.SetActive(true);
            bgBot.GetChild(1).GetComponent<Toggle>().isOn = true;
            GameManager.Instance.SetDiamond();
            uiFinish.SetDiamondStart();
            slotShop.isBuyed = true;
            GetCharacterBuyed(ref SaveManager.Instance.buySave.charactersBuyed);
            DeactiveAllChacracter();
            slotShop.isActive = true;
            slotShop.buyed.isOn = true;
            GetCharacterSelected(ref SaveManager.Instance.buySave.characterSelected);
         
            SaveManager.Instance.Save();
            SetPlayer(slotShop);
            CountBuyed();

        }
    }

    void DeactiveAllChacracter()
    {
        for (int i = 0; i < countCharacter; i++)
        {
            allCharacters.GetChild(i).GetComponent<SlotShop>().isActive = false;
            allCharacters.GetChild(i).GetComponent<SlotShop>().buyed.isOn = false;
        }
    }

    void CountBuyed()
    {
        countBuyed = 0;
        for (int i = 0; i < countCharacter; i++)
        {
            if (allCharacters.GetChild(i).GetComponent<SlotShop>().isBuyed)
            {
                countBuyed++;
            }
        }
        countBuyedText.text = countBuyed.ToString()+"/"+ countCharacter.ToString();
    }

    void SetPlayer(SlotShop slotShop)
    {
        playerBody.sprite = slotShop.body;
        ParticleSystem.MinMaxGradient gradientColor = new ParticleSystem.MinMaxGradient(slotShop.playerBehind[0], slotShop.playerBehind[1]);
        gradientColor.mode = ParticleSystemGradientMode.TwoColors;
       ParticleSystem.MainModule mainModule = playerBehind.main;
        mainModule.startColor = gradientColor;
    }

    void GetCharacterBuyed(ref List<int> buyedcharactersBuyed)
    {
        buyedcharactersBuyed.Clear();
        for (int i = 0; i < countCharacter; i++)
        {
            if (allCharacters.GetChild(i).GetComponent<SlotShop>().isBuyed)
            {
                buyedcharactersBuyed.Add(i);
            }
        }
    }

    void GetCharacterSelected(ref int indexSelected)
    {
        for (int i = 0; i < countCharacter; i++)
        {
            if (true)
            {
                if (allCharacters.GetChild(i).GetComponent<SlotShop>().isActive)
                {
                    indexSelected = i;
                } 
            }
            
           
        }
    }

   public void LoadCharacter()
    {
        SaveManager.Instance.Load();
        BuySave buySave = SaveManager.Instance.buySave;
   
        for (int i = 0; i < buySave.charactersBuyed.Count; i++)
        {
            Transform characterBuyed = allCharacters.GetChild(buySave.charactersBuyed[i]);
            characterBuyed.GetComponent<SlotShop>().isBuyed = true;
            characterBuyed.GetComponent<SlotShop>().isActive = true;
            characterBuyed.GetChild(1).GetChild(0).gameObject.SetActive(false);
            characterBuyed.GetChild(1).GetChild(1).gameObject.SetActive(true);

        }
        DeactiveAllChacracter();
        SlotShop chacracterSelectedSlot = allCharacters.GetChild(buySave.characterSelected).GetComponent<SlotShop>();
        chacracterSelectedSlot.isActive = true;
        chacracterSelectedSlot.buyed.isOn = true;
        SetPlayer(chacracterSelectedSlot);
    }

}
