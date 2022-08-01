using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingSymbol : MonoBehaviour
{

    public float xScroll = 0.5f;
    public float yScroll = 0.5f;

    void Update()
    {
        float OffsetX = Time.time * xScroll;
        float OffsetY = Time.time * yScroll;
        GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (OffsetX , OffsetY);

    }
}
