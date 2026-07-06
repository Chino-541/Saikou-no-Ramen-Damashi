using UnityEngine;

public class Ken_BgmSystem : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private AudioSource _BgmPelanggan;
    [SerializeField] private AudioSource _BgmScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _BgmPelanggan.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gantiBGM()
    {
        _BgmPelanggan.enabled=false;
        _BgmScore.enabled=true;
    }
    
}
