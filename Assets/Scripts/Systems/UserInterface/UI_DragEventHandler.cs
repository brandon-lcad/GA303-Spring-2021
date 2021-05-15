using UnityEngine;
using UnityEngine.EventSystems;

public class UI_DragEventHandler : MonoBehaviour
{
    public class DragEventHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public Canvas canvas;
        private CanvasGroup canvasGroup;
        private RectTransform rect;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            rect = GetComponent<RectTransform>();
        }


        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Dragging: ", eventData.pointerDrag);
            rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Begin dragging...");
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("End drag");
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }
}
