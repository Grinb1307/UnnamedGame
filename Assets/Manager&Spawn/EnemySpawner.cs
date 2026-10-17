using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemySpawnPegasus;

    public GameObject EnemySpawnPlane;
    public float minX = -3.4f;
    public float maxX = 2.1f;
    public float minY = -5.3f;
    public float maxY = 4.76f;

    private float CheckTime = 0f;

    private float countPegasus = 0f;

    private float count_spawner = 0f;
    bool CheckFirstCalled = false;



    void Update()
    {
        if (count_spawner <= 11f)
        {

            SpawnFor3s();
        }
    }

    Vector3 RandomPosition()
    {
        float randomX = Random.Range(minX + 0.5f, maxX - 0.5f);
        float randomY = Random.Range(maxY, maxY + 4f);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
        return spawnPosition;
    }
    void SpawnFor3s()
    {
        if (!CheckFirstCalled)
        {
            SpawnPegasus();
            CheckFirstCalled = true;
        }
        else
        {
            CheckTime += Time.deltaTime;
            if (CheckTime > 3f)
            {
                SpawnPlane();
                if (countPegasus <= 6f)
                {
                    SpawnPegasus();
                }
                CheckTime = 0f;
            }
        }
        Debug.Log(count_spawner);
    }
    void SpawnPegasus()
        {
            Vector3 spawnPosition = RandomPosition();

            // Sinh ra GameObject tại vị trí ngẫu nhiên
            Instantiate(EnemySpawnPegasus, spawnPosition, Quaternion.Euler(0, 0, -180));
            countPegasus++;
            count_spawner++;
        }

        void SpawnPlane()
        {
            if (countPegasus >= 6f)
            {
                Vector3 spawnPosition = RandomPosition();
                // Sinh ra GameObject tại vị trí ngẫu nhiên
                Instantiate(EnemySpawnPlane, spawnPosition, Quaternion.Euler(0, 0, -180));
                count_spawner++;
            }
        }
}