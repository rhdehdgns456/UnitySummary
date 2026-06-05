using Unity.Cinemachine;
using UnityEngine;

public class CinemachineRotator : MonoBehaviour
{
    public float rotateSpeed = 1f;  
    private CinemachineOrbitalFollow follow;

    void Start()
    {
        follow = GetComponent<CinemachineOrbitalFollow>();  
    }

    // Update is called once per frame
    void Update()
    {
        follow.HorizontalAxis.Value = follow.HorizontalAxis.Value + rotateSpeed * Time.deltaTime;
    }
}
