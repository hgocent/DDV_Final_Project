using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;
    public CharacterController player;
    public GameObject[] Weapon;

    public float playerSpeed;    
    public float gravity;
    public float fallVelocity;
    public float jumpForce;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;

    private bool isWalk = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
     horizontalMove = Input.GetAxis("Horizontal");
     verticalMove = Input.GetAxis("Vertical");

     playerInput = new Vector3(horizontalMove, 0, verticalMove);
     playerInput = Vector3.ClampMagnitude(playerInput, 1);

     camDirection();

     //movePlayer = playerInput.x * camRight + playerInput.z * camForward;

     MovePlayer();
     //movePlayer = movePlayer * playerSpeed;

     player.transform.LookAt(player.transform.position + movePlayer);

     SetGravity();

     PlayerSkills();

     player.Move(movePlayer * Time.deltaTime);

     Debug.Log(player.velocity.magnitude);

     SelWeapon();

    }
    // Funcion para determinar la direccion a la que mira la camara.
   void camDirection()
   {
       camForward = mainCamera.transform.forward;
       camRight = mainCamera.transform.right;

       camForward.y = 0;
       camRight.y = 0;

       camForward = camForward.normalized;
       camRight = camRight.normalized;
   }
   // Funcion para las habilidades de nuestro jugador
   public void PlayerSkills()
   {
       if (player.isGrounded && Input.GetButtonDown("Jump"))
       {
           fallVelocity = jumpForce;
           movePlayer.y = fallVelocity;
       }
   }

   // Funcion para la gravedad.
   void SetGravity()
   {
       if (player.isGrounded){
           fallVelocity = -gravity * Time.deltaTime;
           movePlayer.y = fallVelocity; 
       
       }
       else{
           fallVelocity -= gravity * Time.deltaTime;
           movePlayer.y = fallVelocity;
       }
   }
   void SelWeapon(){
       if (Input.GetKeyDown(KeyCode.T)){
           Weapon[0].SetActive(true);
           Weapon[1].SetActive(false);                     
       }
       if (Input.GetKeyDown(KeyCode.Y)){
           Weapon[0].SetActive(false);
           Weapon[1].SetActive(true);
       } 
       }
    void MovePlayer()
    {
        isWalk = true;
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer = movePlayer * playerSpeed;
    }




}
