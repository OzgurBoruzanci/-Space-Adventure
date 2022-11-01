using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefabs = default;
    [SerializeField]
    GameObject deadlyPlatformformPrefabs = default;
    [SerializeField]
    GameObject playerPrefabs = default;

    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPosition;
    Vector2 playerPosition;

    [SerializeField]
    float distanceBetweenPlatforms;

    void Start()
    {
        CreatePlatform();
    }

    
    void Update()
    {
        if (platforms[platforms.Count-1].transform.position.y<
            Camera.main.transform.position.y+ScreenCalculator.Instance.Height)
        {
            PlacePlatform();
        }
    }

    void CreatePlatform()
    {
        platformPosition = new Vector2(0, 0);
        playerPosition = new Vector2(0, 0.5f);

        GameObject player=Instantiate(playerPrefabs,playerPosition,Quaternion.identity);
        GameObject firstPlatform= Instantiate(platformPrefabs,platformPosition,Quaternion.identity);
        platforms.Add(firstPlatform);
        NextPlatformPosition();
        firstPlatform.GetComponent<PlatformMove>().Move = true;

        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefabs, platformPosition, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<PlatformMove>().Move = true;
            NextPlatformPosition();
        }

        GameObject deadlyPlatform= Instantiate(deadlyPlatformformPrefabs, platformPosition, Quaternion.identity);
        deadlyPlatform.GetComponent<DeadlyPlatform>().Move = true;
        platforms.Add(deadlyPlatform);
        NextPlatformPosition();
    }

    void PlacePlatform()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPosition;
            NextPlatformPosition();
        }
    }

    void NextPlatformPosition()
    {
        platformPosition.y += distanceBetweenPlatforms;
        float random =Random.Range(0.0f,1.0f);
        if (random<0.5f)
        {
            platformPosition.x = ScreenCalculator.Instance.Width / 2;
        }
        else
        {
            platformPosition.x = -ScreenCalculator.Instance.Width / 2;
        }
    }

}
