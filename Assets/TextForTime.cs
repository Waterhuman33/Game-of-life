using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TextForTime : MonoBehaviour
{
    public TextMeshProUGUI showTimeBox;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        showTimeBox.text = "Timescale="+Time.timeScale;
    }
}
