using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextColor : MonoBehaviour, ISelectHandler, IDeselectHandler
{

    // Use this for initialization
    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        gameObject.GetComponentInChildren<Text>().color = new Color(0, 255, 255, 255);
    }

    // Update is called once per frame
    void IDeselectHandler.OnDeselect(BaseEventData eventData)
    {
        gameObject.GetComponentInChildren<Text>().color = new Color(0, 0, 0, 255);
    }

    private void OnMouseUpAsButton()
    {
        gameObject.GetComponentInChildren<Text>().color = new Color(0, 255, 255, 255);
    }
}
