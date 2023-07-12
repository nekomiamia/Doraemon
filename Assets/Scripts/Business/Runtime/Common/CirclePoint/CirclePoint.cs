using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePoint : MonoBehaviour
{
    public Transform target; // ��ת��������
    public float speed = 5f; // ��ת�ٶ�

    /*void Update()
    {
        // ��ȡ��굱ǰλ��
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ����Ŀ��λ������ת���ĵķ���
        Vector3 dir = mousePos - target.transform.position;

        // ������ת�Ƕ�
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        // ������ת��Ԫ������ת����
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);

        // ������ת�����λ��
        float distance = Vector3.Distance(target.transform.position, transform.position);
        Vector3 newPos = target.transform.position + rot * new Vector3(distance, distance, 0f);
        transform.position = newPos;
    }*/
    public float distance = 2f; // ������ָ������ľ���

    void Update()
    {
        // ��ȡ��굱ǰλ��
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // ����ָ�����嵽��������
        Vector3 targetToMouse = mousePos - target.position;

        // ������ת�Ƕ�
        float angle = Mathf.Atan2(targetToMouse.y, targetToMouse.x) * Mathf.Rad2Deg;

        // ������ת��Ԫ������ת����
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = rot;

        // ���������λ��
        Vector3 newPos = target.position + targetToMouse.normalized * distance;

        // ���������λ��
        transform.position = newPos;
    }
}
