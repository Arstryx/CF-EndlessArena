using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image healthbarImage;

    RectTransform healthbarRectTransform;
    float initialWidth;
     void Start()
    {
        healthbarImage.type = Image.Type.Filled;
        healthbarImage.fillMethod = Image.FillMethod.Horizontal;
        healthbarImage.fillOrigin = 0;
        healthbarRectTransform = healthbarImage.GetComponent<RectTransform>();
        initialWidth = healthbarRectTransform.rect.width;
    }


    public void UpdateHealthbar(float normalizedHealth)
    {

        if (normalizedHealth <= 0.3)
        {
            healthbarImage.color = Color.red;
        }

        else if (normalizedHealth <= 0.7)
        {
            healthbarImage.color = Color.yellow;
        }

        
        else
        {
            healthbarImage.color = Color.green;
        }

        float newWidth = initialWidth * normalizedHealth;
        healthbarRectTransform.sizeDelta = new Vector2(newWidth, healthbarRectTransform.sizeDelta.y);
    }
}
