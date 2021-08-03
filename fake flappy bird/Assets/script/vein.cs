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

        damarUnityEbatlar = damar.GetComponent<SpriteRenderer>().sprite.rect.size / 128;
       

        
        arkaplanSayisi = Mathf.CeilToInt((kamera.orthographicSize * 2 * kamera.aspect) / damarUnityEbatlar.x)+1;
        // Kameraya kaç tane arkaplan objesinin sýðabildiðini depoluyor. Oyun baþladýðýnda bu deðiþkenin deðeri kadar yanyana arkaplan objesi oluþturuyoruz. Aslýnda deðiþkenin gerçek deðeri kameraya sýðan arkaplan objesi sayýsýnýn 1 fazlasý.

        kameraUnityEbatlar = new Vector2(kamera.orthographicSize, kamera.orthographicSize);
        //Deðiþkenin X deðerinde kameranýn tam ortasý ile tam solu arasýnýn kaç Uzay Birimi‘ne denk geldiði kaydedilirken Y deðerinde kameranýn tam ortasý ile tam tepesi arasýnýn kaç Uzay Birimi‘ne denk geldiði kaydediliyor

        damarObjeleri = new Transform[arkaplanSayisi];
       

        for (int i = 0; i < arkaplanSayisi; i++)
        {
            
            float xKoordinati = transform.position.x - kameraUnityEbatlar.x +1 + i * damarUnityEbatlar.x;
            //Ýki arkaplaný yanyana eklenmesi saðlandý.
            damarObjeleri[i] = Instantiate(damar, new Vector3(xKoordinati, 0, 0), Quaternion.identity).transform;
            //Kameranýn transform.position deðeri, kameranýn tam merkezinin uzaydaki konumunu depolar. Bu deðerin X bileþeninden kameraUnityEbatlar.x‘i çýkarýrsak kameranýn en sol noktasýnýn koordinatýný, bu deðerin Y bileþenine kameraUnityEbatlar.y‘yi eklersek kameranýn en üst noktasýnýn koordinatýný buluruz (Y koordinatý aþaðýdan yukarýya doðru artar). Kameramýzýn Y deðeri zaten 0 olduðu için, kameraUnityEbatlar.y diyince direkt kameranýn en tepe noktasýnýn koordinatýný elde ediyoruz.
                if (i == arkaplanSayisi- 1)
                {
                    damarObjeleri[i].transform.localScale = new Vector3(-1, 1, 1);
                  //damarObjeleri[i].transform.position = new Vector3(xKoordinati+damarUnityEbatlar.x, kameraUnityEbatlar.y, 0);
              
                }

        }
    }


    void Update()
    {
        if (transform.position.x - kameraUnityEbatlar.x >= damarObjeleri[bastakiArkaplanObjesi].position.x+damarUnityEbatlar.x )
        {
         
            damarObjeleri[bastakiArkaplanObjesi].Translate(arkaplanSayisi* damarUnityEbatlar.x, 0, 0);
            bastakiArkaplanObjesi++;

            if (bastakiArkaplanObjesi == damarObjeleri.Length) 
              bastakiArkaplanObjesi = 0; 
        }
    }
}


