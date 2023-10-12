using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeScale : MonoBehaviour
{
    public TextMeshProUGUI showTimeBox;
    public Slider slider;
    public float sliderValue;
    float shownsliderValue;
    
 
    // Update is called once per frame
    public void Start()
    {
       
        if(slider.value<0)
        {
            shownsliderValue = 0;   
        }
        else
        {
        sliderValue =1-(slider.value) / 10;
        shownsliderValue=1+(slider.value)/10;
        
          } 
        showTimeBox.text = "Timescale=" +shownsliderValue;
    }
}
