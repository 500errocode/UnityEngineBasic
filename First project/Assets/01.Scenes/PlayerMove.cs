using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// ��ũ��Ʈ �ν��Ͻ��� ó�� �ε�� �� ȣ��.
    /// �� ��ũ��Ʈ�� ������Ʈ�� ������ GameObject�� Ȱ��ȭ �Ǿ�� ȣ���.
    /// MonoBehaviour ���� �����ڸ� ���ؼ� �����Ҽ� ���� ������, Awake()���� ������� �ʱ�ȭ ��
    /// </summary>
    private void Awake()
    {
        Debug.Log("Awake");
    }

    /// <summary>
    /// �� ��ũ��Ʈ �ν���Ʈ�� Ȱ��ȭ�ɶ����� ȣ���
    /// + �� ��ũ��Ʈ�� ������Ʈ�� ������ GameObject�� Ȱ��ȭ �� ������ ȣ���.
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    /// <summary>
    /// ��� ��������� �ʱⰪ���� ����. Editor������ ����
    /// ��ũ��Ʈ �ν��Ͻ��� Editor ���� GameObject�� AddComponent
    /// </summary>
    private void Reset()
    {
        Debug.Log("Reset");
    }

    /// <summary>
    /// ������ ���� ���� �ѹ��� ȣ���.
    /// Awake�� �ʱ�ȭ�� �Ϸ��� �ٸ� ��ü���� ������ ���ؼ� �ʱ�ȭ�ؾ��ϴ� ������ �ִ°��/
    /// ó���� ��ü���� �ѹ� �����ؾ��ϴ� ��� � ����� �� �ִ�.
    /// </summary>
    private void Start()
    {
        Debug.Log("Start");
    }

    /// <summary>
    /// ������ �����Ӽӵ��� �������� ȣ���
    /// ����������� ������ �� �̺�Ʈ�Լ����� �����ؾ���
    /// </summary>
    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name} ��(��) Ʈ���ŵ�");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{other.name} �̰� Ʈ���ŵǴ� ��");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.name} ��(��) Ʈ����������");
    }

    /// <summary>
    /// 
    /// 
    /// </summary>
    private void Update()
    {
        //Debug.Log("Update");
    }

    /// <summary>
    /// 
    /// 
    /// </summary>
    private void LateUpdate()
    {
        //Debug.Log("LateUpdate");
    }

    /// <summary>
    /// 
    /// 
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(Vector3.up * 2.0f, Vector3.one * 2.0f);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(Vector3.up * 1.0f + Vector3.right * 1.0f, 1.0f);
    }

    private void OnApplicationFocus(bool pause)
    {
        
    }

    /// <summary>
    /// ��ũ��Ʈ �ν��Ͻ��� ��Ȱ��ȭ �ɶ����� ȣ�� 
    /// </summary>
    private void OnDisable()
    {
        Debug.Log("Disable");
    }

    /// <summary>
    /// ��ũ��Ʈ �ν���Ʈ�� �ı��ɶ� ȣ��
    /// </summary>
    private void OnDestroy()
    {
        Debug.Log("Destory");
    }
}