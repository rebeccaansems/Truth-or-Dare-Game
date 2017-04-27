using System.Collections;
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
        StartCoroutine("Check");
    }

    IEnumerator Check()
    {
        while (!Advertisement.isInitialized || !Advertisement.IsReady())
        {
            yield return new WaitForSeconds(0.5f);
        }
        if (Advertisement.IsReady())
        {

            questionsShown++;
            if (questionsShown % 10 == 0)
            {
                Advertisement.Show();
                StopCoroutine("Check");
            }
        }
    }
}