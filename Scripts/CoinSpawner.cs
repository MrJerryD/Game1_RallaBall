using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Префаб монеты
    public float spawnInterval = 3f; // Интервал между спаунами монет

    private GameObject ground; // Ссылка на объект "Ground"
    private Bounds groundBounds; // Границы объекта "Ground"

    private void Start()
    {
        ground = GameObject.Find("Ground"); // Ищем объект "Ground" в сцене

        if (ground != null)
        {
            // Получаем границы объекта "Ground"
            Renderer groundRenderer = ground.GetComponent<Renderer>();
            groundBounds = groundRenderer.bounds;

            // Запускаем корутину для создания монет
            StartCoroutine(SpawnCoins());
        }
        else
        {
            Debug.LogError("No 'Ground' object found in the scene!");
        }
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            // Создаем монету
            GameObject coin = Instantiate(coinPrefab, GetRandomSpawnPosition(), Quaternion.identity);

            // Ждем указанный интервал времени
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Получаем случайные координаты в пределах границ объекта "Ground"
        Vector3 randomPosition = new Vector3(
            Random.Range(groundBounds.min.x, groundBounds.max.x),
            transform.position.y,
            Random.Range(groundBounds.min.z, groundBounds.max.z)
        );

        return randomPosition;
    }
}
