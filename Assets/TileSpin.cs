using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpin : MonoBehaviour
{    
    int[] Symbols = new int[] {1, 2, 5, 4, 3, 3, 3, 6, 8, 7, 9};
    
    bool mNeedAlpha = true;

    public GameObject Up;
    public GameObject Down;

	Renderer mRendererUp;
    Renderer mRendererDown;

    Mesh mMeshUp;
    Mesh mMeshDown;

    Vector2 mAtlasSize = new Vector2(256, 256);


    void Awake()
    {
        mRendererUp=Up.GetComponent<Renderer>();
        mRendererDown=Down.GetComponent<Renderer>();

        mMeshUp=Up.GetComponent<MeshFilter>().mesh;
        mMeshDown=Down.GetComponent<MeshFilter>().mesh;

        if (mNeedAlpha)
        {
            Up.GetComponent<Renderer>().material.SetFloat("_Intensity", 0.5f);
            Down.GetComponent<Renderer>().material.SetFloat("_Intensity", 0.5f);
        }
    }


    void Start()
    {

    }

    float p = 0.0f;
    int symbolindex = 0;

    void Update() {        
        p = p + 0.004f;
        if (p >= 1.0f) {
            p = 0.0f;
            symbolindex--;
            if (symbolindex < 0) {
                symbolindex = Symbols.Length - 1;
            }
        }
        int symbol1 = Symbols[symbolindex];
        int symbol2 = Symbols[(symbolindex + 1) % Symbols.Length];
        Set(mMeshUp, 1-p, false, symbol1);
        Set(mMeshDown, 1-p, true, symbol2);
    }
        
    void  Set(Mesh aMesh, float aPercent, bool aDown, int symbol)
    {
        XSpriteData sd = XSpriteData.GetSymbolData(symbol);
        
        if (sd != null)
        {
            Vector3[] v=new Vector3[4];
            Vector2[] uv=new Vector2[4];

		    float u0 = sd.x / mAtlasSize.x;
		    float u1 = (sd.x + sd.width) / mAtlasSize.x;
		    float v0 = 1 - sd.y / mAtlasSize.y;
		    float v1 = 1 - (sd.y + sd.height) / mAtlasSize.y;

            if(aDown)
            {
                v[0] = new Vector3( 0.5f, 0, 0);  // jobb also
                v[3] = new Vector3(-0.5f, aPercent, 0);   // bal felso
                v[2] = new Vector3(-0.5f, 0, 0);   // bal also
                v[1] = new Vector3( 0.5f, aPercent, 0); // jobb felso

                uv[0] = new Vector2(u1, v0 + (v1-v0) * aPercent);
                uv[3] = new Vector2(u0, v0);
                uv[2] = new Vector2(u0, v0 + (v1-v0) * aPercent);
                uv[1] = new Vector2(u1, v0);
            }
            else
            {
                v[0] = new Vector3( 0.5f, aPercent, 0);
                v[3] = new Vector3(-0.5f, 1, 0);
                v[2] = new Vector3(-0.5f, aPercent, 0);
                v[1] = new Vector3( 0.5f, 1, 0);

                uv[0] = new Vector2(u1, v1);
                uv[3] = new Vector2(u0, v0 + (v1-v0) * aPercent);
                uv[2] = new Vector2(u0, v1);
                uv[1] = new Vector2(u1, v0 + (v1-v0) * aPercent);
            }

            aMesh.vertices=v;
            aMesh.uv = uv;
        }
        else
        {
            // Debug.LogError("Missing sprite: " + aSprite);
            Debug.LogError("Missing sprite: " + symbol);
        }
    }



}
