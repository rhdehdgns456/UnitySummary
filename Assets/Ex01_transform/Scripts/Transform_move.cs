using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Transform_move : MonoBehaviour
{
    public Vector2 input; //인풋 시스템의 move 액션의 값을 저장할 vector2 변수
    public float moveSpeed = 1f; //이동 속도
    public float rotateSpeed = 360f; // 회전 속도
    public bool canRotate = false; // 회전을 적용할지 말지 여부


    //move 액션의 콜백함수(콜백이란?특정 상황에 호출될 함수를 미리 지정해 놓으면 그 상황이 발동될 때 호출되는 함수를 콜백함수라고 함)
    public void OnMove(InputValue Value)
    {
        input = Value.Get<Vector2>();
    }
    private void Update()
    {
        if (canRotate)
        {
            transform.Rotate(Vector3.up * input.x * rotateSpeed * Time.deltaTime, Space.World);
            transform.Translate(new Vector3(0f, 0f, input.y) * moveSpeed * Time.deltaTime);
        }
        else
        {

            //translat함수는 현재 위치에서 이동하고자 하는 방향 *이동거리로 이동시켜주는 함수. 기본값은 해당 게임오브젝트 기준으로 이동함.
            transform.Translate(new Vector3(input.x, 0f, input.y) * moveSpeed * Time.deltaTime);
        }
    }
}
