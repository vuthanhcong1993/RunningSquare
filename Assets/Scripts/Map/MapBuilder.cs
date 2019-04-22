using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapBuilder : MonoBehaviour
{

    public int pointWallSum = 1;
    public Transform[] maps = null;

    [SerializeField] private int countSquare = 15;
    [SerializeField] private int probabilityDeactiveWall = 40;
    [SerializeField] private int probabilityDectiveCoin = 35;
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private EffectManager effectManager = null;

    private int lastValueBot = 0;
    private int lastValueTop = 0;
    private int wallDeactive = 0;
    private int rdNextSquareTop = 0;
    private int  rdNextSquareBot = 0;
    private float xDelta = 0;
    private float yDelta = 0;
    private bool isFirstCreate = true;
    private bool isMakeNewWall = false;
    private List<Transform> wallsBot = new List<Transform>();
    private List<Transform> wallsTop = new List<Transform>();
    private List<int[]> nextSquare = new List<int[]>(5) { new int[3] { 0, 1, 2 }, new int[4] { 0, 1, 2, 3 }, new int[5] { 0, 1, 2, 3, 4 }, new int[4] { 4, 1, 2, 3 }, new int[3] { 2, 3, 4 } };
    private List<int[]> nextSquareDeactive = new List<int[]>(5) { new int[2] { 0, 1 }, new int[3] { 0, 1, 2 }, new int[3] {  1, 2, 3 }, new int[3] { 4,3,2 }, new int[2] { 3, 4 } };//random square behind square deactive
    private Transform[] wallPoint = new Transform[2];
    
    // private ParticleSystem a;


    // Use this for initialization

    void Start()
    {

        //ParticleSystem.MainModule b= a.main;
        //ParticleSystem.MinMaxGradient x = new ParticleSystem.MinMaxGradient(Color.blue, Color.red);
        //x.mode = ParticleSystemGradientMode.TwoColors;
        //b.startColor = x;
        // CreateStart();


    }

    // Update is called once per frame
    void Update()
    {

        if (isFirstCreate)
        {
            StartReset();
            isFirstCreate = false;

        }
       // CreateNewWall();
    }



    public void StartReset()
    {
        xDelta = playerController.xDelta;
        yDelta = playerController.yDelta;
        playerController.isDead = false;
        wallsBot.Clear();
        wallsTop.Clear();
        ClearChild(maps[0]);
        ClearChild(maps[1]);
        maps[0].transform.position = new Vector3(0, 0, 0);
        maps[1].transform.position = new Vector3(0, 0, 0);
        Create();
        playerController.transform.position = new Vector3(-8.4f, -2.405f, 0);
        playerController.transform.rotation = Quaternion.Euler(0, 0, 0);
        playerController.body.rotation = Quaternion.Euler(0, 0, 0);
        playerController.isSecondChance = false;
        wallPoint[0] = maps[0].GetChild(0);
        maps[0].GetChild(0).GetChild(3).gameObject.SetActive(false);
        maps[1].GetChild(0).GetChild(3).gameObject.SetActive(false);
        wallPoint[1] = maps[1].GetChild(0);
        pointWallSum = 1;
        isMakeNewWall = false;
        Camera.main.transform.position = new Vector3(/*-4.399999f*/0, 0.09f, -10);
        GameManager.Instance.score = 0;
        GameManager.Instance.diamondsPlus = 0;
        AddWall();
        effectManager.scoreLevel = 15;
        effectManager.newHighScore.SetActive(false);
        AudioManager.Instance.audioSources[6].gameObject.SetActive(false);


    }

    public void CreateStart()
    {
        isFirstCreate = true;
    }

   public void ClearChild(Transform parent)
    {
        int count = parent.childCount;
        for (int i = 0; i < count; i++)
        {
            SetColorSquareDeselect(parent.GetChild(i));
            parent.GetChild(i).gameObject.SetActive(false);
          

        }
    }

    public void SetSquareDeselectAll(Transform parent)
    {
        int count = parent.childCount;
        for (int i = 0; i < count; i++)
        {
           
            SetColorSquareDeselect(parent.GetChild(i));

        }
    }

    void AddWall()
    {
        for (int i = 0; i < maps[0].childCount; i++)
        {
            wallsBot.Add(maps[0].GetChild(i));
        }
        for (int i = 0; i < maps[1].childCount; i++)
        {
            wallsTop.Add(maps[1].GetChild(i));
        }
    }

    void Create()
    {
        for (int i = 0; i < countSquare; i++)
        {
            if (i == 0)
            {
                lastValueBot = 2;
                GameObject firstSquareBot = ObjectPool.Instance.SpawnPool("SquareBot", new Vector3(-6.63f, -6.18f + lastValueBot * yDelta, 0), Quaternion.identity);
                SetColorSquareSelect(firstSquareBot.transform);
                // firstSquareBot.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                lastValueTop = 2;
                GameObject firstSquareTop = ObjectPool.Instance.SpawnPool("SquareTop", new Vector3(-6.63f, 6.18f - lastValueTop * yDelta, 0), Quaternion.identity);
            }
            else if (i == 1)
            {
                lastValueBot = 1;
                GameObject firstSquareBot = ObjectPool.Instance.SpawnPool("SquareBot", new Vector3(-6.63f + xDelta, -6.18f + lastValueBot * yDelta, 0), Quaternion.identity);
                //SetColorSquareSelect(firstSquareBot.transform);
                // firstSquareBot.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                lastValueTop = 1;
                GameObject firstSquareTop = ObjectPool.Instance.SpawnPool("SquareTop", new Vector3(-6.63f + xDelta, 6.18f - lastValueTop * yDelta, 0), Quaternion.identity);
            }
            else if (i == 2) {
                lastValueBot = 2;
                GameObject firstSquareBot = ObjectPool.Instance.SpawnPool("SquareBot", new Vector3(-6.63f + 2*xDelta, -6.18f + lastValueBot * yDelta, 0), Quaternion.identity);
                //SetColorSquareSelect(firstSquareBot.transform);
                // firstSquareBot.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                lastValueTop = 2;
                GameObject firstSquareTop = ObjectPool.Instance.SpawnPool("SquareTop", new Vector3(-6.63f + 2*xDelta, 6.18f - lastValueTop * yDelta, 0), Quaternion.identity);
            }
            else
            {
                //bot
                int rdNextSquareBot = Random.Range(0, nextSquare[lastValueBot].Length);
                GameObject wallBotOb = ObjectPool.Instance.SpawnPool("SquareBot", new Vector3(-6.63f + i * xDelta, -6.18f + nextSquare[lastValueBot][rdNextSquareBot] * yDelta, 0), Quaternion.identity);
                if (ProbabilityActive(probabilityDectiveCoin))
                {
                    wallBotOb.transform.GetChild(wallBotOb.transform.childCount - 1).gameObject.SetActive(true);
                }
                lastValueBot = nextSquare[lastValueBot][rdNextSquareBot];
                //top
                int rdNextSquareTop = Random.Range(0, nextSquare[lastValueTop].Length);
                GameObject wallTopOb = ObjectPool.Instance.SpawnPool("SquareTop", new Vector3(-6.63f + i * xDelta, 6.18f - nextSquare[lastValueTop][rdNextSquareTop] * yDelta, 0), Quaternion.identity);
                lastValueTop = nextSquare[lastValueTop][rdNextSquareTop];
                if (ProbabilityActive(probabilityDectiveCoin))
                {
                    wallTopOb.transform.GetChild(wallTopOb.transform.childCount - 1).gameObject.SetActive(true);
                }
            }

        }
    }

   public void CreateNewWall()
    {
        if (!playerController.gameObject.activeSelf || playerController.isDead)
        {
            return;
        }
        GameObject wallDown = playerController.buttonDown.ObjectBelow(playerController, -1);
        if (!wallDown)
        {
            return;
        }
        if (wallPoint[0] == null && wallPoint[1] == null)
        {
            return;
        }


        if (wallDown.transform.gameObject.layer != LayerMask.NameToLayer("Wall"))
        {
            return;
        }
        if ((wallPoint[0] ? wallPoint[0] : wallPoint[1]).position.x != wallDown.transform.position.x)
        {
            if (wallPoint[0])
            {
                SetColorSquareDeselect(wallPoint[0]);
              

            }
            if (wallPoint[1])
            {
                SetColorSquareDeselect(wallPoint[1]);
               

            }

            SetColorSquareSelect(playerController.buttonUp.ObjectBelow(playerController, -1).transform);
            
            pointWallSum++;
            GameManager.Instance.score++;
            int scoreInit = 10;
            int scoreAdd = 10;
            float speedIncrease = 0;
            if (GameManager.Instance.score< scoreInit)
            {
                speedIncrease = 0.2f;
            }
            else if (scoreInit <= GameManager.Instance.score && GameManager.Instance.score < scoreInit+ scoreAdd)
            {
                speedIncrease = 0.16f;
            }
            else if(scoreInit + scoreAdd <= GameManager.Instance.score && GameManager.Instance.score < scoreInit + scoreAdd*2)
            {
                speedIncrease = 0.14f;
            }
            else if (scoreInit + scoreAdd*2 <= GameManager.Instance.score && GameManager.Instance.score < scoreInit + scoreAdd*3)
            {
                speedIncrease = 0.12f;
            }
            else if (scoreInit + scoreAdd*3 <= GameManager.Instance.score && GameManager.Instance.score < scoreInit + scoreAdd*4)
            {
                speedIncrease = 0.11f;
            }
            else if (scoreInit + scoreAdd*4 <= GameManager.Instance.score && GameManager.Instance.score <= scoreInit + scoreAdd*5)
            {
                speedIncrease = 0.1f;
            }
            GameManager.Instance.playerMotor.speed += speedIncrease;
            int firstNewWall = 6;
            if (pointWallSum == firstNewWall)
            {
                isMakeNewWall = true;
            }
            if (isMakeNewWall)
            {
                //two wall bot ,top next behind wall deactive probable active
                bool isActive = false;
                if (wallDeactive == 1)
                {
                    isActive = true;
                    wallDeactive = 0;
                }
                //bot
                CreateNewWallBot(isActive);
                //top
                CreateNewWallTop(isActive);

            }

            if (playerController.buttonUp.ObjectBelow(playerController, -1))
            {
                wallPoint[0] = playerController.buttonUp.ObjectBelow(playerController, -1).transform;
            }
            else
            {
                wallPoint[0] = null;
            }
            if (playerController.buttonUp.ObjectBelow(playerController, 1))
            {
                wallPoint[1] = playerController.buttonUp.ObjectBelow(playerController, 1).transform;
            }
            else
            {
                wallPoint[1] = null;
            }

        }
    }

    void CreateNewWallBot(bool isActive)
    {
         rdNextSquareBot = Random.Range(0, nextSquare[lastValueBot].Length);
        wallsBot[0].gameObject.SetActive(true);
        wallsBot[0].transform.GetChild(wallsBot[0].transform.childCount - 1).gameObject.SetActive(false);
        if (ProbabilityActive(probabilityDeactiveWall) && !isActive)
        {
            wallsBot[0].gameObject.SetActive(false);
            wallDeactive++;
        }
        wallsBot[0].position = new Vector3(-6.63f + (countSquare + (pointWallSum - 6)) * xDelta, -6.18f + nextSquare[lastValueBot][rdNextSquareBot] * yDelta, 0);
        wallsBot[0].GetChild(2).gameObject.SetActive(false);
        wallsBot[0].GetChild(3).gameObject.SetActive(false);
        if (ProbabilityActive(probabilityDectiveCoin))
        {
            wallsBot[0].transform.GetChild(wallsBot[0].transform.childCount - 1).gameObject.SetActive(true);
        }
        wallsBot.Add(wallsBot[0]);
        wallsBot.RemoveAt(0);
       
    }

    void CreateNewWallTop(bool isActive)
    {
        bool isBotDeactive = false;
         rdNextSquareTop = Random.Range(0, nextSquare[lastValueTop].Length);
        wallsTop[0].gameObject.SetActive(true);
        wallsTop[0].transform.GetChild(wallsTop[0].transform.childCount - 1).gameObject.SetActive(false);
        if (wallDeactive ==1)
        {
            //Bot Deactive
            isBotDeactive = true;
            rdNextSquareTop = Random.Range(0, nextSquareDeactive[lastValueTop].Length);
            wallsTop[0].position = new Vector3(-6.63f + (countSquare + (pointWallSum - 6)) * xDelta, 6.18f - nextSquareDeactive[lastValueTop][rdNextSquareTop] * yDelta, 0);
            lastValueTop = nextSquareDeactive[lastValueTop][rdNextSquareTop];
        }
        else
        {
            wallsTop[0].position = new Vector3(-6.63f + (countSquare + (pointWallSum - 6)) * xDelta, 6.18f - nextSquare[lastValueTop][rdNextSquareTop] * yDelta, 0);
            lastValueTop = nextSquare[lastValueTop][rdNextSquareTop];
        }
        if (ProbabilityActive(probabilityDeactiveWall) && wallDeactive == 0 && !isActive)
        {
            wallsTop[0].gameObject.SetActive(false);
            wallDeactive++;
        }
        if (wallDeactive == 1 && isBotDeactive==false)
        {
            //Top Deactive
            rdNextSquareBot = Random.Range(0, nextSquareDeactive[lastValueBot].Length);
            wallsBot[wallsBot.Count-1].position= new Vector3(-6.63f + (countSquare + (pointWallSum - 6)) * xDelta, -6.18f + nextSquareDeactive[lastValueBot][rdNextSquareBot] * yDelta, 0);
            lastValueBot = nextSquareDeactive[lastValueBot][rdNextSquareBot];
        }
        else
        {
            lastValueBot = nextSquare[lastValueBot][rdNextSquareBot];
        }
        wallsTop[0].GetChild(2).gameObject.SetActive(false);
        wallsTop[0].GetChild(3).gameObject.SetActive(false);
        if (ProbabilityActive(probabilityDectiveCoin))
        {
            wallsTop[0].transform.GetChild(wallsTop[0].transform.childCount - 1).gameObject.SetActive(true);
        }
        wallsTop.Add(wallsTop[0]);
        wallsTop.RemoveAt(0);
       
       

    }

    bool ProbabilityActive(int probabilityDeactive)
    {
        int lastRd = 101;
        int rd = Random.Range(1, lastRd);
        if (rd <= probabilityDeactive)
        {
            return true;
        }
        return false;
    }

   public void SetColorSquareSelect(Transform target)
    {
        target.GetChild(0).GetComponent<_2dxFX_PlasmaRainbow>().enabled = false;
        target.GetChild(0).GetComponent<_2dxFX_LightningBolt>().enabled = true;
        target.GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;
        target.GetChild(4).gameObject.SetActive(false);
        target.GetChild(4).gameObject.SetActive(true);
    }
   public void SetColorSquareDeselect(Transform target)
    {
        target.GetChild(0).GetComponent<_2dxFX_LightningBolt>().enabled = false;
        target.GetChild(0).GetComponent<_2dxFX_PlasmaRainbow>().enabled = true;
        target.GetChild(4).gameObject.SetActive(false);
        target.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
    }


}

