using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Worker : MonoBehaviour
{

    public bool alive = false;
    Vector2 workerPosition;
    Vector2 up;
    public bool willLive;
    float whatColor = 0;
    Color whenAlive;
    Color whenAlive2;
    

    SpriteRenderer spriteRenderer;
 
    public void UpdateStatus( bool willLiveCheck)
    {
       
        spriteRenderer ??= GetComponent<SpriteRenderer>();
        whatColor += 0.002f;
        willLive = willLiveCheck;
        
        
        Color whenAlive = Random.ColorHSV(0.16f,0.16f,whatColor,whatColor,1-whatColor,1-whatColor);
        
        Color whenAlive2 = Random.ColorHSV(0.78f, 0.78f, 1-whatColor, 1-whatColor, whatColor, whatColor);
      
        
        

        //workerPosition = new Vector2(x, y);
        if (alive && !willLiveCheck)
        {
            
            spriteRenderer.color = Color.Lerp (whenAlive, whenAlive2, whatColor);


        }
        else if (alive && willLiveCheck)
        {
            spriteRenderer.color = whenAlive ;
            
        }
        else if (!alive && willLiveCheck)
        {
          
            spriteRenderer.color = Color.black;
        }
        else if (!alive && !willLiveCheck)
        {

            spriteRenderer.color = Color.black;
        }


    }



}
