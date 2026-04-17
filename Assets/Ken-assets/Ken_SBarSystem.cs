using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class Ken_SBarSystem : MonoBehaviour
{
    public TextMeshProUGUI _CharName;
    public TextMeshProUGUI _CharText;

    private int _Index = -1;
    public Ken_SText _SText;
    private State state = State.COMPLETED;

    private enum State
    {
        PLAYING, COMPLETED
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TypeText(_SText.sentences[++_Index]._Text));
    }
    private IEnumerator TypeText(string text)
    {
        _CharText.text = "";
        state = State.PLAYING;
        int index = 0;
        
        while (state != State.COMPLETED)
        {
            _CharText.text += text[index];
            yield return new WaitForSeconds(0.05f);
            if (++index == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}
