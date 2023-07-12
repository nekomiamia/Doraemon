using Assets.Scripts.Framework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputController inputController;
    public Vector2 inputDirection;
    public float moveSpeed = 5.0f;
    public SpriteRenderer spriteRenderer;


    private Rigidbody2D rb;
    private Transform srTransform;
    private void Awake()
    {
        inputController = new PlayerInputController();
        rb = GetComponent<Rigidbody2D>();
        srTransform = spriteRenderer.transform;
    }


    private void OnEnable()
    {
        inputController.Enable();
        EventSingle.Instance.AddListener(EventDefine.ClickStartBtn, Move);
    }

    private void OnDisable()
    {
        inputController.Disable(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputDirection = inputController.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();   
    }

    public void Move()
    {
        rb.velocity = new Vector2(inputDirection.x * moveSpeed * Time.deltaTime, inputDirection.y * moveSpeed * Time.deltaTime);

        int faceDir = (int)srTransform.localScale.x;
        // ·­×ª
        if (inputDirection.x > 0) faceDir = 1;
        else if (inputDirection.x < 0) faceDir = -1;

        srTransform.localScale = new Vector3(faceDir, 1, 1);
    }
}
