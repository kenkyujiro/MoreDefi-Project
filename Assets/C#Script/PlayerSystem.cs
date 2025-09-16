using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    public float moveSpeed = 5f;  // ���ړ����x
    public float jumpForce = 5f;  // �W�����v��

    public Transform groundCheck; // �n�ʃ`�F�b�N�p��Transform
    public LayerMask groundLayer; // �n�ʃ��C���[�̐ݒ�
    private Rigidbody2D rb;       // Rigidbody2D

    private bool isGrounded;      // �n�ʂɂ��邩�ǂ���
    private float moveInput;      //���ړ��p�̒l

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//RigidBody�̎擾
    }

    void Update()
    {
        //���͂��擾(AD�ɍ��킹�āA-1��1���擾)
        moveInput = Input.GetAxisRaw("Horizontal");

        // �n�ʂɂ��邩�`�F�b�N(groundCheck.position�𒆐S�ɉ~�`�Ƀ`�F�b�N)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.8f, groundLayer);

        // �X�y�[�X�L�[�������ăW�����v
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // ���ړ� (���������Ȃ̂� FixedUpdate ���ŏ���)
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // y�������ɗ͂�������
    }
}
