using UnityEngine;

public class Ken_SoundNoDestroy : MonoBehaviour
{
    void Awake()
    {
        // Perintah agar GameObject ini tidak hancur saat pindah scene
        DontDestroyOnLoad(gameObject);
    }
}