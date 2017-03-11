using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    public void ShowAd()
    {
        if (!Advertisement.IsReady())
        {
            Debug.Log("Ads not ready for default placement");
            return;
        }

        Advertisement.Show();
    }
}