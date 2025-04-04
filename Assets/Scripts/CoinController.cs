using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CoinController : MonoBehaviour
{
    //유니티 허브에서 수정 용이하도록 회전 속도 정의
    public float rotateSpeed;

    void Update()
    {
        //y축을 기준으로 돌게하는 것. Vector3.up -> (0, 1, 0). 프레임 관계없이 돌수 있도록 deltaTime 사용.
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }
}
