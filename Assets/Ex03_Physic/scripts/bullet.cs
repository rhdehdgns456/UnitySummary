using UnityEngine;

public class bullet : MonoBehaviour
{
    public float lifetime = 10f;

    private float deadtime;
    void Start()
    {
        deadtime = Time.time + lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        if (deadtime < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
