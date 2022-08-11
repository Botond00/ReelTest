using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelTileSpinner : MonoBehaviour
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
        CreateTiles();
    }

    void Update() {
        
        if (Input.GetKeyUp(KeyCode.Space)) {
            mReelState = (mReelState == ReelState.STOPPED) ? ReelState.SPINNING : ReelState.STOPPED;
        }
    }

    void CreateTiles() {
        GameObject prefab = Resources.Load("SpinTile") as GameObject;
        foreach (GameObject tile in Tiles) {
            Instantiate(prefab, tile.transform);
        }
    }
    
}
