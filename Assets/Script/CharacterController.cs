using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour 
{
    static public CharacterController instance; // instance�� ���� ����
    public RGameManager manager; // ���ӸŴ������� �ҷ����� ���� ����
    private CapsuleCollider capsuleCollider;
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    Rigidbody2D Rigidbody2D;

    Animator animator;

    GameObject scanObject; //������Ʈ�� ��ĵ��

    public bool isMoving = true; //��ȭâ�� ������ �� �����̰ų� �� �����̰� �ϱ� ���� true�� ������
    
    // Start is called before the first frame update
    void Start()
    {
        
        if (instance == null)
        {
            //DontDestroyOnLoad(this.gameObject); // ���� ������Ʈ �ı�����

            // �ִϸ����� ������Ʈ ��������
            capsuleCollider = GetComponent<CapsuleCollider>();
            animator = GetComponent<Animator>();
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {        
            UpdateState();
        
       
        //scan Object
        if (Input.GetButtonDown("Jump")&& scanObject != null)
        {
      
            if (isMoving)
            {
                    // If currently moving, stop movement
                isMoving = false;
                Rigidbody2D.velocity = Vector2.zero; // Set velocity to zero to stop movement
            }
            
            else
            {
                // If not moving, resume movement
                isMoving = true;
            }
            manager.Action(scanObject);
            
        }
        // If not moving, don't scan for objects or perform other actions
        if (!isMoving)
        {
            return;
        }

        // Create a ray starting from the character's position and going in the direction of movement
        Vector2 dirVec = movement.normalized; // Get the normalized movement direction

        // Set the ray's starting position as the character's position (assuming the ray starts from the center of the character)
        Vector2 rayStart = Rigidbody2D.position;

        // You can adjust the length of the ray based on your requirements
        float rayLength = 1.0f; // Change this value as needed

        // Calculate the end point of the ray
        Vector2 rayEnd = rayStart + dirVec * rayLength;

        // Cast the ray and check for collisions
        RaycastHit2D rayHit = Physics2D.Raycast(rayStart, dirVec, rayLength, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
            // You can access information about the hit, such as the object it hit (hit.collider.gameObject)
            // and react accordingly (e.g., apply damage, trigger events, etc.).         
        }
        else
        {
            scanObject = null;
        }
    }

    private void FixedUpdate()
    {
        if (manager != null && manager.isAction == true)
        {
            isMoving = false;
        }
        if (!isMoving)
        {
            return;
        }

        MoveCharacter();       

    }

    public void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize(); //������ ����ȭ

        Rigidbody2D.velocity = movement * movementSpeed;
    }

    private void UpdateState()
    {
        if(Mathf.Approximately(movement.x,0)&&Mathf.Approximately(movement.y,0))
        {
            animator.SetBool("isMove", false);
        }
        else
        {
            animator.SetBool("isMove", true);
        }
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
    }

   
}
