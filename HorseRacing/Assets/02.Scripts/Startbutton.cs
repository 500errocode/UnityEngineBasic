using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startbutton : MonoBehaviour
{
    [SerializeField] private Button _start;

    private void Awake()
    {
        _start.onClick.AddListener(StartClickedLog);
        _start.onClick.AddListener(() => Debug.Log("Start Cliked"));
    }

    private void StartClickedLog()
    {
        Debug.Log("Start Clicked");
    }
}
