using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPlayerCommand : MonoBehaviour
{

    public abstract void Execute(PlayerController playerController);

    public void Move(PlayerController playerController, int directionValue)
    {
        GameObject wall = ObjectBelow(playerController,-1).transform.gameObject;
        if (!wall || playerController.isDead)
        {
            return;
        }

        //threshhold
        if (wall.CompareTag("WallBot"))
        {
            if (directionValue == 1)
            {
                if (wall.transform.position.y>=playerController.botUpTheshHold)
                {
                    return;
                }
                
            }
            if (directionValue == -1)
            {
                if (wall.transform.position.y <= playerController.botDownTheshHold)
                {
                    return;
                }
            }
        }
        if (wall.CompareTag("WallTop"))
        {
            if (directionValue == 1)
            {
                if (wall.transform.position.y >= playerController.topUpThreshHold)
                {
                    return;
                }

            }
            if (directionValue == -1)
            {
                if (wall.transform.position.y <= playerController.topDownThreshHold)
                {
                    return;
                }
            }
        }
        Vector2 positionMoveWall = new Vector2(wall.transform.position.x, wall.transform.position.y + playerController.yDelta * directionValue);
        Vector2 positionMovePlayer = new Vector2(playerController.transform.position.x, playerController.transform.position.y + playerController.yDelta * directionValue);
        NewFunction.Instance.StartCoroutine(NewFunction.Instance.MoveToPoint(wall.transform, positionMoveWall, playerController.ySpeedMove, playerController.isDead));
        NewFunction.Instance.StartCoroutine(NewFunction.Instance.MoveToPoint(playerController.transform, positionMovePlayer, playerController.ySpeedMove, playerController.isDead));
        AudioManager.Instance.audioSources[3].Play();

    }

    public void ChangeRole(PlayerController playerController,MapBuilder createMap)
    {
        GameObject wallUp = ObjectBelow(playerController, 1);
        GameObject wallDown = ObjectBelow(playerController, -1);
        if (wallUp)
        {       
            createMap.SetColorSquareSelect(wallUp.transform.transform);
            RaycastHit2D wall = Physics2D.Raycast(playerController.raycastPos.position,  playerController.transform.up, 50, 1 << LayerMask.NameToLayer("Wall"));
            playerController.transform.position = wall.point;
            AudioManager.Instance.audioSources[7].Play();
            playerController.GetComponent<Animator>().Play("ChangeRole");
            if (wallUp.transform.CompareTag("WallTop"))
            {
                createMap.SetSquareDeselectAll(createMap.maps[0]);
                playerController.transform.rotation = Quaternion.Euler(180, 0, 0);

            }
            if (wallUp.transform.CompareTag("WallBot"))
            {
                createMap.SetSquareDeselectAll(createMap.maps[1]);
                playerController.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        


    }

   public GameObject ObjectBelow(PlayerController playerController,int direction)
    {
 
        RaycastHit2D wall = Physics2D.Raycast(playerController.raycastPos.position, direction*playerController.transform.up, 50, 1 << LayerMask.NameToLayer("Wall"));
        if (wall)
        {
            return wall.transform.gameObject;
        }
        return null;
    }
}
