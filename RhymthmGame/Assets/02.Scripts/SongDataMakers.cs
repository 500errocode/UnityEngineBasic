using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

namespace RhythmGame
{
    public class SongDataMakers : MonoBehaviour
    {
        private KeyCode[] _keys = { KeyCode.D, KeyCode.F, KeyCode.J, KeyCode.K };
        private SongData _songData;
        [SerializeField] private VideoPlayer _videoPlayer;
        private bool _doRecord;

        public void StartRecod()
        {
            if (_doRecord)
                return;

            _songData = new SongData(_videoPlayer.clip.name);
            _videoPlayer.Play();
            _doRecord = true;
        }

        public void StopRecord()
        {
            if (_doRecord == false)
                return;

            _videoPlayer.Stop();
            string dir = UnityEditor.EditorUtility.SaveFilePanelInProject("�뷡 ������ ����",
            _songData.name,
            "json",
            String.Empty);
            System.IO.File.WriteAllText(dir, JsonUtility.ToJson(_songData));
            _songData = null;
        }

        private void Update()
        {
            if (_doRecord)
                Recording();
        }

        private void Recording()
        {
            for (int i = 0; i < _keys.Length; i++)
            {
                if (Input.GetKeyDown(_keys[i]))
                {
                    _songData.noteList.Add(CreateNoteData(_keys[i]));
                }
            }
        }

        private NoteData CreateNoteData(KeyCode key)
        {
            NoteData noteData = new NoteData()
            {
                key = key,
                time = (float)Math.Round(_videoPlayer.time, 2)
            };
            return noteData;
        }
    }
}
