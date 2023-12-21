using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class helper : MonoBehaviour
{
    private bool show = false;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.H)){
            text1.enabled = !show;
            text2.enabled = show;
            show = !show;
        }
    }
}
