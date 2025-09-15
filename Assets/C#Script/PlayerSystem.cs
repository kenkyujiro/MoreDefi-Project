using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    public float jumpForce = 5f;  // ジャンプ力
    public Transform groundCheck; // 地面チェック用のTransform
    public LayerMask groundLayer; // 地面レイヤーの設定
    private Rigidbody2D rb;       // Rigidbody2D
    private bool isGrounded;      // 地面にいるかどうか

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//RigidBodyの取得
    }

    void Update()
    {
        // 地面にいるかチェック(groundCheck.positionを中心に円形にチェック)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.8f, groundLayer);

        // スペースキーを押してジャンプ
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // y軸方向に力を加える
    }
}
