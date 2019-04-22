using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ObjectPool.Instance.SpawnPool("Cube", new Vector3(0, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            ObjectPool.Instance.SpawnPool("squere", new Vector3(3, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Common.Log("dsadsa");
        }
    }

   
}
