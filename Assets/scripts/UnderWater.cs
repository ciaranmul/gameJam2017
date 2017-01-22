using UnityEngine;
using System.Collections;

public class UnderWater : MonoBehaviour
{

    //This script enables underwater effects. Attach to main camera.

    //Define variable
    public float UnderwaterLevel = RisingWater.WaterHeight;

    //The scene's default fog settings
    private Material noSkybox;

    void Start()
    {
        //Set the background color
        GetComponent<Camera>().backgroundColor = new Color(0, 0.4f, 0.7f, 1);
    }

    void Update()
    {
        if (transform.position.y < RisingWater.WaterHeight)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = new Color(0, 0.4f, 0.7f, 0.6f);
            RenderSettings.fogDensity = 0.04f;
            RenderSettings.skybox = noSkybox;
        }
        else
        {
            RenderSettings.fog = false;
        }
    }
}