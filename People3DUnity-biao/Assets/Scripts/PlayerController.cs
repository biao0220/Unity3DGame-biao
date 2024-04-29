using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



// ����������Ϊ����ת���ƶ�
public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 2;
    public float runSpeed = 6;

    public float gravity = -0.05f;
    float velocityY;
    public float jumpHeight = 3;

    public GameObject laserPrefab;
    public Transform firePosition;
    
    private CharacterController characterController;
    private Animator animator;
    private float horizontalInput; // A/D��  
    private float verticalInput;    // W/S��  


    Transform cameraT;

    // Start is called before the first frame update
    void Start()
    {   
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        cameraT = Camera.main.transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ��ȡ�������
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        

        //��ת��ɫ  
       
            
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.y = cameraT.eulerAngles.y; // ֻ����Y�����ת�Ƕ�  
        transform.eulerAngles = eulerAngles;
        

        bool running = Input.GetKey(KeyCode.LeftShift);
        float speed = (running) ? runSpeed : walkSpeed;
        float animationSpeedPercent = ((running) ? 1 : 0.5f);


        velocityY +=  gravity;
       
        if (characterController.isGrounded)
        {
            velocityY = 0;
        }
        
        // �����ƶ�����  
        Vector3 move = Vector3.zero;
        bool isMoving = false;
        if (Input.GetKey(KeyCode.W))
        {
            move += transform.forward; // ��ǰ�ƶ�  
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move -= transform.forward; // ����ƶ�  
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move -= transform.right; // �����ƶ�  
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += transform.right; // �����ƶ�  
            isMoving = true;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            Jump();
            
        }
        if (Input.GetMouseButton(0))
        {
            Fire();

        }

        // �����ƶ�������������ٶȲ�Ӧ��  
        
        Vector3 movement = move.normalized * speed * Time.fixedDeltaTime + Vector3.up * velocityY;
        characterController.Move(movement);

        //�л�����
        if (isMoving)
        {
            animator.SetFloat("SpeedPercent", animationSpeedPercent);
        }
        else
        {
            animator.SetFloat("SpeedPercent", 0f);
        }

    }

    //��Ծ����
    void Jump()
    {
        if (characterController.isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
        }
    }

    void Fire()
    {
        Instantiate(laserPrefab,firePosition.position ,firePosition.rotation);
    }






}
