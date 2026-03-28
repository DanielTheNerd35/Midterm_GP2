using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Stats")]
    public float moveSpeed;

    [Header("References")]
    private Rigidbody2D rb;
    private Animator anim;
    private ToolType heldTool = ToolType.NONE;
    private SeedType heldSeed = SeedType.NONE;

    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    public void SetHeldItem(ToolType tool, SeedType seed)
    {
        heldTool = tool;
        heldSeed = seed;
    }

    public ToolType GetHeldTool()
    {
        return heldTool;
    }

    public SeedType GetHeldSeed()
    {
        return heldSeed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move (InputAction.CallbackContext context)
    {
        anim.SetBool("isWalking", true);

        if (context.canceled)
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("LastInputX", moveInput.x);
            anim.SetFloat("LastInputY", moveInput.y);
        }

        moveInput = context.ReadValue<Vector2>();
        anim.SetFloat("InputX", moveInput.x);
        anim.SetFloat("InputY", moveInput.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.gameObject.GetComponent<Item>();

        if (item == null)
            return;

        Debug.Log("Picked up " + item.toolType);

        PlantLocation plant = collision.gameObject.GetComponent<PlantLocation>();
        if (plant == null)
        {
            return;
        }

    }
}
