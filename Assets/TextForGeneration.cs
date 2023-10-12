using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TextForGeneration : MonoBehaviour
{
    public TextMeshProUGUI showTimeBox;
    public GameOfLife gameOfLife;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        showTimeBox.text ="Generation:" + gameOfLife.firstGeneration;
    }
}
