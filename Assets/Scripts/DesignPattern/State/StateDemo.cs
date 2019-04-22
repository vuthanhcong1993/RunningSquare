using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Cho phép một đối tượng thay đổi hành vi của nó khi trạng thái nội bộ của nó thay đổi. Đối tượng sẽ xuất hiện để thay đổi lớp học của nó.
public class StateDemo :MonoBehaviour {

    enum stateNow
    {
        run,
        move,
        attack,
        none
    }
    stateNow enumState = stateNow.none;

    private float heal = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeState()
    {
        switch (enumState)
        {
            case stateNow.run:
                if (heal>0)
                {
                    enumState = stateNow.move;
                }
                break;
            case stateNow.move:
                break;
            case stateNow.attack:
                break;
            case stateNow.none:
                break;
            default:
                break;
        }
    }

   

    void DoAction(stateNow state)
    {
        switch (state)
        {
            case stateNow.run:
               ///Move here
                break;
            case stateNow.move:
                break;
            case stateNow.attack:
                break;
            case stateNow.none:
                break;
            default:
                break;
        }
    }
}
