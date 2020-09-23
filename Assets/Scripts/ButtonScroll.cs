using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScroll : MonoBehaviour, ISelectHandler
{
    RectTransform contentPanel;   
    ScrollRect scrollRect;

    private void Start()
    {
        contentPanel = transform.parent.GetComponent<RectTransform>();
        scrollRect = contentPanel.parent.parent.GetComponent<ScrollRect>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        RectTransform target = EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform>();

        Canvas.ForceUpdateCanvases();

        contentPanel.anchoredPosition = (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position) - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);     
    }
}
