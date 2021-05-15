using UnityEngine;
using UnityEngine.EventSystems;

public class UI_WindowFocusDrag : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform dragRectTransform;
    [SerializeField] Canvas canvas;

    private void Awake()
    {
        if (dragRectTransform == null)
        {
            dragRectTransform = transform.parent.GetComponent<RectTransform>();
        }

        if (canvas == null)
        {
            Transform findCanvasTransform = transform.parent;
            while (findCanvasTransform != null)
            {
                canvas = findCanvasTransform.GetComponent<Canvas>();
                if (canvas != null)
                {
                    break;
                }
                findCanvasTransform = findCanvasTransform.parent;
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragRectTransform.SetAsLastSibling();
    }
}
