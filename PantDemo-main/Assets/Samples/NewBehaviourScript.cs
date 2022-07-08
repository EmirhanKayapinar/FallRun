using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NewBehaviourScript : MonoBehaviour
{

    public MeshRenderer _meshRenderer;//boyanacak obje
    public Texture2D brush; //fýrça
    public Vector2Int textureArea;//x 1024 y 1024
    Texture2D _texture;
    
    private void Start()
    {
        _texture = new Texture2D(textureArea.x, textureArea.y, TextureFormat.ARGB32, false);
        _meshRenderer.material.mainTexture = _texture;
    }

    private void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;
        if (Input.GetMouseButton(0))
        {

 
            if (Physics.Raycast(_ray, out _hit))
            {
                Debug.Log(_hit.textureCoord);
                Paint(_hit.textureCoord);
            }
        }
    }

    void Paint(Vector2 coordinate)
    {
        coordinate.x *= _texture.width;
        coordinate.y *= _texture.height;
        //fýrçanýn orta koordinatý

        Color32[] textureC32 = _texture.GetPixels32();
        Color32[] brushC32 = brush.GetPixels32();

       


        Vector2Int halfBrush = new Vector2Int(brush.width / 2, brush.height / 2);

        for (int x = 0; x < brush.width; x++)
        {
            int xPos = x - halfBrush.x + (int)coordinate.x;
            if (xPos <0 || xPos >= _texture.width)
            {
                continue;
            }
            for (int y = 0; y < brush.height; y++)
            {
                int yPos = y - halfBrush.y + (int)coordinate.y;
                if (yPos<0 || yPos >= _texture.height )
                {
                    continue;
                }


                if (brushC32[x+(y*brush.width)].a >128)
                {
                    int tPos = xPos + // u
                                (_texture.width * yPos); // V[x+ (y * brush.width)]

                    if (brushC32[x+ (y * brush.width)].r< textureC32[tPos].r)
                    {
                        textureC32[tPos] = brushC32[x + (y * brush.width)];
                    }
                }
                
            }
            
        }
        _texture.SetPixels32(textureC32);//arrayý set ettik
        _texture.Apply();
    }
    
}

