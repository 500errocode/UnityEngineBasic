using System;
using UnityEngine;

namespace RhythmGame
{
    /// <summary>
    /// System.Serializable 속성
    /// Serializeble 는 기본적으로는 기본 자료형에 대해서만 가능함 (사용자정의 자료형은 안됨)
    /// 사용자정의 자료형도 Serialization 되도록 해주는 속성
    /// </summary>
    [Serializable]
    public struct NoteData
    {
        public KeyCode key;
        public float time;
    }
}