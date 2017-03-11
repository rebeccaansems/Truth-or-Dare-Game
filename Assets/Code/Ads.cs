using UnityEngine;
#if UNITY_ADS
using UnityEngine.Advertisements; // only compile Ads code on supported platforms
#endif

public class Ads : MonoBehaviour
{
    public void ShowAd()
    {
#if UNITY_ADS
        if (!Advertisement.IsReady())
        {
            Debug.Log("Ads not ready for default placement");
            return;
        }

        Advertisement.Show();
#endif
    }
}