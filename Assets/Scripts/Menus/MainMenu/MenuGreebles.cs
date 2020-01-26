using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGreebles : MonoBehaviour
{
    [Header("Greebles!")]
    [Tooltip("These are all of the objects which will have a chance of spawning throughout the menu -- add at your leisure!")]
    public List<GameObject> staticObjectPrefabs;
    public List<GameObject> flyingObjectPrefabs;

    [Header("Spawn Locations")]
    [Tooltip("These are the locations for objects to spawn at -- please do not touch.")]
    [SerializeField] GameObject[] staticSpawnMarkers;
    [SerializeField] GameObject[] flyingSpawnMarkers;

    [Header("Settings")]
    [Tooltip("This is the amount of time (in seconds) that should pass between greebles flying across the screen.")]
    [SerializeField] [Range(1f, 60f)] float timeBetweenFlyingGreebles = 10f;


    void SpawnGreebles(List<GameObject> greebleType, GameObject[] spawnMarkerType, int prefabNum, int spawnMarkerNum)
    {
        Instantiate(greebleType[prefabNum], spawnMarkerType[spawnMarkerNum].transform.position, greebleType[prefabNum].transform.rotation);
    }

    void Start()
    {
        // For every spawn marker...
        for (int spawnMarker = 0; spawnMarker < staticSpawnMarkers.Length; spawnMarker++)
        {
            // Spawn a randomly selected greeble at that location
            int prefabNumber = Random.Range(0, staticObjectPrefabs.Count);
        	SpawnGreebles(staticObjectPrefabs, staticSpawnMarkers, prefabNumber, spawnMarker);

            staticObjectPrefabs.Remove(staticObjectPrefabs[prefabNumber]); // This prevents duplicates from spawning
        }

        StartCoroutine(FlyingGreebleEvent());
    }

    IEnumerator FlyingGreebleEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenFlyingGreebles);
            SpawnGreebles(flyingObjectPrefabs, flyingSpawnMarkers, Random.Range(0, flyingObjectPrefabs.Count), Random.Range(0, flyingSpawnMarkers.Length));
        }
    }
}
