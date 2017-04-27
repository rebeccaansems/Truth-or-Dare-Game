using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    void Start()
    {
#if UNITY_ANDROID
        Advertisement.Initialize("1340928");
#elif UNITY_IOS
        Advertisement.Initialize("1340919");
#endif
    }


    int questionsShown = 0;
    public void ShowAd()
    {
        if (!Advertisement.IsReady())
        {
            Debug.Log("Ads not ready for default placement");
            return;
        }

        questionsShown++;
        if (questionsShown % 15 == 0)
        {
            Advertisement.Show();
        }
    }
}