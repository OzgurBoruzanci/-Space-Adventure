using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    Rigidbody2D rgbdy2d;
    Animator animator;

    Vector2 velocity;
    Vector2 scale;

    float moveInput;

    [SerializeField]
    float speed = default;
    
    [SerializeField]
    float acceleration = default;

    [SerializeField]
    float slowdown= default;

    [SerializeField]
    float jumpPower = default;

    [SerializeField]
    int jumpLimit = 3;

    int splashAmount;

    Joystick joystick;
    JoystickButton joystickButton;

    bool jumping;

    void Start()
    {
        joystickButton=FindObjectOfType<JoystickButton>();
        rgbdy2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick=FindObjectOfType<Joystick>();
    }

    
    void Update()
    {
#if UNITY_EDITOR
        KeyboardControl();
#else
                JoystickControl();
#endif
    }

    void KeyboardControl()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        scale = transform.localScale;
        if (moveInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.4f;
        }
        else if (moveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.4f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, slowdown * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            StartJump();
        }
        if (Input.GetKeyUp("space"))
        {
            StopJump();
        }
    }

    void JoystickControl()
    {
        moveInput = joystick.Horizontal;
        scale = transform.localScale;
        if (moveInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.4f;
        }
        else if (moveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.4f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, slowdown * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);
        if (joystickButton.buttonPressed==true && jumping==false)
        {
            jumping = true;
            StartJump();
        }
        if (joystickButton.buttonPressed==false && jumping==true)
        {
            jumping = false;
            StopJump();
        }
    }

    void StartJump()
    {
        if (splashAmount<jumpLimit)
        {
            FindObjectOfType<SoundControl>().JumpSound();
            rgbdy2d.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderControl>().SliderValue(jumpLimit, splashAmount);
        }
        
    }
    void StopJump()
    {
        animator.SetBool("Jump", false);
        splashAmount++;
        FindObjectOfType<SliderControl>().SliderValue(jumpLimit, splashAmount);
    }

    public void JumpReset()
    {
        splashAmount = 0;
        FindObjectOfType<SliderControl>().SliderValue(jumpLimit, splashAmount);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Deadly")
        {
            FindObjectOfType<GameControl>().GameOver();
        }
    }

    public void GameOver()
    {
        Destroy(gameObject);
    }

}
