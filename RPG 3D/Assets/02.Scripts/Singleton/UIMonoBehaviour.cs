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
        manager.Push(this); // �Ŵ������� �̰� ���� �����ٰ� ����޶���.
        gameObject.SetActive(true);
        onShow?.Invoke();
    }

    /// <summary>
    /// ui ��Ȱ��ȭ
    /// </summary>

    public void Hide()
    {
        manager.PoP(this); // �Ŵ������� �̰� ���޶���.
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
