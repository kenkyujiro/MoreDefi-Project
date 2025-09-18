using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    public float moveSpeed = 5f;  //横移動速度
    public float jumpForce = 8f;  //ジャンプ力

    public Transform groundCheck; //地面チェック用のTransform
    public LayerMask groundLayer; //地面レイヤーの設定
    private Rigidbody2D rb;       //Rigidbody2D

    private bool isGrounded;      //地面にいるかどうか
    private int JumpCount;        //ジャンプした回数
    public int MaxJump;           //ジャンプできる最大回数
    private float moveInput;      //横移動用の値

    public GameObject GameManager;//ゲームクリアやゲームオーバーなどを管理する
    private GameManager gameManager;

    private float time;             //現在の時間
    private float OverTime = 10f;    //最大タイム(このタイムを越えるとゴールが出現する)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//RigidBodyの取得

        GameManager = GameObject.Find("GameManager");
        gameManager = GameManager.GetComponent<GameManager>();

        JumpCount = 0;
        MaxJump = 1;
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;

        //入力を取得(ADに合わせて、-1か1を取得)
        moveInput = Input.GetAxisRaw("Horizontal");

        // 地面にいるかチェック(groundCheck.positionを中心に円形にチェック)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.8f, groundLayer);

        if (isGrounded)
        {
            JumpCount = 0;
        }

        // スペースキーを押してジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount < MaxJump)
        {
            Jump();
            JumpCount += 1;
        }

        //timeがオーバーしたらGOALを出現する
        if(time >= OverTime)
        {
            Debug.Log("Khoot");
            time = 0f;
        }
    }

    void FixedUpdate()
    {
        //横移動 (物理挙動なので FixedUpdate 内で処理)
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        //y軸方向に力を加える
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
