using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Invoke("x", 4);


    }

    void x()
    {
        Debug.Log("xxxxx");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(a());
        }

    }
    IEnumerator a()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        Debug.Log("x");
        //for (int i = 0; i < 10; i++)
        //{
        //    Debug.Log("x" + i);
        //    yield return new WaitForSeconds(1);
        //}
    }

    public void a1()
    {
        Time.timeScale = 1;
    }

    public void a0()
    {
        Time.timeScale = 0;
    }


}
