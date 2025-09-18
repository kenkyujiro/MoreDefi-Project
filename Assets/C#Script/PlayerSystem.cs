using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    public float moveSpeed = 5f;  //���ړ����x
    public float jumpForce = 8f;  //�W�����v��

    public Transform groundCheck; //�n�ʃ`�F�b�N�p��Transform
    public LayerMask groundLayer; //�n�ʃ��C���[�̐ݒ�
    private Rigidbody2D rb;       //Rigidbody2D

    private bool isGrounded;      //�n�ʂɂ��邩�ǂ���
    private int JumpCount;        //�W�����v������
    public int MaxJump;           //�W�����v�ł���ő��
    private float moveInput;      //���ړ��p�̒l

    public GameObject GameManager;//�Q�[���N���A��Q�[���I�[�o�[�Ȃǂ��Ǘ�����
    private GameManager gameManager;

    private float time;             //���݂̎���
    private float OverTime = 10f;    //�ő�^�C��(���̃^�C�����z����ƃS�[�����o������)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//RigidBody�̎擾

        GameManager = GameObject.Find("GameManager");
        gameManager = GameManager.GetComponent<GameManager>();

        JumpCount = 0;
        MaxJump = 1;
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;

        //���͂��擾(AD�ɍ��킹�āA-1��1���擾)
        moveInput = Input.GetAxisRaw("Horizontal");

        // �n�ʂɂ��邩�`�F�b�N(groundCheck.position�𒆐S�ɉ~�`�Ƀ`�F�b�N)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.8f, groundLayer);

        if (isGrounded)
        {
            JumpCount = 0;
        }

        // �X�y�[�X�L�[�������ăW�����v
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount < MaxJump)
        {
            Jump();
            JumpCount += 1;
        }

        //time���I�[�o�[������GOAL���o������
        if(time >= OverTime)
        {
            Debug.Log("Khoot");
            time = 0f;
        }
    }

    void FixedUpdate()
    {
        //���ړ� (���������Ȃ̂� FixedUpdate ���ŏ���)
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        //y�������ɗ͂�������
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            gameManager.GameClear();
        }
    }
}
