using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace RhythmGame
{
    public static class SongDataLoader
    {
        public static bool isLoaded => songData != null && videoClip != null;
        public static SongData songData;
        public static VideoClip videoClip;

        public static void Load(string songName)
        {
            try
            {
                songData = JsonUtility.FromJson<SongData>(Resources.Load<TextAsset>
                  ($"SongDatum/{songName}").ToString());
                videoClip = Resources.Load<VideoClip>($"SongClips/{songName}");
                Debug.Log($"[SongDataLoader] : {songName} �� �뷡 �����Ͱ� �ε�Ǿ����ϴ�.");
            }
            catch
            {
                throw new System.Exception($"[SongDataLoader] : {songName} �뷡 ������ �ε� ����. ��θ� ��Ȯ�ϰ� Ȯ���ϼ���...");
            }
        }
    }
}
