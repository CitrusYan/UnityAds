using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ShowInterstitialAdsScript : MonoBehaviour, IUnityAdsListener
{
    Button myButton;
    public string mySurfacingId = "interstitialVideo";
    public string status = "initialized";
    public Text text;
    private void Start()
    {
        myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Ad Unit or legacy Placement’s status:
        myButton.interactable = Advertisement.IsReady(mySurfacingId);


        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
    }
    void Update()
    {
        if (LoadInterstitialAdsScript.loaded == true)
            EnableButton();

    }

    void EnableButton()
    {
        myButton.interactable = true;

    }
    public void ShowInterstitialAd()
    {


        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show(mySurfacingId);
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }


    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished && mySurfacingId == surfacingId)
        {
            // Reward the user for watching the ad to completion.
            Debug.Log("interstitial ad finished");
            
            text.text = "Finished";
        }
        else if (showResult == ShowResult.Skipped && mySurfacingId == surfacingId)
        {
            text.text = "Skipped";

            Debug.Log("interstitial ad skipped");

            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed && mySurfacingId == surfacingId)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
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

    public void OnUnityAdsReady(string placementId)
    {
        
    }
}