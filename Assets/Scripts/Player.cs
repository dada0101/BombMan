using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//玩家类
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;                    //移动速度
    public bool canDropBombs = true;                //是否可以放置炸弹
    public int bombs = 2;
    public bool canMove = true;                     //是否可以移动
    public int playerNumber = 1;                    //玩家编号
    public GameObject bombPrefab;                   //炸弹预制体
    public bool dead = false;                       //是否死亡
    public GameObject Cam;              
    private Animator animator;
    private Rigidbody rigidBody;
    private Transform mTransform;

    // Start is called before the first frame update
    void Start()
    {
        mTransform = transform;
        rigidBody = GetComponent<Rigidbody>();
        animator = mTransform.Find("PlayerModel").GetComponent<Animator>();
    }
    
    // Update is called once per frame 
    void Update()
    {
        animator.SetBool("Walking", false);

        if (!canMove)
            return;
        if(playerNumber == 1)
            PlayerAMovement();
        else
            PlayerBMovement();
    }

    private void PlayerAMovement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            rigidBody.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            rigidBody.rotation = Quaternion.Euler(0, 270, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            rigidBody.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            rigidBody.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("Walking", true);
        }

        if (canDropBombs && Input.GetKey(KeyCode.Space))
            DropBombs();
    }

    private void PlayerBMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            rigidBody.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            rigidBody.rotation = Quaternion.Euler(0, 270, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            rigidBody.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            rigidBody.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("Walking", true);
        }

        if (canDropBombs && Input.GetKey(KeyCode.KeypadEnter))
            DropBombs();
    }
    //放置炸弹 进行四舍五入的处理，使炸弹放置到格子里
    private void DropBombs()
    {
        if(bombPrefab)
            Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(mTransform.position.x),
                Mathf.RoundToInt(mTransform.position.y), Mathf.RoundToInt(mTransform.position.z)), 
                bombPrefab.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Explosion"))
        {
            if (gameObject.name == "Player 1")
                Cam.GetComponent<Score2>().APlayer = true;
            if (gameObject.name == "Player 2")
                Cam.GetComponent<Score2>().BPlayer = true;
            Destroy(gameObject);
        }
    }
}
