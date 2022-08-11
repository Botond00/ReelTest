using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpin : MonoBehaviour
{    
    int[] Symbols = new int[] {1, 2};
    
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



    void Update() {        
        if (Input.GetKeyUp(KeyCode.Space)) {
        }        
    }
        
    void  Set(Mesh aMesh, float aPercent, string aSprite, bool aDown, int symbol)
    {
        // UISpriteData sd = mAtlas.GetSprite(aSprite);
        UISpriteData sd = UISpriteData.GetSymbolData(symbol);
        
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
                v[0] = new Vector3( 0.5f, 0, 0);
                v[3] = new Vector3(-0.5f, aPercent, 0);
                v[2] = new Vector3(-0.5f, 0, 0);
                v[1] = new Vector3( 0.5f, aPercent, 0);

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
