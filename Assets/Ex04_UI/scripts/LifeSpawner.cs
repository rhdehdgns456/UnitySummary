using UnityEditor;
using UnityEngine;

public class LifeSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    private float nextSpawnTime;
    public float spawnDelay = 4f;
    private void Update()
    {
        if (nextSpawnTime < Time.time)
        {
            nextSpawnTime = Time.time + spawnDelay;
            GameObject go = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
            float distance = Random.Range(3f, 9f);
            float height = Random.Range(1f, 5f);
            float angle = Random.Range(0f, 360f);

            go.transform.SetPositionAndRotation(
                Quaternion.Euler(0f, angle, 0f) * Vector3.forward * distance + Vector3.up * height,
                Quaternion.identity);
        }
    }
}
