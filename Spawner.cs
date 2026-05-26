// Spawner.cs
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeightedPrefab
{
    public GameObject prefab;
    [Tooltip("Higher weight = higher chance to spawn. (e.g., Common = 100, Rare = 10, Boss = 1)")]
    [Min(1)] public int weight;
}

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [Tooltip("List of prefabs to spawn with their respective weights. Add at least one.")]
    [SerializeField] private WeightedPrefab[] prefabsToSpawn;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private int maxActiveSpawns = 10;

    [Header("Position Settings")]
    [Tooltip("How far from the spawner's center an object can spawn.")]
    [SerializeField] private float spawnRadius = 5f;
    [Tooltip("Should the spawner start spawning as soon as the game starts?")]
    [SerializeField] private bool spawnOnStart = true;

    private List<GameObject> _activeSpawns = new List<GameObject>();
    private float _timer;

    private void Start()
    {
        // If true, forces the timer to trigger immediately on the first frame
        if (spawnOnStart) 
        {
            _timer = spawnInterval; 
        }
    }

    private void Update()
    {
        CleanUpNullSpawns();

        // Pause spawning if we've hit our maximum limit
        if (_activeSpawns.Count >= maxActiveSpawns) return;

        _timer -= Time.deltaTime;
        
        if (_timer <= 0f)
        {
            Spawn();
            _timer = spawnInterval;
        }
    }

    private void Spawn()
    {
        if (prefabsToSpawn.Length == 0)
        {
            Debug.LogWarning($"Spawner '{gameObject.name}' has no prefabs assigned!");
            return;
        }

        // Pick a prefab based on the weighted algorithm
        GameObject prefab = GetRandomWeightedPrefab();
        if (prefab == null) return;
        
        // Calculate a random position within the radius
        Vector3 spawnPosition = transform.position + (Random.insideUnitSphere * spawnRadius);
        spawnPosition.y = transform.position.y; // Keep it on the same horizontal plane

        // Instantiate and track the new object
        GameObject newSpawn = Instantiate(prefab, spawnPosition, Quaternion.identity);
        _activeSpawns.Add(newSpawn);
    }

    
    // Calculates the total weight and returns a random prefab based on individual weights.
    
    private GameObject GetRandomWeightedPrefab()
    {
        int totalWeight = 0;
        foreach (WeightedPrefab wp in prefabsToSpawn)
        {
            totalWeight += wp.weight;
        }

        int randomValue = Random.Range(0, totalWeight);

        foreach (WeightedPrefab wp in prefabsToSpawn)
        {
            randomValue -= wp.weight;
            
            if (randomValue < 0)
            {
                return wp.prefab;
            }
        }

        return null;
    }

    private void CleanUpNullSpawns()
    {
        // Automatically removes destroyed objects from the list so new ones can spawn
        _activeSpawns.RemoveAll(item => item == null);
    }

    // Drawing the visual sphere in the Editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
        Gizmos.DrawSphere(transform.position, spawnRadius);
    }
}
