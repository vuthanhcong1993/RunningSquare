using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;

public class PlayerController : MonoBehaviour
{

    public float yDelta = 0.61f;
    public float xDelta = 2.269f;
    public float ySpeedMove = 5f;
    public float botUpTheshHold = -3.84f;
    public float botDownTheshHold = -6.08f;
    public float topUpThreshHold = 6.25f;
    public float topDownThreshHold = 4.01f;
    public bool isDead = false;
    public Transform raycastPos = null;
    public Transform raycastPosFar = null;
    public Transform raycastPosBehind = null;
    public Transform body = null;

    [HideInInspector] public IPlayerCommand buttonUp, buttonDown, buttonSpace;
    [HideInInspector] public bool isSecondChance = false;

    [SerializeField] private GameObject[] emojiDie = null;
    [SerializeField] private MapBuilder createMap = null;
    [SerializeField] private UIFinish uIFinish = null;
    [SerializeField] private UIStart uIStart = null;
    [SerializeField] private EffectManager effectManager = null;
    [SerializeField] private GameObject threeToOne = null;
    [SerializeField] private Animator uiAnimator = null;
    [SerializeField] private GameObject tutorial = null;
  
    private Transform currentWall = null;
    private Animator animator = null;
    private GameObject wallBeforeDie = null;
    private bool isDelayUseButton = false;
    // Use this for initialization
    void Start()
    {
        buttonUp = GetComponent<ChangeUp>();
        buttonDown = GetComponent<ChangeDown>();
        buttonSpace = GetComponent<ChangeRole>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Die();
        createMap.CreateNewWall();
        InputHandle();
       

    }

    void InputHandle()
    {
       
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            
            ButtonUp();
           
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) )
        {
          
            ButtonDown();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            ButtonSpace();
        }
#endif      

    }

    IEnumerator DeleteDelayButton()
    {
        //   yield return new WaitForSeconds(0);
        yield return null;
        isDelayUseButton = false;
    }

    public void  ButtonUp()
    {
        if (isDead || isDelayUseButton )
        {
            return;
        }
        buttonUp.Execute(this);
        isDelayUseButton = true;
        StartCoroutine(DeleteDelayButton());
    }

    public void ButtonDown()
    {
        if (isDead || isDelayUseButton )
        {
            return;
        }
        buttonDown.Execute(this);
        isDelayUseButton = true;
        StartCoroutine(DeleteDelayButton());
    }

    public void ButtonSpace()
    {
        if (isDead || isDelayUseButton )
        {
            return;
        }
        buttonSpace.Execute(this);
        isDelayUseButton = true;
        StartCoroutine(DeleteDelayButton());

    }

    void Die()
    {
        // consider next wall +x?
        // check null down raycast
        GameObject wallDown = buttonDown.ObjectBelow(this, -1);
        if (isDead)
        {
            return;
        }
        
        if (!wallDown)
        {
            RaycastHit2D wallFar = Physics2D.Raycast(raycastPosFar.position, -transform.up, 50, 1 << LayerMask.NameToLayer("Wall"));
            RaycastHit2D wallBehind = Physics2D.Raycast(raycastPosBehind.position, -transform.up, 50, 1 << LayerMask.NameToLayer("Wall"));
            if (!wallFar )
            {
                isDead = true;
                uIStart.playerInputUI.SetActive(false);
                uiAnimator.Play("Trash", 2);
                tutorial.SetActive(false);
                UnActiveEmojiCool();
                effectManager.ActiveEmoji(emojiDie);
                animator.Play("Die");
                if (/*!GameManager.Instance.isSecondChance ||*/ isSecondChance || !AdManager.IsRewardedAdReady())
                {
  
                    uIFinish.FinishGame(2);
                }
                else
                {
                    uIFinish.SecondChange();
                }
                AudioManager.Instance.audioSources[5].Play();
                AudioManager.Instance.audioSources[9].Play();
                if (wallBehind)
                {
                    wallBeforeDie = wallBehind.transform.gameObject;
                }
                return;
            }
           
        }
        if (wallDown)
        {
            if (currentWall != null && wallDown.transform.position.x == currentWall.position.x)
            {
                return;
            }
            currentWall = wallDown.transform;
            if (wallDown.transform.CompareTag("WallBot"))
            {
                TestSameWall(0, wallDown);
            }
            if (wallDown.transform.CompareTag("WallTop"))
            {
                TestSameWall(1, wallDown);
            }
              
            
        }

    }

    void UnActiveEmojiCool()
    {
        for (int i = 0; i < effectManager.emojiCool.Length; i++)
        {
            effectManager.emojiCool[i].SetActive(false);
        }
    }

    public void SecondChangedOk()
    {
        threeToOne.SetActive(true);
        createMap.SetSquareDeselectAll(createMap.maps[0]);
        createMap.SetSquareDeselectAll(createMap.maps[1]);
       
#if UNITY_EDITOR
        uIFinish.DeletePlayerDead();
        SetWallEqual();
        uIFinish.GetComponent<Animator>().Play("Trash", 0);

#endif

        if (transform.position.y <0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.y >= 0)
        {
            transform.rotation = Quaternion.Euler(180, 0, 0);
        }
        transform.position = new Vector2(wallBeforeDie.transform.position.x - xDelta / 2 + 1f, transform.position.y);
        transform.GetChild(0).GetChild(0).localRotation = Quaternion.Euler(0, 0, 0);
        animator.Play("PlayerAppear");
        GameObject wallDown = buttonDown.ObjectBelow(this, -1);
        createMap.SetColorSquareSelect(wallDown.transform);

        uIFinish.GetComponent<Animator>().Play("321", 3);


    }

    public void ShowAdsRewardLife()
    {
        uIFinish.GetComponent<Animator>().Play("Trash", 0);
        AudioManager.Instance.audioSources[9].Stop();
        uIFinish.DeletePlayerDead();
        SetWallEqual();
        AdsManager.Instance.ShowReward();
    }

    void SetWallEqual()
    {
        GameObject wallDown = buttonDown.ObjectBelow(this, -1);
        if (wallDown)
        {
            if (wallDown.transform.CompareTag("WallBot"))
            {
                EqualYNextWall(0, wallDown);
            }
            if (wallDown.transform.CompareTag("WallTop"))
            {
                EqualYNextWall(1, wallDown);
            }
        }
        else
        {
            if (transform.position.y <0)
            {
                EqualYNextWallNull(0, wallBeforeDie);
            }
            else
            {
                EqualYNextWallNull(1, wallBeforeDie);
            }
        }
        



    }

    void EqualYNextWallNull(int pos, GameObject wallBeforeDie)
    {
        int mapBotCount = createMap.maps[pos].childCount;

        for (int i = 0; i < mapBotCount; i++)
        {
            if (Mathf.Abs(createMap.maps[pos].GetChild(i).position.x - (wallBeforeDie.transform.position.x + xDelta)) < 0.1f)
            {

                createMap.maps[pos].GetChild(i).gameObject.SetActive(true);
                createMap.maps[pos].GetChild(i).position = new Vector2(createMap.maps[pos].GetChild(i).position.x, wallBeforeDie.transform.position.y);

            }
        }


    }

    void EqualYNextWall(int pos, GameObject wallDown)
    {
        int mapBotCount = createMap.maps[pos].childCount;
       
        for (int i = 0; i < mapBotCount; i++)
        {
            if (Mathf.Abs(createMap.maps[pos].GetChild(i).position.x - (wallDown.transform.position.x - xDelta)) < 0.1f)
            {
                wallDown.SetActive(true);
                wallDown.transform.position = new Vector2(wallDown.transform.position.x, createMap.maps[pos].GetChild(i).position.y);
               
            }
        }

    }

    public void StartNewLife()
    {
        threeToOne.SetActive(false);
        isDead = false;
        uIStart.playerInputUI.SetActive(true);
        //  transform.position = new Vector2(wallBeforeDie.transform.position.x - xDelta / 2, transform.position.y);
        //  animator.Play("PlayerAppear");
        isSecondChance = true;
      //  uIFinish.GetComponent<Animator>().Play("Trash");
        uIFinish.DeletePlayerDead();
    }

    void TestSameWall(int pos, GameObject wallDown)
    {
        // Debug.Log(pos + "//" + wallDown.transform.position);
        int mapBotCount = createMap.maps[pos].childCount;
        if (isDead)
        {
            return;
        }
        for (int i = 0; i < mapBotCount; i++)
        {
         //   Debug.Log(Mathf.Abs(createMap.maps[pos].GetChild(i).position.x - (wallDown.transform.position.x - xDelta)));
            if (Mathf.Abs(createMap.maps[pos].GetChild(i).position.x - (wallDown.transform.position.x - xDelta)) < 0.1f)
            {
                // Debug.Log(createMap.maps[pos].GetChild(i).position.x);
                // Debug.Log(pos+"//"+createMap.maps[pos].GetChild(i).position + "///" + wallDown.transform.position);
                if (Mathf.Abs(createMap.maps[pos].GetChild(i).position.y - wallDown.transform.position.y) >(0.1f))
                {
                    isDead = true;
                  //  Debug.Log("??");
                    uIStart.playerInputUI.SetActive(false);
                    UnActiveEmojiCool();
                    effectManager.ActiveEmoji(emojiDie);
                    uiAnimator.Play("Trash", 2);
                    tutorial.SetActive(false);
                    animator.Play("Die");
                    if (/*!GameManager.Instance.isSecondChance ||*/ isSecondChance || !AdManager.IsRewardedAdReady()) //only 1 chance 
                    {
          
                        uIFinish.FinishGame(2);
                    }
                    else
                    {
                        uIFinish.SecondChange();
                    }
                    AudioManager.Instance.audioSources[5].Play();
                    AudioManager.Instance.audioSources[9].Play();
                    currentWall = createMap.maps[pos].GetChild(i);
                    return;
                }
            }
        }
        wallBeforeDie = wallDown; // error behind vs current y not same 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            ObjectPool.Instance.SpawnPool("StarBurst", collision.transform.position, Quaternion.identity);
            GameManager.Instance.diamonds++;
            GameManager.Instance.diamondsPlus++;
            AudioManager.Instance.audioSources[2].Play();
        }
        
       
    }

   



}
