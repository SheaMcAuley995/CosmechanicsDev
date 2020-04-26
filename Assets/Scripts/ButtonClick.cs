using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IMoveHandler
{
    public AudioSource buttonClick;

    public void OnMove(AxisEventData eventData)
    {       
       buttonClick.Play();  
    }
}
