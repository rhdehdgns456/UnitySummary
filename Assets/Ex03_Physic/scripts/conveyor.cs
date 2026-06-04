using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class conveyor : MonoBehaviour
{
    public float moveSpeed = 1f;
    public List<Rigidbody> rigidList = new();
    private void OnTriggerEnter(Collider other)
    {
        if(rigidList.Contains(other.attachedRigidbody))
            return;

        rigidList.Add(other.attachedRigidbody);
    }
    private void OnTriggerExit(Collider other)
    {
        if(!rigidList.Contains(other.attachedRigidbody))
            return;
        
        rigidList.Remove(other.attachedRigidbody);
    }
    private void FixedUpdate()
    {
        foreach(Rigidbody r in rigidList)
        {
            r.MovePosition(r.position + transform.forward*moveSpeed*Time.deltaTime);
        }
    }
}
