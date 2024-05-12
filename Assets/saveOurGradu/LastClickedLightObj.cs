using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastClickedLightObj : MonoBehaviour
{
    private Light_Controller lightController;
    private changeColor changecolor;
    // Start is called before the first frame update
    void Start()
    {
        lightController = GameObject.FindObjectOfType<Light_Controller>();
        changecolor = GameObject.FindObjectOfType<changeColor>();
    }

    private void OnMouseDown()
    {
        lightController.SetLastClickedObject(gameObject);
        changecolor.SetLastClickedObject(gameObject);
    }
}