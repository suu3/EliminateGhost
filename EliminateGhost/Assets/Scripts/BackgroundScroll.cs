using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    Material mat;
    float currentXoffset = 0;
    float speed = 0.08f;

    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;        
    }

    void Update()
    {
        currentXoffset += speed * Time.deltaTime;
        mat.mainTextureOffset = new Vector2(currentXoffset, 0);
    }
}
