using UnityEngine;

using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class GoogleMobileAdsDemoScript : MonoBehaviour
{

    public void Start()
    {
        // Load an app open ad when the scene starts
        AppOpenAdManager.Instance.LoadAd();

        // Listen to application foreground and background events.
        AppStateEventNotifier.AppStateChanged += OnAppStateChanged;
    }

    private void OnAppStateChanged(AppState state)
    {
        // Display the app open ad when the app is foregrounded.
        UnityEngine.Debug.Log("App State is " + state);
        if (state == AppState.Foreground)
        {
            AppOpenAdManager.Instance.ShowAdIfAvailable();
        }
    }
}