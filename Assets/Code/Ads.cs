using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{

    int questionsShown = 0;
    public void ShowAd()
    {
        if (!Advertisement.IsReady())
        {
            Debug.Log("Ads not ready for default placement");
            return;
        }

        questionsShown++;
        if (questionsShown%15 == 0)
        {
            Advertisement.Show();
        }
    }
}