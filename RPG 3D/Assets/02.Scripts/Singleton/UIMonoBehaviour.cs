using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class UIMonoBehaviour : MonoBehaviour, IUI
{
    public int sortOrder
    {
        get => canvas.sortingOrder;
        set => canvas.sortingOrder = value;
    }

    protected Canvas canvas;
    protected UIManager manager;

    public event Action onShow;
    public event Action onHide;

    public void Show()
    {
        manager.Push(this); // 매니저한테 이거 제일 위에다가 띄워달라함.
        gameObject.SetActive(true);
        onShow?.Invoke();
    }

    /// <summary>
    /// ui 비활성화
    /// </summary>

    public void Hide()
    {
        manager.PoP(this); // 매니저한테 이거 빼달라함.
        gameObject.SetActive(false);
        onHide?.Invoke();
    }
    
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        manager = UIManager.instance;
        manager.Register(this);
    }
}
