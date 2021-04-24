using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeSDK: MonoBehaviour
{

    string gameId = "4097068";
    bool testMode = true;

    void Start()
    {
 
    }

    public void Initialize()
    {
        Advertisement.Initialize(gameId, testMode);
        Debug.Log("SDK initialized!");
    }
}