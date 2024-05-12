using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lightmaker : MonoBehaviour
{
    public GameObject prefab, Plane;

    private float spawnRadius = 3f;

    private List<GameObject> spawnList = new List<GameObject>();

    public void CreatePrefab()
    {
        Vector3 PlaneCenter = Plane.transform.position;

        Vector3 randomPosition = PlaneCenter + Random.insideUnitSphere * spawnRadius;

        Vector3 spawnPosition = new Vector3(
            randomPosition.x,
            randomPosition.y,
            0);

        GameObject spawnedList = Instantiate(prefab, spawnPosition, Quaternion.identity);
        spawnList.Add(spawnedList);
    }

    public void DeleteLastPrefab()
    {
        if(spawnList.Count > 0)
        {
            int lastIndex = spawnList.Count - 1;
            GameObject lastPrefab = spawnList[lastIndex];
            spawnList.RemoveAt(lastIndex);
            Destroy(lastPrefab);
        }
    }
}
