//using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        //Facebook.Unity.FB.Init();
        //GameAnalytics.Initialize();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Main");
    }

 
}
