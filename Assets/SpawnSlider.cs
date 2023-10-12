using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSlider : MonoBehaviour
{
    public Slider spawnSlider;
    public TextMeshProUGUI spawnPercentage;
    public void OnValueChange()
    {
        StaticVariables.spawnChancePercentage = spawnSlider.value;
        spawnPercentage.text = "Spawn %:" + spawnSlider.value;
    }
}
