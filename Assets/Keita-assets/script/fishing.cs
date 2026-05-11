using System.Collections;
using UnityEngine;

using UnityEngine.UIElements;

public class fishing : MonoBehaviour
{
   // private int ŠÔ§ŒÀ = 8;
  //  private int number = 50;
    public Slider slider;

     void Start()
    {
        //ŠÔ§ŒÀ
        for (int i = 8; i < 0; i--)
        {
            //Šm—¦


            
            //–ˆ•bŠm—¦‚Ö‚é
            for(int j = 50; j < 0; j--)
            {
                if(Input.GetMouseButton(0))
                {
                    //number++;
                }

                if(j > 40 && j < 60)
                {
                    Debug.Log("‹›‚Æ‚ê‚½‚æ");
                }
                else
                {
                    Debug.Log("c”O‚Å‚µ‚½‚‚");
                }
            }
        }

    }       
 }
