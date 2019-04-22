using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;
using System;

public class AdsManager : Singleton<AdsManager> {

    [SerializeField] private PlayerController playerController = null; 
     [SerializeField] private UIFinish uIFinish = null;

    private bool isLoadInterstitial = false;
    private BannerAdNetwork[] banners = null;

    private void Awake()
    {
        GameManager.Instance.isRemoveAds = PlayerPrefs.GetInt("RemoveAds");
        if (GameManager.Instance.isRemoveAds == 1)
        {
            return;
        }
       
        InvokeRepeating("LoadNow", 110, 110);
        ShowBanner(BannerAdPosition.Top);
    }
   

    void LoadNow()
    {
        if (!isLoadInterstitial)
        {
            isLoadInterstitial = true;
        }
        
    }

    private void OnEnable()
    {
        AdManager.InterstitialAdCompleted += InterstitialAdCompletedHandler;
        AdManager.RewardedAdCompleted += RewardedAdCompletedHandler;
        AdManager.RewardedAdSkipped += AdManager_RewardedAdSkipped;
        AdManager.AdsRemoved += AdsRemovedHandler;
        
    }

   

    private void OnDisable()
    {
        AdManager.InterstitialAdCompleted -= InterstitialAdCompletedHandler;
        AdManager.RewardedAdCompleted -= RewardedAdCompletedHandler;
    }

    public void SetBannerOnTop()
    {
        if (AdManager.IsAdRemoved())
        {
            return;
        }
        banners = AdManager.GetActiveBannerAdNetworks();
        if (banners.Length >1)
        {
            for (int i = 0; i < banners.Length; i++)
            {
                AdManager.DestroyBannerAd(banners[i]);
            }
            ShowBanner(BannerAdPosition.Top);
        }
       
    }
   

    public void ShowBanner(BannerAdPosition pos )
    {
        if (AdManager.IsAdRemoved())
        {
            return;
        }
        AdManager.ShowBannerAd(pos,BannerAdSize.Banner);
    }

    public bool CheckBannerLoad()
    {
        return AdManager.IsShowingBannerAd();
    }

    public void LoadInterstitialAds()
    {
        if (AdManager.IsAdRemoved())
        {
            return;
        }
        if (!isLoadInterstitial)
        {
            return;
        }
        bool isReady = AdManager.IsInterstitialAdReady();
        if (!isReady)
        {
            AdManager.LoadInterstitialAd();
            isLoadInterstitial = false;
        }
     
    }

    public void LoadRewardAds()
    {
       
        bool isReady = AdManager.IsRewardedAdReady();
        if (!isReady)
        {
            AdManager.LoadRewardedAd();
        }
    }

    public void HideBanner()
    {
        AdManager.HideBannerAd();
    }

    public void DestroyBanner()
    {
        if (AdManager.IsAdRemoved())
        {
            return;
        }
        AdManager.DestroyBannerAd();
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
        if (GameManager.Instance.isRemoveAds == 1)
        {
            Debug.Log("Removed");
        }
        else
        {
            GameManager.Instance.isRemoveAds = 1;
            CancelInvoke("LoadNow");
            PlayerPrefs.SetInt("RemoveAds", GameManager.Instance.isRemoveAds);
            AdManager.RemoveAds();
        }
      
    }

    public void ResetRemoveAds()
    {
        AdManager.ResetRemoveAds();
    }

    public void InterstitialAdCompletedHandler(InterstitialAdNetwork network, AdLocation location)
    {
        Debug.Log("Interstitial closed");
    }

    void AdsRemovedHandler()
    {
        Debug.Log("Ads were removed.");
        // Unsubscribe
        AdManager.AdsRemoved -= AdsRemovedHandler;
    }

    public void RewardedAdCompletedHandler(RewardedAdNetwork network, AdLocation location)
    {
        playerController.SecondChangedOk();
        Debug.Log("reward complete");
    }

    private void AdManager_RewardedAdSkipped(RewardedAdNetwork network, AdLocation location)
    {
        uIFinish.FinishGame(0);
    }

}
