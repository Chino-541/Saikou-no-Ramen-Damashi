using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewText",menuName ="Data/New Text Scene")]
[System.Serializable]
public class Ken_SText : ScriptableObject
{
    public List<Sentence> sentences;
    public Sprite _Background;
    public Ken_SText _NextScene;

    [System.Serializable]
    public struct Sentence
    {
        public string _Text;
        public Ken_SChar _Char;
    }
    
}
