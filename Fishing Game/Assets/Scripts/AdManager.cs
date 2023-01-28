using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;
using System;

public class AdManager : MonoBehaviour
{
    [Header("Android Ads")]
    [SerializeField] String androidBannerAdCode = "ca-app-pub-3940256099942544/6300978111";
    [SerializeField] String androidInterstitialAdCode = "ca-app-pub-3940256099942544/1033173712";

    [Header("IOS Ads")]
    [SerializeField] String iosBannerAdCode = "ca-app-pub-3940256099942544/2934735716";
    [SerializeField] String iosInterstitialAdCode = "ca-app-pub-3940256099942544/4411468910";


    string bannerAdCode;
    string interstitialAdCode;

    private BannerView bannerAd;

    private InterstitialAd interstitial;

    public static AdManager instance;

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            bannerAdCode = androidBannerAdCode;
            interstitialAdCode = androidInterstitialAdCode;
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            bannerAdCode = iosBannerAdCode;
            interstitialAdCode = iosInterstitialAdCode;
        }
        else
        {
            bannerAdCode = "unexpected_device";
            interstitialAdCode = "unexpected_device";
        }


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });

        this.RequestBanner();

    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    private void RequestBanner()
    {
        string adUnitId = bannerAdCode;
        this.bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Clean up banner ad before creating a new one.
        if (this.bannerAd != null)
        {
            this.bannerAd.Destroy();
        }

        // Create a 320x50 banner at the bottom of the screen.
        this.bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Load a banner ad.
        this.bannerAd.LoadAd(this.CreateAdRequest());
    }

    public void RequestInterstitial()
    {

        string adUnitId = interstitialAdCode;
        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
            this.interstitial.Destroy();

        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);

        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    public void ShowInterstitial()
    {
        if (this.interstitial == null) { return; }

        if (this.interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            Debug.Log("Inerstitial Ad is not ready yet");
        }
    }

}