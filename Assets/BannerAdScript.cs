using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdScript : MonoBehaviour, IUnityAdsListener
{

    public string surfacingId = "banner";

    void Start()
    {
        Advertisement.AddListener(this);
            
    }
    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, activate the button: 
        if (this.surfacingId == surfacingId)
        {
            Advertisement.Banner.SetPosition(BannerPosition.CENTER);
            StartCoroutine(ShowBannerWhenInitialized());
        }
    }

    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        //handle each situation

    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(surfacingId);
    }
}