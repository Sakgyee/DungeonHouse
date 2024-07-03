using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerContro : MonoBehaviour
{
    static public PlayerContro instance; // instance의 값을 공유
    public RGameManager manager; // 게임매니저에서 불러오기 위해 넣음
    public PotionManager pmanager; //포션매니저에서 불러오기 위해
    private BoxCollider2D boxCollider;
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    Rigidbody2D Rigidbody2D;
    
    Animator animator;

    GameObject scanObject; //오브젝트가 스캔됨

    public bool isMoving = true; //대화창이 켜졌을 때 움직이거나 못 움직이게 하기 위함 true는 움직임

    public float attackCooldown = 0.5f;
    private float lastAttackTime;

    public GameObject attackHitbox;

    public float pushBackForce = 5.0f; // The force applied to push the player back upon collision.
    public int damage = 10;
    public int health;
    public int PlayerHealth = 100;
    public int maxHealth = 100;
    private bool isInvincible = false;
    public SpriteRenderer playerSpriteRenderer;
    private float invincibilityTimer = 0.0f;
    private float blinkTimer = 0.0f;
    private float blinkInterval = 0.05f;
    private bool isBlinking = false;
    public float invincibilityDuration = 3.0f;

    public GameObject PotionFull;
    public Text PotionF;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        playerSpriteRenderer = GetComponent<SpriteRenderer>(); //플레이어 깜빡 효과

        if (instance == null)
        {
            //DontDestroyOnLoad(this.gameObject); // 게임 오브젝트 파괴금지

            // 애니메이터 컴포넌트 가져오기
            boxCollider = GetComponent<BoxCollider2D>();
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
        
        //플레이어 깜빡효과
        if (isInvincible)
        {
            // Handle blinking effect during invincibility
            BlinkEffect();
        }
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0)
            {
                isInvincible = false;
                playerSpriteRenderer.enabled = true;
                // Invincibility duration has expired
                // You can add code to handle the end of invincibility here
            }
        }

        //scan Object
        if (Input.GetButtonDown("Jump") && scanObject != null)
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

        // 공격 코드
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Handle attack input when the "Z" key is pressed
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Determine the attack direction based on the character's facing direction
            Vector2 attackDirection = animator.GetFloat("MoveX") > 0 ? Vector2.right :
                                      animator.GetFloat("MoveX") < 0 ? Vector2.left :
                                      animator.GetFloat("MoveY") > 0 ? Vector2.up :
                                      animator.GetFloat("MoveY") < 0 ? Vector2.down :
                                      Vector2.zero; // No direction if not moving

            // Ensure the attack direction is normalized
            attackDirection.Normalize();

            Attack(attackDirection);
        }

        movement.Normalize(); //벡터의 정규화

        //레이코드

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
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(PlayerHealth == maxHealth && PotionManager.Potioncount > 0)
            {
                PotionManager.Potioncount += 1;
                
                    StartCoroutine(Potionfull());
    

            }
            // Call the UsePotion method from the PotionManager
            PotionManager.instance.UsePotion();
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

        movement.Normalize(); //벡터의 정규화

        Rigidbody2D.velocity = movement * movementSpeed;
    }

    private void UpdateState()
    {
        if (Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.y, 0))
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

    // Add a method for handling attacks
    private void Attack(Vector2 attackDirection)
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Update the timestamp of the last attack
            lastAttackTime = Time.time;

            float moveX = animator.GetFloat("MoveX");
            float moveY = animator.GetFloat("MoveY");

            if (Mathf.Abs(moveX) > Mathf.Abs(moveY))
            {
                // Horizontal attack
                if (moveX > 0)
                {
                    // Right
                    animator.SetTrigger("AttackR");
                }
                else
                {
                    // Left
                    animator.SetTrigger("AttackL");
                }
            }
            else
            {
                // Vertical attack
                if (moveY > 0)
                {
                    // Up
                    animator.SetTrigger("AttackU");
                }
                else
                {
                    // Down
                    animator.SetTrigger("AttackD");
                }
            }

            // Enable the attack hitbox
            attackHitbox.SetActive(true);

            // Move the attack hitbox in the attack direction
            attackHitbox.transform.position = (Vector2)transform.position + attackDirection;

            // Start a coroutine to disable the hitbox after a short time
            StartCoroutine(DisableHitboxAfterDelay(0.1f));

        }

    }

    IEnumerator DisableHitboxAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isInvincible = false;
        playerSpriteRenderer.enabled = true;
        attackHitbox.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && invincibilityTimer <= 0)
        {
            TakeDamage(damage);
            Push(collision.transform.position);       

            invincibilityTimer = invincibilityDuration;

            StartCoroutine(DisableCollisionAndMovementForTime(0.5f));

        }
        
    }
    
    void Push(Vector2 targetPos)
    {
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        int dird = transform.position.y - targetPos.y > 0 ? 1 : -1;
        Rigidbody2D.AddForce(new Vector2(dirc, dird) * 3, ForceMode2D.Impulse);

    }
    IEnumerator DisableCollisionAndMovementForTime(float time)
    {
        // Disable collisions with other objects and prevent movement for a specified time
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Object"), true);
        isMoving = false;

        yield return new WaitForSeconds(time);

        // Re-enable collisions and allow movement after the specified time
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Object"), false);
        isMoving = true;
    }

    IEnumerator DisableInvincibilityAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isInvincible = false;
        playerSpriteRenderer.enabled = true; // Make sure the player is visible again after invincibility ends
    }
    
    void TakeDamage(int damage)
    {
        isInvincible = true;
        StartCoroutine(DisableInvincibilityAfterDelay(3.0f));

        health -= damage;
        PlayerHealth -= damage;

        if (PlayerHealth <= 0)
        {
            if (SceneManager.GetActiveScene().name == "Dungeon1")
            {
                SceneManager.LoadScene("GameOver 1");
                if(PotionManager.Potioncount == 0)
                {
                    PotionManager.Potioncount += 3;
                }
                if (PotionManager.Potioncount == 1)
                {
                    PotionManager.Potioncount += 2;
                }
                if (PotionManager.Potioncount == 2)
                {
                    PotionManager.Potioncount += 1;
                }              
            }
            if (SceneManager.GetActiveScene().name == "Dungeon2")
            {
                SceneManager.LoadScene("GameOver 2");
                if (PotionManager.Potioncount == 0)
                {
                    PotionManager.Potioncount += 3;
                }
                if (PotionManager.Potioncount == 1)
                {
                    PotionManager.Potioncount += 2;
                }
                if (PotionManager.Potioncount == 2)
                {
                    PotionManager.Potioncount += 1;
                }
            }
            if (SceneManager.GetActiveScene().name == "Dungeon3")
            {
                SceneManager.LoadScene("GameOver 3");
                if (PotionManager.Potioncount == 0)
                {
                    PotionManager.Potioncount += 3;
                }
                if (PotionManager.Potioncount == 1)
                {
                    PotionManager.Potioncount += 2;
                }
                if (PotionManager.Potioncount == 2)
                {
                    PotionManager.Potioncount += 1;
                }
            }
        }

        // Add your code here to handle the player's reaction to taking damage
        Debug.Log("Player health: " + PlayerHealth);

    }
    void BlinkEffect()
    {
        blinkTimer += Time.deltaTime;

        if (blinkTimer >= blinkInterval)
        {
            isBlinking = !isBlinking; // Toggle blinking state
            playerSpriteRenderer.enabled = isBlinking;

            blinkTimer = 0.0f; // Reset timer      
        }
    }
    public void Postion(int amount)
    {
        PlayerHealth += amount;
        health += amount;
        // Add code here to fill the player's stamina
        // For example, you might have a stamina variable in your PlayerContro script:
        if (PlayerHealth > maxHealth)
        {            
            PlayerHealth -= PlayerHealth;
            PlayerHealth = 100;
            health -= health;
            health = 100;
        }
        

        Debug.Log("Player's Stamina Filled with " + amount);
    }
    IEnumerator Potionfull()
    {
        // Display the UI element
        PotionFull.SetActive(true);

        PotionF.text = "이미 최대 체력이야";
        // Add torque effect (assuming you have a TorqueEffect script attached to the UI element)
        //PotionTalk torqueEffect = torqueUI.GetComponent<PotionTalk>();        

        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Hide the UI element after 1 second
        PotionFull.SetActive(false);
    }
}
