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
        // Kameraya ka� tane arkaplan objesinin s��abildi�ini depoluyor. Oyun ba�lad���nda bu de�i�kenin de�eri kadar yanyana arkaplan objesi olu�turuyoruz. Asl�nda de�i�kenin ger�ek de�eri kameraya s��an arkaplan objesi say�s�n�n 1 fazlas�.

        kameraUnityEbatlar = new Vector2(kamera.orthographicSize, kamera.orthographicSize);
        //De�i�kenin X de�erinde kameran�n tam ortas� ile tam solu aras�n�n ka� Uzay Birimi�ne denk geldi�i kaydedilirken Y de�erinde kameran�n tam ortas� ile tam tepesi aras�n�n ka� Uzay Birimi�ne denk geldi�i kaydediliyor

        damarObjeleri = new Transform[arkaplanSayisi];
       

        for (int i = 0; i < arkaplanSayisi; i++)
        {
            
            float xKoordinati = transform.position.x - kameraUnityEbatlar.x +1 + i * damarUnityEbatlar.x;
            //�ki arkaplan� yanyana eklenmesi sa�land�.
            damarObjeleri[i] = Instantiate(damar, new Vector3(xKoordinati, 0, 0), Quaternion.identity).transform;
            //Kameran�n transform.position de�eri, kameran�n tam merkezinin uzaydaki konumunu depolar. Bu de�erin X bile�eninden kameraUnityEbatlar.x�i ��kar�rsak kameran�n en sol noktas�n�n koordinat�n�, bu de�erin Y bile�enine kameraUnityEbatlar.y�yi eklersek kameran�n en �st noktas�n�n koordinat�n� buluruz (Y koordinat� a�a��dan yukar�ya do�ru artar). Kameram�z�n Y de�eri zaten 0 oldu�u i�in, kameraUnityEbatlar.y diyince direkt kameran�n en tepe noktas�n�n koordinat�n� elde ediyoruz.
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


