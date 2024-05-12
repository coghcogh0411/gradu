using UnityEngine;
using System.Collections;
public class Webcam : MonoBehaviour
{


    void Start()
    {
        WebCamTexture web = new WebCamTexture(1920, 1080, 60);
        GetComponent<MeshRenderer>().material.mainTexture = web;
        web.Play();
    }
}
