using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brillo : MonoBehaviour
{
   public Slider slider;
   public float sliderValue;
   public Image PanelBrillo;

   void Start()
   {
        slider.value= PlayerPrefs.GetFloat("brillo", 0.5f);
        PanelBrillo.color = new Color(PanelBrillo.color.r, PanelBrillo.color.g, PanelBrillo.color.b, slider.value);
   }

   void Update()
   {

   }

   public void ChangeSlider (float valor)
   {
    sliderValue= valor;
    PlayerPrefs.SetFloat("brillo",sliderValue);
    PanelBrillo.color = new Color(PanelBrillo.color.r, PanelBrillo.color.g, PanelBrillo.color.b, slider.value);
   }
}
