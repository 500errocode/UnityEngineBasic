using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RhythmGame
{
    /// <summary>
    /// � �뷡�� � ��Ʈ��� �̷�����ִ����� ���� ������
    /// </summary>
    [Serializable]
    public class SongData
    {
        public string name;
        public List<NoteData> noteList;
        public SongData(string name)
        {
            this.name = name;
            noteList= new List<NoteData>();
        }
    }
}
