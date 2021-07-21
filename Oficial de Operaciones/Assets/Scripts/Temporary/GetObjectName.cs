using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetObjectName : MonoBehaviour
{
    private TextMeshProUGUI Label_TXT;

    void Start()
    {
        Label_TXT = GetComponent<TextMeshProUGUI>();
        Label_TXT.text = transform.name;
    }

}
