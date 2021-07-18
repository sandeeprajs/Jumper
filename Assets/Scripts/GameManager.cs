using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    #region Varibles
    [SerializeField]
    private GameObject player, platform;

    [SerializeField]
    private float minx = -2.97f, maxX = 2.97f, minY = -2.5f, maxY = -3.9f;

    private float lerpX, lerpTime = 1.5f;
    private bool lerpCamera;

    private Text scoreText;
    private int score;
    #endregion

    #region Main Methods
    // Use this for initialization
    void Start()
    {
        CreateInitialPlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        if(lerpCamera)
        {
            LerpTheCamera();
        }
    }
    #endregion

    #region Unity Utilities
    void CreateInitialPlatforms ()
    {
        //Frist Platform
        Vector3 temp = new Vector3(Random.Range(minx, minx + 1.2f), Random.Range(minY, minY), 0);

        Instantiate(platform, temp, Quaternion.identity);        

        //Character
        temp.y += 5f;

        Instantiate(player, temp, Quaternion.identity);

        //Second Platform
        temp = new Vector3(Random.Range(maxX, maxX - 1.2f), Random.Range(minY, maxY), 0);

        Instantiate(platform, temp, Quaternion.identity);
    }

    //Create New Platfrom at a distance
    public void CreateNewPlatform ()
    {
        float cameraX = Camera.main.transform.position.x;

        float newMaxX = (maxX * 2f) + cameraX;
        Debug.Log("Max" + maxX);
        Debug.Log("New Max" + newMaxX);

        Instantiate(platform, new Vector3(Random.Range(newMaxX, newMaxX - 0.5f), Random.Range(maxY, maxY - 1.2f), 0), Quaternion.identity);
    }

    // Call Newly Created Platform and lerp the camera
    public void CreateNewPlatfromAndLerp (float lerpPosition)
    {
        CreateNewPlatform();

        lerpX = lerpPosition + maxX;
        lerpCamera = true;
    }

    //Lerping Camera
    void LerpTheCamera ()
    {
        float x = Camera.main.transform.position.x;

        x = Mathf.Lerp(x, lerpX, lerpTime * Time.deltaTime);

        Camera.main.transform.position = new Vector3(x, Camera.main.transform.position.y, Camera.main.transform.position.z);

        if(Camera.main.transform.position.x > (lerpX - 0.2f))
        {
            lerpCamera = false;
        }
    }

    public void IncrementScore ()
    {
        score++;
        scoreText.text = "" + score.ToString();
    }
    #endregion
}
