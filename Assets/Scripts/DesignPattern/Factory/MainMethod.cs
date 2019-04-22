using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMethod : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowType()
    {
        GetComponent<GunBase>().Title();
    }
}
