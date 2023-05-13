using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RhythmGame
{
    public class GamePlayButton : MonoBehaviour
    {
        private void Start()
        {
            Button button = GetComponent<Button>();
                button.onClick.AddListener(GameManager.instance.PlayGame);
            GameManager.instance.onSongSelectedChanged += (songName) =>
            {
                button.interactable = string.IsNullOrEmpty(songName) == false;
            };
            button.interactable = false;
        }
    }
}
