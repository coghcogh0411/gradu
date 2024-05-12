using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Light_Controller : MonoBehaviour
{
    public GameObject lightControlObject;

    public Slider intensitySlider;
    public Slider distanceSlider;

    // Start is called before the first frame update
    void Start()
    {
        intensitySlider.onValueChanged.AddListener(ChangeIntensity);
        distanceSlider.onValueChanged.AddListener(ChangeDistance);
    }

    public void SetLastClickedObject(GameObject obj)
    {
        lightControlObject = obj;

        if(lightControlObject != null)
        {
            Light pointLight = lightControlObject.GetComponentInChildren<Light>();
            if(pointLight != null)
            {
                intensitySlider.value = pointLight.intensity;
                distanceSlider.value = lightControlObject.transform.position.z;
            }
        }
    }
    void ChangeIntensity(float newLightPower)
    {
        if (lightControlObject != null)
        {
            Light pointLight = lightControlObject.GetComponentInChildren<Light>();
            if (pointLight != null)
            {
                pointLight.intensity = newLightPower;
                pointLight.range = newLightPower;

                intensitySlider.value = newLightPower;
                
            }
        }
    }

    void ChangeDistance(float newDistance)
    {
        if (lightControlObject != null)
        {
            Vector3 newPosition = lightControlObject.transform.position;
            newPosition.z = newDistance;
            lightControlObject.transform.position = newPosition;

            distanceSlider.value = newDistance;
        }
    }
}
