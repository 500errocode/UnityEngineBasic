using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // SerializeField Attribute
    // 해당 필드를 인스펙터창에 노출시키는 속성
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    /// <summary>
    /// 스크립트 인스턴스가 처음 로드될 때 호출.
    /// 이 스크립트를 컴포넌트로 가지는 GameObject가 활성화 되어야 호출됨.
    /// MonoBehaviour 들은 생성자를 통해서 생성할수 없기 때문에, Awake()에서 멤버들을 초기화 함
    /// </summary>
    private void Awake()
    {
        Debug.Log("Awake");
    }

    /// <summary>
    /// 이 스크립트 인스턴트가 활성화될때마다 호출됨
    /// + 이 스크립트를 컴포넌트로 가지는 GameObject가 활성화 될 때마다 호출됨.
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    /// <summary>
    /// 모든 멤버변수를 초기값으로 설정. Editor에서만 동작.
    /// 스크립트 인스턴스를 Editor 에서 GameObject에 AddComponent
    /// </summary>
    private void Reset()
    {
        Debug.Log("Reset");
    }

    /// <summary>
    /// 프레임 시작 전에 한번만 호출됨.
    /// Awake로 초기화를 완료한 다른 객체들의 참조를 통해서 초기화해야하는 값들이 있는경우/
    /// 처음에 객체들을 한번 생성해야하는 경우 등에 사용할 수 있다.
    /// </summary>
    private void Start()
    {
        Debug.Log("Start");
    }

    /// <summary>
    /// 고정된 프레임속도로 매프레임 호출됨
    /// 물리연산관련 로직은 이 이벤트함수에서 수행해야함
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
        Debug.Log($"{other.name} 이(가) 트리거됨");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{other.name} 이가 트리거되는 중");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.name} 이(가) 트리거해제됨");
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
    /// 매 프레임마다 호출
    /// 기기 성능마다 프레임 주기는 달라짐
    /// </summary>
    private void Update()
    {
        //Debug.Log("Update");
        // Input class
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        // 거리 = 속력 x 시간
        // 거리변화량 = 속력 x 시간변화량
        // 벡터의 크기 = 각축의 제곱의 합 에 루트
        transform.Translate(new Vector3(h, 0, v) * _moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.up * r * _rotateSpeed * Time.deltaTime);
    }

    /// </summary>
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
    /// 스크립트 인스턴스가 비활성화 될때마다 호출 
    /// </summary>
    private void OnDisable()
    {
        Debug.Log("Disable");
    }

    /// <summary>
    /// 스크립트 인스턴트가 파괴될때 호출
    /// </summary>
    private void OnDestroy()
    {
        Debug.Log("Destory");
    }
}