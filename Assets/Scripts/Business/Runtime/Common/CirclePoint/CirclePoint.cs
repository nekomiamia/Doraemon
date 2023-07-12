using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePoint : MonoBehaviour
{
    public Transform target; // 旋转中心物体
    public float speed = 5f; // 旋转速度

    /*void Update()
    {
        // 获取鼠标当前位置
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 计算目标位置与旋转中心的方向
        Vector3 dir = mousePos - target.transform.position;

        // 计算旋转角度
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        // 构造旋转四元数并旋转物体
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);

        // 调整旋转物体的位置
        float distance = Vector3.Distance(target.transform.position, transform.position);
        Vector3 newPos = target.transform.position + rot * new Vector3(distance, distance, 0f);
        transform.position = newPos;
    }*/
    public float distance = 2f; // 物体与指定物体的距离

    void Update()
    {
        // 获取鼠标当前位置
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // 计算指定物体到鼠标的向量
        Vector3 targetToMouse = mousePos - target.position;

        // 计算旋转角度
        float angle = Mathf.Atan2(targetToMouse.y, targetToMouse.x) * Mathf.Rad2Deg;

        // 构造旋转四元数并旋转物体
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = rot;

        // 计算物体的位置
        Vector3 newPos = target.position + targetToMouse.normalized * distance;

        // 调整物体的位置
        transform.position = newPos;
    }
}
