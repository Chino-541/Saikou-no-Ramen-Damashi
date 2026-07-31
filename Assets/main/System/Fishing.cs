using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    [Header("スライダー関連")]
    [SerializeField] private Slider _slider;
    [SerializeField] private int _BaseValue = 0;
    [SerializeField] private int _MaxValue = 1000;
    [SerializeField] private int _StartValue = 500;

    [Header("値関連")]
    [SerializeField] private int _MinValue = 5;
    [SerializeField] private int _PlusValue = 25;
    [SerializeField] private float _FishSpeed = 0.3f;
    [SerializeField] private int _MaxFishTime = 10;

    [Header("成否の範囲")]
    [SerializeField] private int _GetFishBaseValue = 400;
    [SerializeField] private int _GetFishMaxValue = 600;
    private int _FinalValue;

    [Header("結果")]
    [SerializeField] private ItemData item;
    [SerializeField] private int Getfish;
    [SerializeField] private Cook cook;

    [Header("演出")]
    [SerializeField] private GameObject _GetFishSprite;
    [SerializeField] private GameObject _MissFishSprite;
    [SerializeField] private GameObject _PanelFishing;

    public bool _Fishing = false;   // PanelView が参照する重要フラグ
    private int _FishTime;

    // スライダー設定
    private void Start()
    {
        SetupSlider();
    }

    void SetupSlider()
    {
        _slider.minValue = _BaseValue;
        _slider.maxValue = _MaxValue;
        _slider.value = _StartValue;
    }
    // 釣りスタート処理
    public void StartFishing()
    {
        _PanelFishing.SetActive(true);
        StartCoroutine(FishTimeSystem());
    }

    // 釣り中の処理
    IEnumerator FishTimeSystem()
    {
        _Fishing = true;
        _FishTime = 0;

        while (_Fishing)
        {
            _FishTime++;

            if (_FishTime >= _MaxFishTime)
                _Fishing = false;

            _slider.value -= _MinValue;

            yield return new WaitForSeconds(_FishSpeed);
        }

        _FinalValue = (int)_slider.value;
        yield return StartCoroutine(FishFinal());
    }

    public void FishPlusSystem(InputAction.CallbackContext context)
    {
        if (context.performed)
            _slider.value += _PlusValue;
    }
    // 釣り終了時の値によって処理が変わる
    IEnumerator FishFinal()
    {
        bool success = (_FinalValue >= _GetFishBaseValue &&
                        _FinalValue <= _GetFishMaxValue);

        ExitFishing();

        if (success)
        {
            Inventory.instance.AddItem(item, Getfish);
            cook.fish += Getfish;

            _GetFishSprite.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            _GetFishSprite.SetActive(false);
        }
        else
        {
            _MissFishSprite.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            _MissFishSprite.SetActive(false);
        }
    }
    // 釣り終了処理
    void ExitFishing()
    {
        Debug.Log("ExitFishing() 実行");

        _Fishing = false;
        _FishTime = 0;

        _slider.value = _StartValue;
        _PanelFishing.SetActive(false);

        Fisher fisher = FindAnyObjectByType<Fisher>();
        if (fisher != null)
        {
            fisher.EndFishing();
        }
        else
        {
            Debug.LogError("Fisher が見つかりません");
        }
    }
}
