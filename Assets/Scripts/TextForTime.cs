using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextForTime : MonoBehaviour
{
    public TextMeshProUGUI showTimeBox;

    void Update()
    {
        showTimeBox.text = "Timescale x " + StaticVariables.Timescale;
    }
}
