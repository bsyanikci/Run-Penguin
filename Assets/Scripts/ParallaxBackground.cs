using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour 
    //Arka plan� Belirli s�rede hareket ettirme
{
    public float parallaxSpeed = 0.5f; 
    private float startPosX;
    private float length;

    private void Start() //arka planlar�n baslang�ctaki x de�erlerini al�r
    {
        startPosX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update() //ana kameran�n x de�erini temel alarak arka plan�n h�z�na g�re arka planlar� hareket ettirir.
    {
        float temp = (Camera.main.transform.position.x * (1 - parallaxSpeed));
        float dist = (Camera.main.transform.position.x * parallaxSpeed);

        transform.position = new Vector3(startPosX + dist, transform.position.y, transform.position.z);

        if (temp > startPosX + length)
            startPosX += length;
        else if (temp < startPosX - length)
            startPosX -= length;
    }
}

