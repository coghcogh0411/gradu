using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Material_Controller : MonoBehaviour
{
    private string CopiedMatPath = "Materials/copied";
    public GameObject But;
    public void ChangeMat0()
    {
        gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/example0");
    }
    public void ChangeMat1()
    { 
        gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/example1");
    }
    public void ApplyCopiedMat()
    {
        Material copiedMat = Resources.Load<Material>(CopiedMatPath);
        gameObject.GetComponent<MeshRenderer>().material = copiedMat;      
    }

}