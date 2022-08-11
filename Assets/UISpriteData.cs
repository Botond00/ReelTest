using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpriteData : MonoBehaviour
{
	public int x = 0;
	public int y = 0;
	public int width = 0;
	public int height = 0;

    public static UISpriteData GetSymbolData(int symbol) {
        UISpriteData data = new UISpriteData();
        data.SetSymbolData(symbol);
        return data;
    }    
    public void SetSymbolData(int symbol) {

        if (symbol == 1) {
            x = 0;
            y = 0;
            width = 85;
            height = 85;
        }
        if (symbol == 2) {
            x = 85;
            y = 0;
            width = 85;
            height = 85;
        }
        if (symbol == 3) {
            x = 171;
            y = 0;
            width = 85;
            height = 85;
        }
        if (symbol == 4) {
            x = 0;
            y = 85;
            width = 85;
            height = 85;
        }
        if (symbol == 5) {
            x = 85;
            y = 85;
            width = 85;
            height = 85;
        }
        if (symbol == 6) {
            x = 171;
            y = 85;
            width = 85;
            height = 85;
        }
        if (symbol == 7) {
            x = 0;
            y = 171;
            width = 85;
            height = 85;
        }
        if (symbol == 8) {
            x = 85;
            y = 171;
            width = 85;
            height = 85;
        }
        if (symbol == 9) {
            x = 171;
            y = 171;
            width = 85;
            height = 85;
        }
    }



}
