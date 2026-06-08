using UnityEngine;
using UnityEngine.UI;

public class Create : MonoBehaviour
{
    [SerializeField] SlotBef Bef;
    [SerializeField] SlotVeg Veg;
    [SerializeField] SlotFis Fis;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        int befUsed = Bef.Minus();
        int vegUsed = Veg.Minus();
        int fisUsed = Fis.Minus();

        Debug.Log("¡‰ñÁ”ï‚µ‚½‚¨“÷: " + befUsed);
        Debug.Log("¡‰ñÁ”ï‚µ‚½–ìØ: " + vegUsed);
        Debug.Log("¡‰ñÁ”ï‚µ‚½‹›: " + fisUsed);

        int total = befUsed + vegUsed + fisUsed;


        if (befUsed == vegUsed && vegUsed == fisUsed)
        {
            Debug.Log("’ö‚æ‚¢ƒoƒ‰ƒ“ƒX");
        }
        else if (total >= 15)
        {
            Debug.Log("‚ß‚Á‚¿‚áW‚ß‚½‚Ë");
        }
        else if(total >= 3)
        {
            Debug.Log("•À‚Ý");
        }
        else if(total <= 0)
        {
            Debug.Log("–³‚µ");
        }
    }
}
