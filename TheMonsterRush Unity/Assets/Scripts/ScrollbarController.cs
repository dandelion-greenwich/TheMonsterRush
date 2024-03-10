using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarController : MonoBehaviour
{
    public Scrollbar scrollbar;
    public float scrollSpeed = 0.1f;

    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        scrollbar.value += scrollInput * scrollSpeed;
    }
}
