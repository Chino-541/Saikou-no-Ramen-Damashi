using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class SoundButton : MonoBehaviour
{
    bool isInited = false; //初期化されたか
    [SerializeField] AudioClip _audioClip; //音源
    [SerializeField] AudioSource _audioSource; //AudioSource
    [SerializeField] Button _button; //ボタン

    //初期化(AudioSourceに音源を設定)
    public void Init(Action action, MonoBehaviour monoBehaviour)
    {
        isInited = true;

        //音源を割り当てる
        _audioSource.clip = _audioClip;

        //OnClickに処理を割り当てる
        _button.onClick.AddListener(() => monoBehaviour.StartCoroutine(Play(action)));
    }

    //鳴り終わったことを通知するコルーチン
    IEnumerator Play(Action action)
    {
        //初期化されていなかったらエラー
        if (!isInited)
        {
            Debug.LogError("AudioSourceに音源を設定していない");
            yield break;
        }

        //ボタンが入力を受け付けないようにする
        _button.enabled = false;

        //効果音を鳴らす
        _audioSource.PlayOneShot(_audioClip);

        //終了まで待機
        yield return new WaitWhile(() => _audioSource.isPlaying);

        //処理
        action();

        //ボタンが入力を受け付けるようにする
        _button.enabled = true;
    }
}
