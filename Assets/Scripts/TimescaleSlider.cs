using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
public class TimescaleSlider : MonoBehaviour
{
   public Slider timeScaleSlider;
    public void Start()
    {
        timeScaleSlider.value = StaticVariables.Timescale*10;
    }

    public void OnValueChange()
    {
        StaticVariables.Timescale = timeScaleSlider.value / 10;
        Time.timeScale = StaticVariables.Timescale;

    }
    }
