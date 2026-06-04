using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float startSpawntime = 3f;
    public float spawninterval = 2.5f;
    public Transform SpawnPosition;

    private float nextspawnTime;

    private void Start()
    {
        nextspawnTime = Time.time + startSpawntime;
    }
    private void Update()
    {
        if(nextspawnTime < Time.time)
        {
            nextspawnTime = Time.time + spawninterval;
            GameObject nextCube = 
                Instantiate<GameObject>
                (prefabs[Random.Range(0,prefabs.Length)],SpawnPosition.position,SpawnPosition.rotation);

        }
    }
}
