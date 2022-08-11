using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    enum ReelState {
        STOPPED,
        SPINNING
    }
    
    public int StartPos;

    public GameObject[] Tiles;
    int[] Symbols = new int[] {1, 2, 3, 4, 5, 9, 8, 7, 6, 3, 3, 3, 5, 7, 7, 7, 4};
    
    ReelState mReelState;
    public int mReelPos;

    void Start()
    {
        mReelState = ReelState.STOPPED;
        mReelPos = StartPos;
        ReelStartPos = this.transform.position;
    }



    void Update() {
        
        if (Input.GetKeyUp(KeyCode.Space)) {
            mReelState = (mReelState == ReelState.STOPPED) ? ReelState.SPINNING : ReelState.STOPPED;
        }
        
        switch(mReelState){
            case ReelState.STOPPED:
                ShowStoppedReels();
                break;
            case ReelState.SPINNING:
                mSpinningReelsPhase = 1;
                break;
        }

        DoSpinningReels();
    }

    void ShowStoppedReels() {
        int reelpos = mReelPos;
        foreach (GameObject tile in Tiles) {
            int symbol = Symbols[reelpos];
            SetTileSymbol(tile, symbol);
            reelpos++;
            if (reelpos >= Symbols.Length) {
                reelpos = 0;
            }
        }
    }
    
    float mSpinTime;
    
    // void ShowSpinningReels() {
    //     float passedtime = Time.time - mSpinTime;
    //     if (passedtime < 1.0f) {
    //         return;
    //     }
    //     mSpinTime = Time.time;
    //     ShowStoppedReels();
    //     mReelPos--;
    //     if (mReelPos <= 0) {
    //         mReelPos = Symbols.Length-1;
    //     }
    // }

    public float mOneSpinTime = 1.0f;
    float mOneSpinDeltaY = -1.5f;
    float mSpinTime2T0;
    float mSpinTime2;
    Vector3 ReelStartPos;
    int mSpinningReelsPhase = 0;
    
    void DoSpinningReels() {            
        if (mSpinningReelsPhase == 1) {
            mSpinTime2T0 = Time.time;
            mSpinTime2 = Time.time;
            mSpinningReelsPhase++;
        }
        if (mSpinningReelsPhase == 2) {
            // timing
            float passedtime2 = Time.time - mSpinTime2;
            if (passedtime2 < 0.005f) {
                return;
            }
            mSpinTime2 = Time.time;
            // moving
            float movetime = Time.time - mSpinTime2T0;
            float movePos = movetime / mOneSpinTime;
            if (movePos > 1.0f) {
                movePos = 1.0f;
            }
            Vector3 pos = transform.localPosition;
            pos.y = ReelStartPos.y + mOneSpinDeltaY * movePos;
            transform.localPosition = pos;
            if (movePos >= 1.0f) {
                this.transform.position = ReelStartPos;
                mReelPos--;
                if (mReelPos == -1) {
                    mReelPos = Symbols.Length-1;
                }
                ShowStoppedReels();
                mSpinningReelsPhase = 1;
            }
        }
    }    

    void SetTileSymbol(GameObject tile, int symbol) {
        
        Mesh mesh = tile.GetComponent<MeshFilter>().mesh;
        Vector2[] UVs = GetSymbolUVs(symbol);
        mesh.uv = UVs;
    }

    Vector2[] GetSymbolUVs(int symbol) {

        Vector2[] UVs = new Vector2[4];

        if (symbol == 1) { 
            UVs[0] = new Vector2(0.0f, 0.0f);
            UVs[1] = new Vector2(0.333f, 0.0f);
            UVs[2] = new Vector2(0.0f, 0.333f);
            UVs[3] = new Vector2(0.333f, 0.333f);
        }
        else if (symbol == 2) { 
            UVs[0] = new Vector2(0.334f, 0.0f);
            UVs[1] = new Vector2(0.666f, 0.0f);
            UVs[2] = new Vector2(0.334f, 0.333f);
            UVs[3] = new Vector2(0.666f, 0.333f);
        }
        else if (symbol == 3) { 
            UVs[0] = new Vector2(0.666f, 0.0f);
            UVs[1] = new Vector2(1.0f, 0.0f);
            UVs[2] = new Vector2(0.666f, 0.333f);
            UVs[3] = new Vector2(1.0f, 0.333f);
        }
        else if (symbol == 4) { 
            UVs[0] = new Vector2(0.0f, 0.334f);
            UVs[1] = new Vector2(0.333f, 0.333f);
            UVs[2] = new Vector2(0.0f, 0.666f);
            UVs[3] = new Vector2(0.333f, 0.666f);
        }
        else if (symbol == 5) { 
            UVs[0] = new Vector2(0.334f, 0.334f);
            UVs[1] = new Vector2(0.666f, 0.333f);
            UVs[2] = new Vector2(0.333f, 0.666f);
            UVs[3] = new Vector2(0.666f, 0.666f);
        }
        else if (symbol == 6) { 
            UVs[0] = new Vector2(0.667f, 0.334f);
            UVs[1] = new Vector2(1.0f, 0.333f);
            UVs[2] = new Vector2(0.666f, 0.666f);
            UVs[3] = new Vector2(1.0f, 0.666f);
        }
        else if (symbol == 7) { 
            UVs[0] = new Vector2(0.0f, 0.666f);
            UVs[1] = new Vector2(0.333f, 0.666f);
            UVs[2] = new Vector2(0.0f, 1.0f);
            UVs[3] = new Vector2(0.333f, 1.0f);
        }
        else if (symbol == 8) { 
            UVs[0] = new Vector2(0.333f, 0.666f);
            UVs[1] = new Vector2(0.666f, 0.666f);
            UVs[2] = new Vector2(0.333f, 1.0f);
            UVs[3] = new Vector2(0.666f, 1.0f);
        }
        else if (symbol == 9) { 
            UVs[0] = new Vector2(0.667f, 0.666f);
            UVs[1] = new Vector2(1.0f, 0.666f);
            UVs[2] = new Vector2(0.666f, 1.0f);
            UVs[3] = new Vector2(1.0f, 1.0f);
        }
        
        return UVs;
    }  

}
