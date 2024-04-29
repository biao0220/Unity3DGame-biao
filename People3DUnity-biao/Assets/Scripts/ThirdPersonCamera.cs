using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制第三人称摄像机

public class ThirdPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 10;

    public Transform target;

    public float offset = 2;

    public Vector2 pitchMinMax = new Vector2(-30,60);

    public bool lockCursor ;

    //偏航
    float yaw = 0;
    //俯仰角
    float pitch = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*
         * Cursor.lockState = CursorLockMode.Locked; 
         * 这行代码将鼠标锁定在屏幕中心，防止它移动到屏幕边缘之外。
         * 这在第一人称或第三人称射击游戏中很常见，因为玩家通常希望
         * 鼠标移动直接控制角色的视角，而不是让鼠标指针离开游戏窗口。
         * Cursor.visible = false; 
         * 这行代码将鼠标指针隐藏起来。这通常
         * 与鼠标锁定一起使用，以提供沉浸式的游戏体验。
         */
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //获取鼠标输入
        yaw += Input.GetAxis("Mouse X")*mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y")*mouseSensitivity;
        //要牵制的值，最小值，最大值
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        Vector3 targetRotation = new Vector3(pitch, yaw);

        transform.eulerAngles = targetRotation;
        transform.position = target.position - transform.forward * offset;



    }
}
