using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
/*
    string appid = "ca-app-pub-7490973564927547~7355343357";


    string bannerAdId = "ca-app-pub-3940256099942544/6300978111";
    string InterstitialAdID = "ca-app-pub-3940256099942544/1033173712";
 */
public class AdMobManager : MonoBehaviour
{
    public string android_banner_id;

    public string android_interstitial_id;

    private BannerView bannerView;
    private InterstitialAd interstitialAd;

    public void Start()
    {
        if (SceneManager.GetActiveScene().name != "Main")
        {
            RequestBannerAd();
        }

        RequestInterstitialAd();

        if(SceneManager.GetActiveScene().name != "Main")
        {
            ShowBannerAd();
        }
    }

    public void RequestBannerAd()
    {
        string adUnitId = string.Empty;

#if UNITY_ANDROID
        adUnitId = android_banner_id;
#elif UNITY_IOS
        adUnitId = ios_bannerAdUnitId;
#endif

        // bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();

        // bannerView.LoadAd(request);
    }
    public void ReqInterstital()
    {
        RequestInterstitialAd();
    }
    private void RequestInterstitialAd()
    {
        string adUnitId = string.Empty;

#if UNITY_ANDROID
        adUnitId = android_interstitial_id;
#elif UNITY_IOS
        adUnitId = ios_interstitialAdUnitId;
#endif

        interstitialAd = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();

        interstitialAd.LoadAd(request);

        interstitialAd.OnAdClosed += HandleOnInterstitialAdClosed;
    }

    public void HandleOnInterstitialAdClosed(object sender, EventArgs args)
    {
        print("HandleOnInterstitialAdClosed event received.");

        interstitialAd.Destroy();

        RequestInterstitialAd();
    }

    public void ShowBannerAd()
    {
        //bannerView.Show();
    }

    public void ShowInterstitialAd()
    {
        if (!interstitialAd.IsLoaded())
        {
            RequestInterstitialAd();
            return;
        }
        if(UnityEngine.Random.Range(0,9)%2 == 0)
            interstitialAd.Show();
    }

}
