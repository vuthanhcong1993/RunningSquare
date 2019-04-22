using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float speed = 5;
    [SerializeField] private float offset = -7;
    [SerializeField] private Transform player = null;
    [SerializeField] private bool useMultiple = false;
    // Use this for initialization
    void Start()
    {
        if (useMultiple)
        {
            MultipleResolution();
        }
   

    }

    // Update is called once per frame
    void LateUpdate()
    {
        MoveToPlayer();

    }

    void MoveToPlayer()
    {
        if (player.gameObject.activeSelf)
        {
            float xPosCam = Mathf.Lerp(transform.position.x, player.position.x + offset, Time.deltaTime * speed);
            transform.position = new Vector3(xPosCam, 0, -10);
        }
       


    }

    void MultipleResolution()
    {
        float TARGET_WIDTH = 1080.0f;
        float TARGET_HEIGHT = 1920.0f;
        int PIXELS_TO_UNITS = 62; // 1:1 ratio of pixels to units

        float desiredRatio = TARGET_WIDTH / TARGET_HEIGHT;
        float currentRatio = (float)Screen.width / (float)Screen.height;

        if (currentRatio >= desiredRatio)
        {
            // Our resolution has plenty of width, so we just need to use the height to determine the camera size
            Camera.main.orthographicSize = TARGET_HEIGHT /( 4 * PIXELS_TO_UNITS);
        }
        else
        {
            // Our camera needs to zoom out further than just fitting in the height of the image.
            // Determine how much bigger it needs to be, then apply that to our original algorithm.
            float differenceInSize = desiredRatio / currentRatio;
            Camera.main.orthographicSize = TARGET_HEIGHT / (4 * PIXELS_TO_UNITS) * differenceInSize;
        }
    }

}
