using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab; // Prefab of the pickup to spawn
    public float spawnInterval = 2f; // Time between each spawn
    public float spawnRangeX = 8f; // Range of X axis for spawning pickups
    public float spawnRangeY = 5f; // Starting Y position for spawning pickups

    private void Start()
    {
        InvokeRepeating("SpawnPickup", spawnInterval, spawnInterval);
    }

    private void SpawnPickup()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, spawnRangeY);
        Instantiate(pickupPrefab, spawnPosition, Quaternion.identity);
    }
}
