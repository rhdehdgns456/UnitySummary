using UnityEngine;
using UnityEngine.EventSystems;

public class MaterialChanger : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Material material;               // 바꾸고싶은 메터리얼
    public MeshRenderer meshRenderer;       // 게임오브젝트의 메쉬를 그리는 컴포넌트.
    public Color enterColor;                // 포인터로 가리키고 있을 때 바꾸고 싶은 색
    public float offsetSpeed = 1f;
    public float currentOffset;
    private Color defaultColor;             // 처음 색
    private bool isSelected;                 // 선택되어 있는지 여부

    // 게임오브젝트가 활성화 되는 처음에 한번만 호출
    void Start()
    {
        //게임오브젝트 안에 있는 메쉬렌더러를 찾아서 변수에 넣어라

        meshRenderer = GetComponent<MeshRenderer>();
        //렌더러 안에 메터리얼 변수를 찾아서 내가 원하는 메터리얼로 변경
        meshRenderer.material = material;
        defaultColor = meshRenderer.material.color; 
    }
    private void Update()
    {
        currentOffset = currentOffset + offsetSpeed * Time.deltaTime;
        meshRenderer.material.mainTextureOffset = new Vector2(currentOffset, 0f);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;
        if (isSelected == true)
        {
            meshRenderer.material.EnableKeyword("_EMISSION");
        }
        else
        {
            meshRenderer.material.DisableKeyword("_EMISSION");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        meshRenderer.material.color = enterColor;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        meshRenderer.material.color = defaultColor;
    }

}