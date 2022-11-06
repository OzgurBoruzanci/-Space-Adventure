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
    [SerializeField]
    GameObject platform2Prefabs = default;

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
        player.transform.parent = firstPlatform.transform;
        platforms.Add(firstPlatform);
        NextPlatformPosition();
        firstPlatform.GetComponent<PlatformMove>().Move = true;

        for (int i = 0; i < 7; i++)
        {
            GameObject platform = Instantiate(platformPrefabs, platformPosition, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<PlatformMove>().Move = true;
            if (i%2==0)
            {
                platform.GetComponent<Gold>().goldActive();

            }
            NextPlatformPosition();
        }

        GameObject deadlyPlatform= Instantiate(deadlyPlatformformPrefabs, platformPosition, Quaternion.identity);
        deadlyPlatform.GetComponent<DeadlyPlatform>().Move = true;
        platforms.Add(deadlyPlatform);
        NextPlatformPosition();

        GameObject platform2 = Instantiate(platform2Prefabs, platformPosition, Quaternion.identity);
        platform2.GetComponent<Platform2>().Move = true;
        platforms.Add(platform2);
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
            if (platforms[i + 5].gameObject.tag=="Platform")
            {
                platforms[i + 5].GetComponent<Gold>().goldActiveClose();
                float randomGold = Random.Range(0f, 1.0f);
                if (randomGold>0.5f)
                {
                    platforms[i + 5].GetComponent<Gold>().goldActive();
                }
            }
            NextPlatformPosition();
        }
    }

    void NextPlatformPosition()
    {
        platformPosition.y += distanceBetweenPlatforms;
        SequentialPosition();
    }
    
    void MixedPosition()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (random < 0.5f)
        {
            platformPosition.x = ScreenCalculator.Instance.Width / 2;
        }
        else
        {
            platformPosition.x = -ScreenCalculator.Instance.Width / 2;
        }
    }

    bool direction = true;
    void SequentialPosition()
    {
        if (direction)
        {
            platformPosition.x = ScreenCalculator.Instance.Width / 2;
            direction = false;
        }
        else
        {
            platformPosition.x = -ScreenCalculator.Instance.Width / 2;
            direction=true;
        }
    }
}
