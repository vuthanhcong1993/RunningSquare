using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    private MapBuilder createMap = null;
    public List<Transform> mapBotSort = new List<Transform>();
    // Use this for initialization
    void Start()
    {
        createMap = GetComponent<MapBuilder>();

    }

    // Update is called once per frame
    void Update()
    {
        WallArrange();

    }

    void WallArrange()
    {
        Transform[] maps = createMap.maps;
        mapBotSort = WallSort(maps[0]);
        List<Transform> mapTopSort = WallSort(maps[1]);
        SetMarkWall(mapBotSort,true);
        SetMarkWall(mapTopSort,false);
    }
    //sort X because when create new wall from old wall
    List<Transform> WallSort(Transform parent)
    {
        List<float> xWalls = new List<float>();
        List<Transform> WallSorted = new List<Transform>();
        int wallCount = parent.childCount;
        for (int i = 0; i < wallCount; i++)
        {
            xWalls.Add(parent.GetChild(i).position.x);
        }
        xWalls.Sort();

        for (int x = 0; x < xWalls.Count; x++)
        {
            for (int i = 0; i < wallCount; i++)
            {
                if (parent.GetChild(i).position.x == xWalls[x])
                {
                    WallSorted.Add(parent.GetChild(i));
                }
            }
        }


        return WallSorted;
    }

    void SetMarkWall(List<Transform> targets,bool isBot)
    {
        for (int i = 0; i < targets.Count - 1; i++)
        {
            float deltaY = targets[i + 1].position.y - targets[i].position.y;
            if (isBot ? deltaY > 0.1f : deltaY < -0.1f )
            {
               targets[i].GetChild(2).gameObject.SetActive(true);
                targets[i + 1].GetChild(3).gameObject.SetActive(false);
            }
            if (isBot ? deltaY < -0.1f : deltaY > 0.1f)
            {
            
                targets[i].GetChild(2).gameObject.SetActive(false);
              
               targets[i + 1].GetChild(3).gameObject.SetActive(true);
            }
            if (Mathf.Abs(deltaY) < 0.1f)
            {
                targets[i].GetChild(2).gameObject.SetActive(true);
             
              
            }
            if (i>0)
            {
                if (!targets[i].gameObject.activeSelf)
                {
                   targets[i-1].GetChild(2).gameObject.SetActive(false);
                    targets[i+1].GetChild(3).gameObject.SetActive(false);
                }
            }
        }
    }

   

}
