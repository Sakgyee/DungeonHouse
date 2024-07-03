using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RequireComponent는 이 스크립트를 추가한 게임 오브젝트에 필요한 컴포넌트가 없으면
//그 해당 컴포넌트를 자동으로 추가하게 한다.(Rigidbody2D,CircleCollider2D,Animator컴포넌트가 없으면 자동으로 추가)
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]
public class ScanPlayer : MonoBehaviour
{
    public float pursuitSpeed; //추적 속도
    public float wanderSpeed; //적이 떠돌아 다니는 움직임 속도
    public float currentSpeed; //현재 속도

    public float directionChangeInterval; //방향변경간격
    public bool followPlayer; //플레이어 추적

    Coroutine moveCoroutine;
    CircleCollider2D CircleCollider2D;
    Rigidbody2D Rigidbody2D;
    Animator animator;

    Transform targetTransform = null;
    Vector3 endPosition;
    float currenAngle = 0;

    private Transform EnemyMove;

    static public Dictionary<int, ScanPlayer> instances = new Dictionary<int, ScanPlayer>();
    public int damage = 30;

    // Store health and max health in dictionaries
    public static Dictionary<int, int> enemyHealth = new Dictionary<int, int>();
    public static Dictionary<int, int> enemyMaxHealth = new Dictionary<int, int>();

    public int uniqueID;

    void Awake()
    {
        instances[uniqueID] = this;
        // Add initial health and max health values for this enemy
        enemyHealth[uniqueID] = 90;
        enemyMaxHealth[uniqueID] = 90;
    }
    void Start()
    {

        EnemyMove = transform.GetChild(0); //트랜스폼 참조

        animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        CircleCollider2D = GetComponent<CircleCollider2D>();
        currentSpeed = wanderSpeed;
        StartCoroutine(WanderRoutine());
    }

    void Update()
    { 
        Debug.DrawLine(Rigidbody2D.position, endPosition, Color.red);
    }

    public IEnumerator WanderRoutine()
    {
        while (true)
        {
            ChooseNewEndPoint();

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            moveCoroutine = StartCoroutine(Move(Rigidbody2D, currentSpeed));

            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    void ChooseNewEndPoint()
    {
        endPosition = transform.position;
        currenAngle += Random.Range(0, 360);
        currenAngle = Mathf.Repeat(currenAngle, 360);
        endPosition += Vector3FromAngle(currenAngle);
    }

    Vector3 Vector3FromAngle(float inputAngleDegrees)
    {
        float inputAngleRadians = inputAngleDegrees * Mathf.Deg2Rad;

        return new Vector3(Mathf.Cos(inputAngleRadians), Mathf.Sin(inputAngleRadians), 0);
    }

    public IEnumerator Move(Rigidbody2D rigidBodyToMove, float speed)
    {
        float remainingDistance = (transform.position - endPosition).sqrMagnitude;

        while (remainingDistance > float.Epsilon)
        {
            if (targetTransform != null)
            {
                endPosition = targetTransform.position;
            }

            if (rigidBodyToMove != null)
            {
                animator.SetBool("Walk", true);
                Vector3 newPosition = Vector3.MoveTowards(rigidBodyToMove.position, endPosition, speed * Time.deltaTime);

                // 적이 오른쪽으로 갈땐 오른쪽 방향을 보고 왼쪽으로 갈땐 왼쪽방향을 보게 만드는 코드
                if (newPosition.x < rigidBodyToMove.position.x)
                {
                    transform.localScale = new Vector3(5f, 5f, 5f); // Flip along X-axis
                }
                else if (newPosition.x > rigidBodyToMove.position.x)
                {
                    transform.localScale = new Vector3(-5f, 5f, 5f); // Face right
                }

                Rigidbody2D.MovePosition(newPosition);
                remainingDistance = (transform.position - endPosition).sqrMagnitude;

            }
            yield return new WaitForFixedUpdate();
        }
        animator.SetBool("Walk", false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && followPlayer)
        {
            currentSpeed = pursuitSpeed;
            targetTransform = collision.gameObject.transform;
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }

            moveCoroutine = StartCoroutine(Move(Rigidbody2D, currentSpeed));

        }

        
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Walk", false);
            currentSpeed = wanderSpeed;

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            targetTransform = null;
        }
    }

    void OnDrawGizmos()
    {
        if (CircleCollider2D != null)
        {
            Gizmos.DrawWireSphere(transform.position, CircleCollider2D.radius);
        }
    }
    /*
    public void PushBack(Vector2 pushDirection)
    {
        // Apply a force to push the game object back in the specified direction
        Rigidbody2D.AddForce(pushDirection * pushBackForce, ForceMode2D.Impulse);
    }
    */
    public void ReduceHealth(int damage)
    {
        // Update health for this enemy based on its unique ID
        enemyHealth[uniqueID] -= damage;

        Debug.Log("Enemy Health: " + enemyHealth[uniqueID]);

        if (enemyHealth[uniqueID] <= 0)
        {
            // Enemy defeated, you can handle this event
            // e.g., play an animation, destroy the enemy, etc.
            Destroy(gameObject);
        }
    }

}
