using UnityEngine;
using UnityEngine.UI;

public class Ken_Pelanggantiga : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    //[SerializeField] private GameObject _Panel;
    [SerializeField] private Image[] _Image;
    //[SerializeField] private Color _BaseColor;
    //[SerializeField] private Color _FullColor;
    //[SerializeField] private int _SliderMinVal = 0, _SliderMaxVal = 5;
    //[SerializeField] private int _SliderValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PelangantigaInterek();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PelangantigaInterek()
    {
        while (true) 
        {

            for (int i = 5; i < 0; i--)
            {

                _Image[i].gameObject.SetActive(false);
                

            }
            Debug.Log("f");
        }
    }
    
}
