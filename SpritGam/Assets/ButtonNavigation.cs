using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonNavigation : MonoBehaviour {
    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(eventData);
    }
}
