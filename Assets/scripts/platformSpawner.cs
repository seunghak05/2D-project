using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; // Assign this in the inspector
    public int count = 3;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.25f;

    public float timeBetSpawn;
    public float yMin = -3.5f;
    private float xPos = 20f;

    private GameObject[] platforms;

    private int currentIndex = 0;

    private Vector2 poolPosition = new Vector2(0,-25);
    private float lastSpawnTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platforms = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }
        lastSpawnTime = 0;
        timeBetSpawn = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            float yPos = Random.Range(yMin, -yMin);
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);
            
            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);
            currentIndex++;
        }  

        if(currentIndex >= count)
        {
            currentIndex = 0;
        }
    }
}
