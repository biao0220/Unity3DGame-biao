using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



// 控制人物行为，旋转，移动
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
    private float horizontalInput; // A/D键  
    private float verticalInput;    // W/S键  


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
        // 获取玩家输入
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        

        //旋转角色  
       
            
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.y = cameraT.eulerAngles.y; // 只设置Y轴的旋转角度  
        transform.eulerAngles = eulerAngles;
        

        bool running = Input.GetKey(KeyCode.LeftShift);
        float speed = (running) ? runSpeed : walkSpeed;
        float animationSpeedPercent = ((running) ? 1 : 0.5f);


        velocityY +=  gravity;
       
        if (characterController.isGrounded)
        {
            velocityY = 0;
        }
        
        // 计算移动方向  
        Vector3 move = Vector3.zero;
        bool isMoving = false;
        if (Input.GetKey(KeyCode.W))
        {
            move += transform.forward; // 向前移动  
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move -= transform.forward; // 向后移动  
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move -= transform.right; // 向左移动  
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += transform.right; // 向右移动  
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

        // 根据移动方向计算最终速度并应用  
        
        Vector3 movement = move.normalized * speed * Time.fixedDeltaTime + Vector3.up * velocityY;
        characterController.Move(movement);

        //切换动画
        if (isMoving)
        {
            animator.SetFloat("SpeedPercent", animationSpeedPercent);
        }
        else
        {
            animator.SetFloat("SpeedPercent", 0f);
        }

    }

    //跳跃函数
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
