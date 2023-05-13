using System;
using UnityEngine;

namespace RhythmGame
{
    /// <summary>
    /// System.Serializable �Ӽ�
    /// Serializeble �� �⺻�����δ� �⺻ �ڷ����� ���ؼ��� ������ (��������� �ڷ����� �ȵ�)
    /// ��������� �ڷ����� Serialization �ǵ��� ���ִ� �Ӽ�
    /// </summary>
    [Serializable]
    public struct NoteData
    {
        public KeyCode key;
        public float time;
    }
}