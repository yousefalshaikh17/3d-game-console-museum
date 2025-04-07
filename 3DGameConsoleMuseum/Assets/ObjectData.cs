using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ObjectData : MonoBehaviour
{
    public string objectName;
    public Text text;

    void Awake()
    {
        EventTrigger.Entry enterEntry = new EventTrigger.Entry();
        enterEntry.eventID = EventTriggerType.PointerEnter;
        enterEntry.callback.AddListener((data) => {
            Debug.Log("Entered");
             showData();
        });
        GetComponent<EventTrigger>().triggers.Add(enterEntry);

        EventTrigger.Entry exitEntry = new EventTrigger.Entry();
        exitEntry.eventID = EventTriggerType.PointerExit;
        exitEntry.callback.AddListener((data) => {
             hideData();
        });
        GetComponent<EventTrigger>().triggers.Add(exitEntry);
    }

    private void showData()
    {
        ObjectDataHandler.showObjectData(objectName);
    }

    private void hideData()
    {
        ObjectDataHandler.hideObjectData(objectName);
    }

}
