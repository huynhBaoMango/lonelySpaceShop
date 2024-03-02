using UnityEngine;

public class moving : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển
    private Animator animator; // Tham chiếu đến Animator
    private SpriteRenderer sprenderer;

    private void Start()
    {
        animator = GetComponent<Animator>(); // Lấy Animator từ đối tượng
        sprenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Lấy giá trị input từ bàn phím hoặc thiết bị cầm tay
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Tính toán hướng di chuyển
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed;

        // Áp dụng chuyển động cho Rigidbody của nhân vật
        GetComponent<Rigidbody2D>().velocity = movement;

        // Điều khiển Animator dựa trên input
        if (movement.magnitude > 0)
        {
            animator.SetInteger("action", 1); // Đặt trạng thái đi bộ
        }
        else
        {
            animator.SetInteger("action", 0); // Đặt trạng thái đứng yên
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            sprenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sprenderer.flipX = true;
        }
    }
}

