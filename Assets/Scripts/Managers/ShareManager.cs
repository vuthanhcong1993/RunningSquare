using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using EasyMobile;

public class ShareManager : MonoBehaviour
{

    string screenShotName = "ScreenShot";
    string shareMessage = "Fighting ! ";

    public void ShareScreenShot()
    {
        StartCoroutine(Sharing());
    }

    IEnumerator Sharing()
    {
        yield return new WaitForEndOfFrame();
        MobileNativeShare.ShareScreenshot(screenShotName, shareMessage);
    }
}