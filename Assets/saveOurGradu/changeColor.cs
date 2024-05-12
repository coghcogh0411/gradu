using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeColor : MonoBehaviour
{
    public Image circlePalette;
    public Image picker;
    public Color selectedColor;

    private Vector2 sizeOfPalette;
    private CircleCollider2D paletteCollider;

    public GameObject lastClickedObject;

    // Start is called before the first frame update
    void Start()
    {
        paletteCollider = circlePalette.GetComponent<CircleCollider2D>();

        sizeOfPalette = new Vector2(
            circlePalette.GetComponent<RectTransform>().rect.width,
            circlePalette.GetComponent<RectTransform>().rect.height
            );
    }

    public void SetLastClickedObject(GameObject obj)
    {
        lastClickedObject = obj;
    }
    public void mousePointerDown()
    {
        selecteColor();
    }

    public void OnMouseDrag()
    {
        selecteColor();
    }
    private Color getColor()
    {
        Vector2 circlePalettePosition = circlePalette.transform.position;
        Vector2 pickerPosition = picker.transform.position;

        Vector2 position = pickerPosition - circlePalettePosition + sizeOfPalette * 0.5f;
        Vector2 normalized = new Vector2(
            (position.x / (circlePalette.GetComponent<RectTransform>().rect.width)),
            (position.y / (circlePalette.GetComponent<RectTransform>().rect.height)));

        Texture2D texture = circlePalette.mainTexture as Texture2D;
        Color circularSelectedColor = texture.GetPixelBilinear(normalized.x, normalized.y);

        return circularSelectedColor;
    }

    private void selecteColor()
    {
        Vector3 offset = Input.mousePosition - transform.position;
        Vector3 diff = Vector3.ClampMagnitude(offset, paletteCollider.radius);

        picker.transform.position = transform.position + diff;

        selectedColor = getColor();

        if(lastClickedObject != null)
        {
            Light pointLight = lastClickedObject.GetComponentInChildren<Light>();
            if(pointLight != null)
            {
                pointLight.color = selectedColor;
            }
        }
    }
}
