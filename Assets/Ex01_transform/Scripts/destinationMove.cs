using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class destinationMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotateSpeed = 360f;
    public LayerMask detectLayer; // 감지하고 싶은 레이어 
    public bool isPressed = false;
    private Vector3 destination; //목적지
    private Quaternion toward; //목적지 방향
    public void OnPick(InputValue value)
    {
        isPressed = value.isPressed;
        Debug.Log($"마우스 왼쪽 버튼 => {isPressed}");
    }
    // Update is called once per frame
    void Update()
    {
        //마우스 왼쪽 버튼이 눌려져있는 상태에서만 발동
        if (isPressed)
        {
            //카메라 기준에서 마우스 포인터의 위치에 Ray 생성.
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            //생성된 Ray를 발사해 위치 확인.
            if (Physics.Raycast(ray, out RaycastHit hit,100f, detectLayer))
            {
                 destination = hit.point;
                Vector3 direction = destination - transform.position;
                if (Vector3.SqrMagnitude(direction) > 0.001f)
                {
                    // lookrotation => 방향단위 벡터를 넣어주면 그 방향으로 회전해야하는 회전값을 계산해서 알려줌.
                    toward = Quaternion.LookRotation(direction.normalized, Vector3.up);
                }
                    
            }
        }
        //현재 위치에서 목표 위치를 향해 이동속도만큼 이동한 결과 위치를  계산해서 알려줌.
        Vector3 position = Vector3.MoveTowards(transform.position, destination, moveSpeed*Time.deltaTime);

        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, toward, rotateSpeed * Time.deltaTime);
        //이동할 위치와 방향으로 적용
        //transform.position = position;  
        //transform.rotation = rotation;
        transform.SetPositionAndRotation(position,rotation);
    }
}
