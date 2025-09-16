using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    public float moveSpeed = 5f;  // 横移動速度
    public float jumpForce = 5f;  // ジャンプ力

    public Transform groundCheck; // 地面チェック用のTransform
    public LayerMask groundLayer; // 地面レイヤーの設定
    private Rigidbody2D rb;       // Rigidbody2D

    private bool isGrounded;      // 地面にいるかどうか
    private float moveInput;      //横移動用の値

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//RigidBodyの取得
    }

    void Update()
    {
        //入力を取得(ADに合わせて、-1か1を取得)
        moveInput = Input.GetAxisRaw("Horizontal");

        // 地面にいるかチェック(groundCheck.positionを中心に円形にチェック)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.8f, groundLayer);

        // スペースキーを押してジャンプ
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // 横移動 (物理挙動なので FixedUpdate 内で処理)
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // y軸方向に力を加える
    }
}
