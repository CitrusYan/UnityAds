using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class ShowRewardedAdsScript: MonoBehaviour, IUnityAdsListener
{

    Button myButton;
    public string mySurfacingId = "rewardedVideo";
    public Text text;
    int counter = 0;
    void Start()
    {
        myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Ad Unit or legacy Placement’s status:
        myButton.interactable = false;


        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);

    }
    void Update()
    {
        if (LoadRewardedAdsScript.loaded == true)
            EnableButton();

    }

    void EnableButton()
    {
        myButton.interactable = true;

    }
    // Implement a function for showing a rewarded video ad:
    public void ShowRewardedVideo()
    {
        Advertisement.Show(mySurfacingId);
    }


    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string surfacingId)
    {

    }

    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished && mySurfacingId == surfacingId)
        {
            // Reward the user for watching the ad to completion.
            Debug.Log("rewarded ad finished");
            counter++;
            text.text = counter.ToString();
        }
        else if (showResult == ShowResult.Skipped && mySurfacingId == surfacingId)
        {
            Debug.Log("rewarded ad skipped");

            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed &&  mySurfacingId == surfacingId)
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
}