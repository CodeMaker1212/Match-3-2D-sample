using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class DraggableCube : Cube, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform _thisRectTransform;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Canvas _canvas;
    private Vector3 _startPosition;

    public event UnityAction<string> DroppedOn;

    protected override void Awake()
    {
        base.Awake();
        _startPosition = _thisRectTransform.position;
    }

    protected override void OnRoundStarted()
    {
        base.OnRoundStarted();
        PlaceInStartPosition();
    }

    private void PlaceInStartPosition() => _thisRectTransform.position = _startPosition;

    public void OnBeginDrag(PointerEventData eventData) => _canvasGroup.blocksRaycasts = false;

    public void OnDrag(PointerEventData eventData) => _thisRectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;

    public void OnEndDrag(PointerEventData eventData) => _canvasGroup.blocksRaycasts = true;

    public void OnPointerDown(PointerEventData eventData) { }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(eventData.pointerEnter != null)
           DroppedOn(eventData.pointerEnter.tag);       
        else PlaceInStartPosition();
    }  
}