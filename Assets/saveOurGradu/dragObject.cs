using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragObject : MonoBehaviour
{
    private Vector3 m_Offset;
    private float m_ZCoord;

    // Start is called before the first frame update
    void Start()
    {
        m_ZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

    }

    private void OnMouseDown()
    {
        m_Offset = gameObject.transform.position - GetMouseWorldPosition();
    }
    private void OnMouseDrag()
    {
        Vector3 newPos = GetMouseWorldPosition() + m_Offset;
        newPos.z = transform.position.z;
        transform.position = newPos;
    }
    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoiont = Input.mousePosition;
        mousePoiont.z = m_ZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoiont);
    }
}
