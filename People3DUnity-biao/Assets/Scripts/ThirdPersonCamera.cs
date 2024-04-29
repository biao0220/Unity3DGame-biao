using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���Ƶ����˳������

public class ThirdPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 10;

    public Transform target;

    public float offset = 2;

    public Vector2 pitchMinMax = new Vector2(-30,60);

    public bool lockCursor ;

    //ƫ��
    float yaw = 0;
    //������
    float pitch = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*
         * Cursor.lockState = CursorLockMode.Locked; 
         * ���д��뽫�����������Ļ���ģ���ֹ���ƶ�����Ļ��Ե֮�⡣
         * ���ڵ�һ�˳ƻ�����˳������Ϸ�кܳ�������Ϊ���ͨ��ϣ��
         * ����ƶ�ֱ�ӿ��ƽ�ɫ���ӽǣ������������ָ���뿪��Ϸ���ڡ�
         * Cursor.visible = false; 
         * ���д��뽫���ָ��������������ͨ��
         * ���������һ��ʹ�ã����ṩ����ʽ����Ϸ���顣
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
        //��ȡ�������
        yaw += Input.GetAxis("Mouse X")*mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y")*mouseSensitivity;
        //Ҫǣ�Ƶ�ֵ����Сֵ�����ֵ
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        Vector3 targetRotation = new Vector3(pitch, yaw);

        transform.eulerAngles = targetRotation;
        transform.position = target.position - transform.forward * offset;



    }
}
