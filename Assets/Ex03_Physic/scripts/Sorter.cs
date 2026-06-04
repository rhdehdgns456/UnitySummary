using UnityEngine;

public class Sorter : MonoBehaviour
{
    public float power = 300f;
    public string detecttag;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == detecttag)
        {
            other.attachedRigidbody.AddForce(transform.forward * power, ForceMode.VelocityChange);
           // other.attachedRigidbody.AddRelativeForce(Vector3.forward * power, ForceMode.VelocityChange);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
