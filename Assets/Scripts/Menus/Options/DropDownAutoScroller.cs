using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DropDownAutoScroller : MonoBehaviour
{
    Dropdown dropdown;
    PlayerControls inputActions;
    
    public RectTransform contentPanel;
    public ScrollRect scrollRect;

    void SnapTo(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();

        contentPanel.anchoredPosition = (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position) - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);
    }

    private void Update()
    {
        SnapTo(EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform>());
        
        
        /*
         
        //if(EventSystem.current.currentSelectedGameObject == dropdown.gameObject)
        //{
        //    if(inputActions.MainMenu.Movement.enabled)
        //    {
        //        Transform dropdownListTrans = dropdown.gameObject.transform.Find("Dropdown List");
        //        if(dropdownListTrans == null)
        //        {
        //            dropdown.Show();
        //        }
        //    }
        //}
        //else
        //{
        //    PointerEventData eventDataCurrPos = new PointerEventData(EventSystem.current);
        //    eventDataCurrPos.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //    List<RaycastResult> results = new List<RaycastResult>();
        //    EventSystem.current.RaycastAll(eventDataCurrPos, results);
        //    if (results.Count > 0)
        //    {
        //        if (results[0].gameObject.transform.IsChildOf(dropdown.gameObject.transform))
        //        {
        //            return;
        //        }
        //    }

        //    if(EventSystem.current.currentSelectedGameObject.transform.IsChildOf(dropdown.gameObject.transform))
        //    {
        //        if (EventSystem.current.currentSelectedGameObject.name.StartsWith("Item"))
        //        {
        //            Transform parent = EventSystem.current.currentSelectedGameObject.transform.parent;
        //            int activeChild = 0;
        //            int totalchildren = parent.childCount;

        //            for (int i = 0; i < totalchildren; i++)
        //            {
        //                if(parent.GetChild(i).gameObject.activeInHierarchy)
        //                {
        //                    activeChild++;
        //                }
        //            }

        //            int activeIndx = 0;

        //            for(int i = 0; i < totalchildren; i++)
        //            {
        //                if(parent.GetChild(i).gameObject == EventSystem.current.currentSelectedGameObject)
        //                {
        //                    break;
        //                }
        //                else if(parent.GetChild(i).gameObject.activeInHierarchy)
        //                {
        //                    activeIndx++;
        //                }
        //            }

        //            if (activeChild > 1)
        //            { 
        //                if(scrollBar != null && scrollBar.gameObject.activeInHierarchy)
        //                {

        //                    if (scrollBar.direction == Scrollbar.Direction.TopToBottom)
        //                    {
        //                        scrollBar.value = (float)activeIndx / (float)(activeChild - 1);
        //                    }
        //                    else
        //                    {
        //                        scrollBar.value = 1.0f - (float)activeIndx / (float)(activeChild - 1);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}


        */
    }
}
