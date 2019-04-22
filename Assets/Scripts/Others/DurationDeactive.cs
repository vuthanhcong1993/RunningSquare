using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationDeactive : MonoBehaviour {

    [SerializeField] private float timeDeactive = 1;

    private float startTime = 0;
	
	
	// Update is called once per frame
	void Update () {
        DeactiveOb();

    }

    void DeactiveOb()
    {
        if (gameObject.activeSelf)
        {
            startTime += Time.deltaTime;
            if (startTime>= timeDeactive)
            {
                gameObject.SetActive(false);
                startTime = 0;
            }
        }
        
    }
}
