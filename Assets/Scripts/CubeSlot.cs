using UnityEngine;
using UnityEngine.EventSystems;

public class CubeSlot : MonoBehaviour, IDropHandler
{
    private RectTransform _thisRectTransform;
    private RectTransform _droppedCubeRectTransform;

    private void Awake() => _thisRectTransform = GetComponent<RectTransform>();

    public void OnDrop(PointerEventData eventData)
    {     
        _droppedCubeRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
        _droppedCubeRectTransform.position = _thisRectTransform.position;          
    }
}