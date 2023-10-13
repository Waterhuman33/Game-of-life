using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;


public class TextForGeneration : MonoBehaviour
{
   
    public TextMeshProUGUI showGenerationBox;
    public GameOfLife gameOfLife;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        showGenerationBox.text ="Generation:" + gameOfLife.firstGeneration;
        
    }
}
