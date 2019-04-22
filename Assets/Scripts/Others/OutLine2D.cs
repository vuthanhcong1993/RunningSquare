using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class OutLine2D : MonoBehaviour {

    [SerializeField] private float outLine = 0.1f;

    private Vector3 lastLocalScale = Vector3.zero;
	// Use this for initialization
	void Start () {
        lastLocalScale = transform.GetChild(0).localScale;

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.GetChild(0).localScale != lastLocalScale)
        {
            transform.GetChild(1).localScale = new Vector3(transform.GetChild(0).localScale.x - outLine, transform.GetChild(0).localScale.y - outLine, transform.GetChild(0).localScale.z - outLine);
        }
    }
}
