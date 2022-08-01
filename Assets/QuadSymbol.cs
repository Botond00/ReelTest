using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadSymbol : MonoBehaviour
{

    public int symbol;

    void Start () {
     
 }

 Vector2[]  GetSymbolUVs ( int symbol ) {

     Vector2[] UVs = new Vector2[4];

     if ( symbol == 1 ) { 

     // Front
     UVs[0] = new Vector2(0.0f, 0.0f);
     UVs[1] = new Vector2(0.333f, 0.0f);
     UVs[2] = new Vector2(0.0f, 0.333f);
     UVs[3] = new Vector2(0.333f, 0.333f);
     }
     if ( symbol == 2 ) { 
     // Top
     UVs[0] = new Vector2(0.334f, 0.0f);
     UVs[1] = new Vector2(0.666f, 0.0f);
     UVs[2] = new Vector2(0.334f, 0.333f);
     UVs[3] = new Vector2(0.666f, 0.333f);
     }
     if ( symbol == 3 ) { 
     // Back
     UVs[0] = new Vector2(0.666f, 0.0f);
     UVs[1] = new Vector2(1.0f, 0.0f);
     UVs[2] = new Vector2(0.666f, 0.333f);
     UVs[3] = new Vector2(1.0f, 0.333f);
     }
     if ( symbol == 4 ) { 
     // Bottom
     UVs[0] = new Vector2(0.0f, 0.334f);
     UVs[1] = new Vector2(0.333f, 0.333f);
     UVs[2] = new Vector2(0.0f, 0.666f);
     UVs[3] = new Vector2(0.333f, 0.666f);
     }
     if ( symbol == 5 ) { 
     // Left
     UVs[0] = new Vector2(0.334f, 0.334f);
     UVs[1] = new Vector2(0.666f, 0.333f);
     UVs[2] = new Vector2(0.333f, 0.666f);
     UVs[3] = new Vector2(0.666f, 0.666f);
     }
     if ( symbol == 6 ) { 
     // Right        
     UVs[0] = new Vector2(0.667f, 0.334f);
     UVs[1] = new Vector2(1.0f, 0.333f);
     UVs[2] = new Vector2(0.666f, 0.666f);
     UVs[3] = new Vector2(1.0f, 0.666f);
     }
     if ( symbol == 7 ) { 
     UVs[0] = new Vector2(0.0f, 0.666f);
     UVs[1] = new Vector2(0.333f, 0.666f);
     UVs[2] = new Vector2(0.0f, 1.0f);
     UVs[3] = new Vector2(0.333f, 1.0f);

     }
      if ( symbol == 8 ) { 
     UVs[0] = new Vector2(0.333f, 0.666f);
     UVs[1] = new Vector2(0.666f, 0.666f);
     UVs[2] = new Vector2(0.333f, 1.0f);
     UVs[3] = new Vector2(0.666f, 1.0f);

     }
      if ( symbol == 9 ) { 
     UVs[0] = new Vector2(0.667f, 0.666f);
     UVs[1] = new Vector2(1.0f, 0.666f);
     UVs[2] = new Vector2(0.666f, 1.0f);
     UVs[3] = new Vector2(1.0f, 1.0f);

     }
     
     return UVs;

 }

    public float xAngle, yAngle, zAngle;
    public int number;
    public bool ChangingSymbol = false;


    // Update is called once per frame
    void Update()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector2[] UVs = GetSymbolUVs( number );
        //Vector2[] UVs = GetSymbolUVs( Random.Range (1 , 10) );
        

        
        if (ChangingSymbol == false) {
            
            ChangingSymbol = true;
            StartCoroutine(Symbolchange());
        }
        
        mesh.uv = UVs;
         transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }

    
    IEnumerator Symbolchange ()
    {
            number = Random.Range (1 , 10);
            yield return new WaitForSeconds(1);
            ChangingSymbol = false;
    }
    
         
}
