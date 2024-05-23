using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;

    [Header ("플레이어 움직임 정보")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float gravity;
    [SerializeField] private float rotSpeed;

    private bool isJump;
    public bool IsJump { get => isJump; set => isJump = value; }

    private Transform camTransform;

    private Vector3 movement;
    private Vector3 direction;

    private bool grounded = false;
    private float groundedTimer;
    private float vSpeed = 0.0f;

    private float h, v;

    private int hashMeleeAttack = Animator.StringToHash("MeleeAttack");
    private int hashCombo1 = Animator.StringToHash("Combo1");
    private int hashCombo2 = Animator.StringToHash("Combo2");
    private int hashCombo3 = Animator.StringToHash("Combo3");
    private int hashCombo4 = Animator.StringToHash("Combo4");

    private AnimatorStateInfo currentStateInfo;
    private bool isAnimatorTransition;
    public bool isDodging;

    private void Awake()
    {
        GetComponents();
        camTransform = Camera.main.transform;
    }

    private void GetComponents()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (CharacterHealth.isDie) return;

        Jump();
        Move();
        Dodge();
        GravityDown();
    }

    private void Jump()
    {
        if (!controller.isGrounded)
        {
            if (grounded)
            {
                groundedTimer += Time.deltaTime;

                if (groundedTimer >= 0.5f)
                {
                    grounded = false;
                    IsJump = true;
                }
            }
        }
        else
        {
            groundedTimer = 0.0f;
            grounded = true;
            IsJump = false;
        }

        if (grounded && Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
            IsJump = true;
            grounded = false;
            vSpeed = jumpPower;
        }
    }

    private void Move()
    {
        if (isDodging) return;

        animator.SetBool("IsGround", grounded);

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        direction = new Vector3(h, 0, v).normalized;
        direction = Quaternion.AngleAxis(camTransform.rotation.eulerAngles.y, Vector3.up) * direction;
        direction.Normalize();

        currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        isAnimatorTransition = animator.IsInTransition(0);

        if (currentStateInfo.shortNameHash == hashMeleeAttack ||
            currentStateInfo.shortNameHash == hashCombo1 ||
            currentStateInfo.shortNameHash == hashCombo2 ||
            currentStateInfo.shortNameHash == hashCombo3 ||
            currentStateInfo.shortNameHash == hashCombo4)
        {
            movement = direction * 0;
            return;
        }

        animator.SetFloat("Move", direction.magnitude);
        movement = speed * Time.deltaTime * direction;
        controller.Move(movement);

        if (movement != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
        }
    }

    private void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDodging && !IsJump)
        {
            animator.SetTrigger("Dodge");
        }
    }

    private void GravityDown()
    {
        vSpeed = vSpeed - gravity * Time.deltaTime;

        if (vSpeed < -gravity)
        {
            vSpeed = -gravity;
        }

        var verticalMove = new Vector3(0, vSpeed * Time.deltaTime, 0);
        var flag = controller.Move(verticalMove);

        if ((flag & CollisionFlags.Below) != 0)
        {
            vSpeed = 0f;
        }
    }
}
