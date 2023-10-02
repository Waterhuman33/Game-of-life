using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{

    public bool alive = false;
    Vector2 workerPosition;
    Vector2 up;
    public bool willLive;

    SpriteRenderer spriteRenderer;

    public void UpdateStatus( bool willLiveCheck)
    {
        spriteRenderer ??= GetComponent<SpriteRenderer>();

        willLive = willLiveCheck;

        //workerPosition = new Vector2(x, y);
        if (alive && !willLiveCheck)
        {

            spriteRenderer.color = Color.green;


        }
        else if (alive && willLiveCheck)
        {
            spriteRenderer.color = Color.yellow;
            
        }
        else if (!alive && willLiveCheck)
        {
          
            spriteRenderer.color = Color.red;
        }
        else if (!alive && !willLiveCheck)
        {

            spriteRenderer.color = Color.black;
        }


    }



}
