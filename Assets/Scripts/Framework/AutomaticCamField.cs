using UnityEngine;

public class AutomaticCamField : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
        Camera cam = Camera.main;
        float defaultFieldOfView = cam.fieldOfView;
        float screenSize = Screen.height / (float)Screen.width;

        float targetaspect = 9f / 16f;
        float windowaspect = (float)Screen.width / (float)Screen.height;

        float scaleheight = windowaspect / targetaspect;
        Camera camera = Camera.main;
        float proportion;
        if (scaleheight < 1.0f)
        {
            proportion = defaultFieldOfView * ((1.0f - scaleheight) / 2.0f);
            camera.fieldOfView = defaultFieldOfView + proportion;
        }
        else
        {
            float scalewidth = 1.0f / scaleheight;
            proportion = defaultFieldOfView * ((1.0f - scalewidth) / 2.0f);

            camera.fieldOfView = defaultFieldOfView - proportion;
        }
    } 
}
