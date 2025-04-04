using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CoinController : MonoBehaviour
{
    //����Ƽ ��꿡�� ���� �����ϵ��� ȸ�� �ӵ� ����
    public float rotateSpeed;

    void Update()
    {
        //y���� �������� �����ϴ� ��. Vector3.up -> (0, 1, 0). ������ ������� ���� �ֵ��� deltaTime ���.
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }
}
