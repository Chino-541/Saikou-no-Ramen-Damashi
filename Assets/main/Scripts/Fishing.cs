using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Fishing : MonoBehaviour
{
    // スライダー関連
    [Header("スライダー関連")]
    [SerializeField] private Slider _slider;
    [SerializeField] private int _BaseValue = 0;　// 最小値
    [SerializeField] private int _MaxValue = 1000; // 最大値
    [SerializeField] private int _StartValue = 500; // 初期位置

    // 値関連
    [Header("値関連")]
    [SerializeField] private int _MinValue = 5;      // 減る量
    [SerializeField] private int _PlusValue = 25;    // 増える量
    [SerializeField] private float _FishSpeed = 0.3f; // 減る間隔
    [SerializeField] private int _MaxFishTime = 10;   // 釣り時間

    //  成功、失敗の判定
    [Header("成否の範囲")]
    [SerializeField] private int _GetFishBaseValue = 400;// 成功範囲
    [SerializeField] private int _GetFishMaxValue = 600;
    private int _FinalValue; // おわあった時の値

    // 結果処理
    [Header("結果")]
    [SerializeField] private ItemData item;
    [SerializeField] private int Getfish;
    [SerializeField] private Cook cook;

    // 演出
    [Header("演出")]
    [SerializeField] private GameObject _GetFishSprite; // 成功演出
    [SerializeField] private GameObject _MissFishSprite; // 失敗演出
    [SerializeField] private GameObject _PanelFishing;

    // 釣りしているかと釣りタイマーのbool
    private bool _Fishing;
    private int _FishTime;

    private void Start()
    {
        // スライダーの初期位置的な
        SetupSlider();
    }
    // 開始時のスライダー
    void SetupSlider()
    {
        // 最大、最小、初めの位置
        _slider.minValue = _BaseValue;
        _slider.maxValue = _MaxValue;
        _slider.value = _StartValue;
    }
    // 釣り開始
    public void StartFishing()
    {
        _PanelFishing.SetActive(true);
        StartCoroutine(FishTimeSystem());
    }

    IEnumerator FishTimeSystem()
    {
        _Fishing = true;
        // 始まったら0に戻る
        _FishTime = 0;

        while (_Fishing)
        {
            // 釣り中は時間が++
            _FishTime++;
            // 制限時間になったら釣りを終了
            if (_FishTime >= _MaxFishTime)
                _Fishing = false;

            _slider.value -= _MinValue;

            yield return new WaitForSeconds(_FishSpeed);
        }
        // 最後のスライダーの位置
        _FinalValue = (int)_slider.value;
        // 位置を用いて判定
        yield return StartCoroutine(FishFinal());
    }

    public void FishPlusSystem(InputAction.CallbackContext context)
    {
        // spaceキーでsliderが上がる
        if (context.performed)
            _slider.value += _PlusValue;
    }

    IEnumerator FishFinal()
    {
        // 最後のsliderの値が規定に達していたら成功でそれ以外は失敗
        bool success = (_FinalValue >= _GetFishBaseValue &&
                        _FinalValue <= _GetFishMaxValue);
        ExitFishing();
        // 成功処理
        if (success)
        {
            Inventory.instance.AddItem(item, Getfish);
            cook.fish += Getfish;

            _GetFishSprite.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            _GetFishSprite.SetActive(false);
        }
        // 失敗処理
        else
        {

            _MissFishSprite.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            _MissFishSprite.SetActive(false);
        }

      
    }

    void ExitFishing()
    {
        Debug.Log("ExitFishing() 実行");

        _Fishing = false;
        _FishTime = 0;

        _slider.value = _StartValue;
        _PanelFishing.SetActive(false);
        // Fisherに通知してFishinfをfalseに戻す
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
