using TMPro;
using UnityEngine;

public class Ken_LScore : MonoBehaviour
{
    [SerializeField] private int _RamenScorenya ;
    [SerializeField] private TextMeshProUGUI _RamenScoreTextnya;
    [SerializeField] private int _RamenTerjualnya ;
    [SerializeField] private TextMeshProUGUI _RamenTerjualTextnya;
    [SerializeField] private int _TotalScorenya ;
    [SerializeField] private TextMeshProUGUI _TotalScoreTextnya;

    public Ken_Pelanggan _pelangganScriptnya;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScorAkhirnya()
    {
        _RamenScorenya = _pelangganScriptnya._poin;
        // --------------
        //_RamenTerjualnya =

        _TotalScorenya = _RamenScorenya * _RamenTerjualnya;

        _RamenScoreTextnya.text = _RamenScorenya.ToString();
        _RamenTerjualTextnya.text = _RamenTerjualnya.ToString();
        _TotalScoreTextnya.text = _TotalScorenya.ToString();




    }
}
