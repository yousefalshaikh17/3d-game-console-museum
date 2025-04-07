using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDataHandler : MonoBehaviour
{
    private static Text textObject;

    void Awake()
    {
        textObject = gameObject.GetComponent<Text>();
    }

    public static void showObjectData(string objName)
    {
        textObject.text = objName;
        textObject.enabled = true;
    }

    public static void hideObjectData(string objName)
    {
        if (textObject.text == objName)
            textObject.enabled = false;
    }
}
