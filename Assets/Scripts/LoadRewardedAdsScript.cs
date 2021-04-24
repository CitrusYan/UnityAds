using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class LoadRewardedAdsScript : MonoBehaviour, IUnityAdsListener
{
    public string mySurfacingId = "rewardedVideo";
    public static bool loaded = false;
    // Initialize the Ads listener and service:
    void Start()
    {

        // Set interactivity to be dependent on the Ad Unit or legacy Placement’s status:
        Advertisement.AddListener(this);

    }

    public void LoadRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(mySurfacingId))
        {
            Advertisement.Load(mySurfacingId);
            Debug.Log(mySurfacingId + " loaded.");
            loaded = true;
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {

    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == mySurfacingId)
        {

            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}