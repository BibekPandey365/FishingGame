using GoogleMobileAds.Api;
using UnityEngine;
using System;

public class AdManager : MonoBehaviour
{
    [Header("Android Ads")]
    [SerializeField] String androidBannerAdCode = "ca-app-pub-3940256099942544/6300978111";
    [SerializeField] String androidInterstitialAdCode = "ca-app-pub-3940256099942544/1033173712";
    [SerializeField] String androidAppOpenAdCode = "ca-app-pub-3940256099942544/3419835294";

    [Header("IOS Ads")]
    [SerializeField] String iosBannerAdCode = "ca-app-pub-3940256099942544/2934735716";
    [SerializeField] String iosInterstitialAdCode = "ca-app-pub-3940256099942544/4411468910";
    [SerializeField] String iosAppOpenAdCode = "ca-app-pub-3940256099942544/5662855259";


    string bannerAdCode;
    string interstitialAdCode;
    string appOpenAdCode;

    private BannerView bannerAd;

    private InterstitialAd interstitial;

    private AppOpenAd appOpenAd;
    private bool isShowingAppOpenAd = false;
    private static bool isAppOpenAdShown = false;

    public static AdManager instance;

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            bannerAdCode = androidBannerAdCode;
            interstitialAdCode = androidInterstitialAdCode;
            appOpenAdCode = androidAppOpenAdCode;
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            bannerAdCode = iosBannerAdCode;
            interstitialAdCode = iosInterstitialAdCode;
            appOpenAdCode = iosAppOpenAdCode;
        }
        else
        {
            bannerAdCode = "unexpected_device";
            interstitialAdCode = "unexpected_device";
            appOpenAdCode = "unexpected_device";
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

        this.LoadAppOpenAd();
        this.ShowAppOpenAdIfAvailable();
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


    #region AppOpenAd

    private bool IsAppOpenAdAvailable
    {
        get
        {
            return appOpenAd != null;
        }
    }

    public void LoadAppOpenAd()
    {
        string adUnitId = appOpenAdCode;

        AdRequest request = new AdRequest.Builder().Build();

        // Load an app open ad for portrait orientation
        AppOpenAd.LoadAd(adUnitId, ScreenOrientation.Portrait, request, ((appOpenAd, error) =>
        {
            if (error != null)
            {
                // Handle the error.
                Debug.LogFormat("Failed to load the ad. (reason: {0})", error.LoadAdError.GetMessage());
                return;
            }

            // App open ad is loaded.
            this.appOpenAd = appOpenAd;
        }));
    }

    public void ShowAppOpenAdIfAvailable()
    {
        if (!IsAppOpenAdAvailable || isShowingAppOpenAd || isAppOpenAdShown)       //// isAppOpenAdShown
        {
            return;
        }

        appOpenAd.OnAdDidDismissFullScreenContent += HandleAdDidDismissFullScreenContent;
        appOpenAd.OnAdFailedToPresentFullScreenContent += HandleAdFailedToPresentFullScreenContent;
        appOpenAd.OnAdDidPresentFullScreenContent += HandleAdDidPresentFullScreenContent;
        appOpenAd.OnAdDidRecordImpression += HandleAdDidRecordImpression;
        appOpenAd.OnPaidEvent += HandlePaidEvent;

        appOpenAd.Show();
        isAppOpenAdShown = true;        ////
    }

    private void HandleAdDidDismissFullScreenContent(object sender, EventArgs args)
    {
        Debug.Log("Closed app open ad");
        // Set the ad to null to indicate that AppOpenAdManager no longer has another ad to show.
        appOpenAd = null;
        isShowingAppOpenAd = false;
        LoadAppOpenAd();
    }

    private void HandleAdFailedToPresentFullScreenContent(object sender, AdErrorEventArgs args)
    {
        Debug.LogFormat("Failed to present the ad (reason: {0})", args.AdError.GetMessage());
        // Set the ad to null to indicate that AppOpenAdManager no longer has another ad to show.
        appOpenAd = null;
        LoadAppOpenAd();
    }

    private void HandleAdDidPresentFullScreenContent(object sender, EventArgs args)
    {
        Debug.Log("Displayed app open ad");
        isShowingAppOpenAd = true;
    }

    private void HandleAdDidRecordImpression(object sender, EventArgs args)
    {
        Debug.Log("Recorded ad impression");
    }

    private void HandlePaidEvent(object sender, AdValueEventArgs args)
    {
        Debug.LogFormat("Received paid event. (currency: {0}, value: {1}",
                args.AdValue.CurrencyCode, args.AdValue.Value);
    }

    #endregion
}