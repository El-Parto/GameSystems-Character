using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*charter to move around */
public class playerControls : MonoBehaviour
{
    private Rigidbody2D rb;
    private float move;

    [SerializeField] private float moveSpeed = 10; //serialize field makes private editble in editor
    [SerializeField] private float jumpHeight = 5; // variable for how high the player can jump
    [SerializeField] private bool grounded; //detects if player touches ground
    [SerializeField] private float sprintMulti = 2; //variable for the sprint multiplier
    

    [SerializeField] private float jetpackForce = 5;
    [SerializeField] private float maxFuel = 5;
    [SerializeField] private float currentFuel = 5; //cntrl D copies the line but is also the delete button on windows?
    [SerializeField] private GameObject flame; //remember "private" anything after private usually means to declare what data type it is e.g GameObject = unity gameObject and flat is a floating point value.
    [SerializeField] private float maxStamina = 10;
    [SerializeField] private float currentStamina = 10;

    [SerializeField] private Image staminaBar;


    public bool creatingCharacter = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // gets the component Rigidbody2D for rb
        

    }

    // Update is called once per frame
    void Update()
    {
        if (creatingCharacter) //if creating character, you can't move.
            return;

        move = Input.GetAxisRaw("Horizontal") * moveSpeed;
        //detecting the movement keys for left and right
         // a variable that determines the input for horizontal movement.
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            move = move * sprintMulti;
            if(move != 0)
                currentStamina -= 2 * Time.deltaTime;
        }
        else if (!Input.GetKey(KeyCode.LeftShift)&& currentStamina < maxStamina)
        {
            currentStamina += 1 * Time.deltaTime;
        }
        //detecting the spacebar for jump button
        if (Input.GetButtonDown("Jump") && grounded) //&& means and
        {
            rb.velocity += Vector2.up * jumpHeight; 
        }
        else if (Input.GetButton("Jump") && grounded == false)
        {
            if (currentFuel > 0)
            {
                flame.SetActive(true);
                rb.velocity += Vector2.up * jetpackForce * Time.deltaTime; // the value of rb velocity is  multiplied by Vector2 multiplied by jetpackForce and deltaTime
                currentFuel -= Time.deltaTime; // this states that currentFuel decreases it's current value
            }
        }
        else if (Input.GetButtonUp("Jump"))
        {
            flame.SetActive(false);
        }
        staminaBar.fillAmount = currentStamina / maxStamina;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move, rb.velocity.y);// variable that names the velocity along 2 vectors andkeeps the velocity the same around


    }

    private void OnCollisionEnter2D(Collision2D collision)//jumps on. collision2d is calling
    {
        if(collision.gameObject.tag == "Ground")
        { 
        grounded = true;
        currentFuel = maxFuel; // because we have already checked to see if we are grounded, currentFuel will = maxFuel as soon as you touch the ground
        //remember, to stop it from going around (if the flame is spinning) contrain the axis of rotation on the rigid body2D on the Z.
        }
    }
    private void OnCollisionExit2D(Collision2D collision) //jumps off
    {
        grounded = false;
    }

    /* notes
GetAxisRaw - one of the main forms of moving across the axis. Arguments(?) are usually a string
answer either "Vertical" or "Horizontal"


*/
    public void RaiseStat(int value)
    { //this button will increase movement speed give interger of 1
        switch (value)
        {
            case 1:
                moveSpeed += 1; //in the first case, it'll increment by 1 the value inside the variable "moveSpeed"
                break;
            case 2:
                jumpHeight += 1; //in the second case, it'll increment by 1 the value inside the variable "jumpHeight"
                break;
            case 3:
                sprintMulti += 1; //in the sprintMulti case, it'll increment by 1 the value inside the variable "sprintMulti"
                break;
            case 4:
                maxFuel += 1; //in the maxFuel case, it'll increment by 1 the value inside the variable "maxFuel"
                break;
            case 5:
                jetpackForce += 1; //adds one to the value inside the variable "jetpackForce"
                break;


        }
    }    public void LowerStat(int value)
    { //this button will increase movement speed give interger of 1
        switch (value)
        {
            case 1:
                moveSpeed -= 1; //in the first case, it'll decrease by 1 the value inside the variable "moveSpeed"
                break;
            case 2:
                jumpHeight -= 1; //in the second case, it'll decrease by 1 the value inside the variable "jumpHeight"
                break;
            case 3:
                sprintMulti -= 1; //in the sprintMulti case, it'll decrease by 1 the value inside the variable "sprintMulti"
                break;
            case 4:
                maxFuel -= 1; //in the maxFuel case, it'll decrease by 1 the value inside the variable "maxFuel"
                break;
            case 5:
                jetpackForce -= 1; //subtracts one to the value inside the variable "jetpackForce"
                break;


        }
    }

}



 