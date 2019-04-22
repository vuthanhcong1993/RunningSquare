using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    public float speed = 1.5f;

    private Rigidbody2D rb2D = null;
    private PlayerController playerController;
	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        Move();

    }

    void Move()
    {
      
        if (!playerController.isDead && GameManager.Instance.isPlay )
        {
            transform.Translate(Vector3.right *speed * Time.deltaTime);
        }
        

    }
}
