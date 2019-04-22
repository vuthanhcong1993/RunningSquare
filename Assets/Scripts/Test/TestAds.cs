using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;
using System;

public class TestAds : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
       
        AdManager.LoadInterstitialAd();
        AdManager.LoadRewardedAd();
        ShowBanner();
        
    }

    private void InterstitialAdCompletedHandler(InterstitialAdNetwork network, AdLocation location)
    {
        Debug.Log("Interstitial closed");
    }

    private void OnEnable()
    {
        AdManager.InterstitialAdCompleted += InterstitialAdCompletedHandler;
        AdManager.RewardedAdCompleted += RewardedAdCompletedHandler;
        AdManager.AdsRemoved += AdsRemovedHandler;
    }

    void AdsRemovedHandler()
    {
        Debug.Log("Ads were removed.");
        // Unsubscribe
        AdManager.AdsRemoved -= AdsRemovedHandler;
    }

    private void RewardedAdCompletedHandler(RewardedAdNetwork network, AdLocation location)
    {
        Debug.Log("reward complete");
    }

    private void OnDisable()
    {
        AdManager.InterstitialAdCompleted -= InterstitialAdCompletedHandler;
        AdManager.RewardedAdCompleted -= RewardedAdCompletedHandler;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowBanner()
    {
        if (AdManager.IsAdRemoved())
        {
            return;
        }
        AdManager.ShowBannerAd(BannerAdPosition.Top);
    }

    public void HideBanner()
    {
        AdManager.HideBannerAd();
    }

    public void ShowInterstitial()
    {
        if (AdManager.IsAdRemoved())
        {
            return;
        }
        bool isReady = AdManager.IsInterstitialAdReady();
        if (isReady)
        {
            AdManager.ShowInterstitialAd();
        }
    }

    public void ShowReward()
    {
        bool isReady = AdManager.IsRewardedAdReady();
        if (isReady)
        {
            AdManager.ShowRewardedAd();
        }
    }

    public void RemoveAds()
    {
       
        AdManager.RemoveAds();
    }

    public void ResetRemoveAds()
    {
        AdManager.ResetRemoveAds();
    }


}
