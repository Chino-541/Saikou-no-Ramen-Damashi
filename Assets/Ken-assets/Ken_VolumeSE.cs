using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ken_VolumeSE : MonoBehaviour
{
    public static Ken_VolumeSE instance;

    [Range(0, 100)][SerializeField] private int _Volume = 70;
    [SerializeField] private Slider _VolumeSlider;
    [SerializeField] private TextMeshProUGUI _VolumeText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);

        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _VolumeSlider.value = _Volume;

        _VolumeSlider.onValueChanged.AddListener(delegate
        {
            SetVolume((int)_VolumeSlider.value);
        });
    }

    // Update is called once per frame
    void Update()
    {
        _VolumeSlider.value = _Volume;
        _VolumeText.text = _Volume.ToString();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateSE();

    }
    public void UpdateSE()
    {
        GameObject[] bgms = GameObject.FindGameObjectsWithTag("SE");

        foreach (GameObject bgm in bgms)
        {
            AudioSource source = bgm.GetComponent<AudioSource>();
            source.volume = _Volume / 100f;

        }
    }
    public void SetVolume(int NewVolume)
    {
        _Volume = Mathf.Clamp(NewVolume, 0, 100);
        UpdateSE();
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
