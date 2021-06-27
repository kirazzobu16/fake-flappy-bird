using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public GameObject karakter;
    private Vector2 kameraUnityEbatlar;

    // Start is called before the first frame update
    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        Camera kamera = GetComponent<Camera>();
   
        transform.position = new Vector3(karakter.transform.position.x + kamera.orthographicSize*kamera.aspect-0.3f, 0, -10);

    }
}
