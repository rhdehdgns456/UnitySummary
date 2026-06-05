using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject effect;
    public float lifetime = 10f;

    private float deadtime;
    void Start()
    {
        deadtime = Time.time + lifetime;
    }

      void Update()
  {
     if (deadtime < Time.time)
       {
           Destroy(gameObject);
       }
   }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate<GameObject>(effect, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal));   
        Destroy (gameObject);

    }
}
