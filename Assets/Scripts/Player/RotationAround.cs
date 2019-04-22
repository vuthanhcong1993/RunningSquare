using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAround : MonoBehaviour {

    [SerializeField] private float speed = 1;
    [SerializeField] private PlayerController playerController = null;
  	
	// Update is called once per frame
	void Update () {
        if (!playerController.isDead && GameManager.Instance.isPlay)
        {
            transform.Rotate(new Vector3(0, 0, -180) * Time.deltaTime * speed, Space.Self);
        }
        
	}
}
