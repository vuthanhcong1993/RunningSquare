﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;
using EasyMobile;

namespace EasyMobile.Demo
{
    public class AdvertisingDemo : MonoBehaviour
    {
        public GameObject curtain;
        public GameObject isAutoLoadInfo;
        public GameObject isAdRemovedInfo;
        public Text defaultBannerAdNetwork;
        public Text defaultInterstitialAdNetwork;
        public Text defaultRewardedAdNetwork;
        public GameObject isInterstitialAdReadyInfo;
        public GameObject isRewardedAdReadyInfo;
        public DemoUtils demoUtils;

        void OnEnable()
        {
            AdManager.RewardedAdSkipped += AdManager_RewardedAdSkipped;
            AdManager.RewardedAdCompleted += AdManager_RewardedAdCompleted;
            AdManager.InterstitialAdCompleted += AdManager_InterstitialAdCompleted;    
        }

        void OnDisable()
        {
            AdManager.RewardedAdSkipped -= AdManager_RewardedAdSkipped;
            AdManager.RewardedAdCompleted -= AdManager_RewardedAdCompleted;
            AdManager.InterstitialAdCompleted -= AdManager_InterstitialAdCompleted;  
        }

        void AdManager_InterstitialAdCompleted(InterstitialAdNetwork arg1, AdLocation arg2)
        {
            MobileNativeUI.Alert("Interstitial Ad Completed", "Interstitial ad has been closed.");
        }

        void AdManager_RewardedAdCompleted(RewardedAdNetwork arg1, AdLocation arg2)
        {
            MobileNativeUI.Alert("Rewarded Ad Completed", "The rewarded ad has completed, this is when you should reward the user.");
        }

        void AdManager_RewardedAdSkipped(RewardedAdNetwork arg1, AdLocation arg2)
        {
            MobileNativeUI.Alert("Rewarded Ad Skipped", "The rewarded ad was skipped, and the user shouldn't get the reward.");
        }

        void Start()
        {
            curtain.SetActive(!EM_Settings.IsAdModuleEnable);

            AdSettings.DefaultAdNetworks defaultNetworks = new AdSettings.DefaultAdNetworks(BannerAdNetwork.None, InterstitialAdNetwork.None, RewardedAdNetwork.None);

            #if UNITY_ANDROID
            defaultNetworks = EM_Settings.Advertising.AndroidDefaultAdNetworks;
            #elif UNITY_IOS
            defaultNetworks = EM_Settings.Advertising.IosDefaultAdNetworks;
            #endif

            defaultBannerAdNetwork.text = "Default banner ad network: " + defaultNetworks.bannerAdNetwork.ToString();
            defaultInterstitialAdNetwork.text = "Default interstitial ad network: " + defaultNetworks.interstitialAdNetwork.ToString();
            defaultRewardedAdNetwork.text = "Default rewarded ad network: " + defaultNetworks.rewardedAdNetwork.ToString();

        }

        void Update()
        {
            // Check if autoLoad is enabled.
            if (AdManager.IsAutoLoadDefaultAds())
            {
                demoUtils.DisplayBool(isAutoLoadInfo, true, "Auto load default ads: ON");
            }
            else
            {
                demoUtils.DisplayBool(isAutoLoadInfo, false, "Auto load default ads: OFF");
            }

            // Check if ads were removed.
            if (AdManager.IsAdRemoved())
            {
                demoUtils.DisplayBool(isAdRemovedInfo, false, "Ads were removed");
            }
            else
            {
                demoUtils.DisplayBool(isAdRemovedInfo, true, "Ads are enabled");
            }

            // Check if interstitial ad is ready.
            if (AdManager.IsInterstitialAdReady())
            {
                demoUtils.DisplayBool(isInterstitialAdReadyInfo, true, "isInterstitialAdReady: TRUE");
            }
            else
            {
                demoUtils.DisplayBool(isInterstitialAdReadyInfo, false, "isInterstitialAdReady: FALSE");
            }

            // Check if rewarded ad is ready.
            if (AdManager.IsRewardedAdReady())
            {
                demoUtils.DisplayBool(isRewardedAdReadyInfo, true, "isRewardedAdReady: TRUE");
            }
            else
            {
                demoUtils.DisplayBool(isRewardedAdReadyInfo, false, "isRewardedAdReady: FALSE");
            }
        }

        /// <summary>
        /// Shows the default banner ad at the bottom of the screen.
        /// </summary>
        public void ShowBannerAd()
        {
            if (AdManager.IsAdRemoved())
            {
                MobileNativeUI.Alert("Alert", "Ads were removed.");
                return;
            }
            AdManager.ShowBannerAd(BannerAdPosition.Bottom);
        }

        /// <summary>
        /// Hides the default banner ad.
        /// </summary>
        public void HideBannerAd()
        {
            AdManager.HideBannerAd();
        }

        /// <summary>
        /// Loads the interstitial ad.
        /// </summary>
        public void LoadInterstitialAd()
        {
            if (AdManager.IsAutoLoadDefaultAds())
            {
                MobileNativeUI.Alert("Alert", "autoLoadDefaultAds is currently enabled. Ads will be loaded automatically in background without you having to do anything.");
            }

            AdManager.LoadInterstitialAd();
        }

        /// <summary>
        /// Shows the interstitial ad.
        /// </summary>
        public void ShowInterstitialAd()
        {
            if (AdManager.IsAdRemoved())
            {
                MobileNativeUI.Alert("Alert", "Ads were removed.");
                return;
            }

            if (AdManager.IsInterstitialAdReady())
            {
                AdManager.ShowInterstitialAd();
            }
            else
            {
                MobileNativeUI.Alert("Alert", "Interstitial ad is not loaded.");
            }
        }

        /// <summary>
        /// Loads the rewarded ad.
        /// </summary>
        public void LoadRewardedAd()
        {
            if (AdManager.IsAutoLoadDefaultAds())
            {
                MobileNativeUI.Alert("Alert", "autoLoadDefaultAds is currently enabled. Ads will be loaded automatically in background without you having to do anything.");
            }

            AdManager.LoadRewardedAd();
        }

        /// <summary>
        /// Shows the rewarded ad.
        /// </summary>
        public void ShowRewardedAd()
        {
            if (AdManager.IsRewardedAdReady())
            {
                AdManager.ShowRewardedAd();
            }
            else
            {
                MobileNativeUI.Alert("Alert", "Rewarded ad is not loaded.");
            }
        }

        /// <summary>
        /// Removes the ads.
        /// </summary>
        public void RemoveAds()
        {
            AdManager.RemoveAds();
            MobileNativeUI.Alert("Alert", "Ads were removed. Future ads won't be shown except rewarded ads.");
        }

        /// <summary>
        /// Resets the remove ads.
        /// </summary>
        public void ResetRemoveAds()
        {
            AdManager.ResetRemoveAds();
            MobileNativeUI.Alert("Alert", "Remove Ads status was reset. Ads will be shown normally.");
        }
    }
}

