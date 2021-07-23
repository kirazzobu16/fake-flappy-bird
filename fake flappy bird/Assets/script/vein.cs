using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vein : MonoBehaviour
{
    public GameObject damar;
    private int arkaplanSayisi;
    private Vector2 kameraUnityEbatlar;
    private Vector2 damarUnityEbatlar;
    private Transform[] damarObjeleri;
  
    private int bastakiArkaplanObjesi = 0;

    void Start()
    {
        Camera kamera = GetComponent<Camera>();

        damarUnityEbatlar = damar.GetComponent<SpriteRenderer>().sprite.rect.size / 100;
       

        
        arkaplanSayisi = Mathf.CeilToInt((kamera.orthographicSize * 2 * kamera.aspect) / damarUnityEbatlar.x) + 1;

        kameraUnityEbatlar = new Vector2(kamera.orthographicSize, kamera.orthographicSize);

        damarObjeleri = new Transform[arkaplanSayisi];
       

        for (int i = 0; i < arkaplanSayisi; i++)
        {
            float xKoordinati = transform.position.x - kameraUnityEbatlar.x + i * damarUnityEbatlar.x;
            damarObjeleri[i] = Instantiate(damar, new Vector3(xKoordinati, kameraUnityEbatlar.y, 0), Quaternion.identity).transform;
        }
    }

    void Update()
    {
        if (transform.position.x - kameraUnityEbatlar.x >= damarObjeleri[bastakiArkaplanObjesi].position.x + damarUnityEbatlar.x)
        {
            damarObjeleri[bastakiArkaplanObjesi].Translate(arkaplanSayisi * damarUnityEbatlar.x, 0, 0);
           

            bastakiArkaplanObjesi++;

            if (bastakiArkaplanObjesi == damarObjeleri.Length)
                bastakiArkaplanObjesi = 0;
        }
    }
}


