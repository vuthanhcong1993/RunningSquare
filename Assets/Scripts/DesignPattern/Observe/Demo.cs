using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour {
    private Action<object> _OnGetTriggerStary2D;
    public float b;
	// Use this for initialization
	void Start () {
        _OnGetTriggerStary2D = (param) => GetTriggerStay();
        this.RegisterListener(EventID.GetTriggerExit2D, (a) => GetTriggerExitNow(a));
        this.RegisterListener(EventID.GetTriggerStay2D, _OnGetTriggerStary2D);
	}
	
	// Update is called once per frame
	void Update () {
        this.PostEvent(EventID.GetTriggerExit2D,this);
        this.PostEvent(EventID.GetTriggerStay2D);
    }

    void GetTriggerExitNow(object demo)
    {
        if (demo is Demo)
        {
            Demo messsage = (Demo)demo;
            Debug.Log(messsage.b);

        }

    }

    void GetTriggerStay()
    {

    }

    void RemoveEventt()
    {
        this.RemoveListener(EventID.GetTriggerStay2D, (param) => GetTriggerStay());
        this.RemoveListener(EventID.GetTriggerStay2D, _OnGetTriggerStary2D);
    }
}
