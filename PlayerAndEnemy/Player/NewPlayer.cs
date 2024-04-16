using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float rotationSpeed;
    private Rigidbody rb;

    public Joystick joystickMove; // джойстик движения

    private float vInput;
    private float hInput;

    private HealAndDamagePlayer healAndDamage;
    public TextMeshProUGUI life_state;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        healAndDamage = GameObject.Find("Player").GetComponent<HealAndDamagePlayer>();
    }
    private void Update()
    {
        //PlayerRotation();
        life_state.text = healAndDamage.HP.ToString();
    }

    private void FixedUpdate()
    {
        //Move();
        vInput = Input.GetAxis("Vertical") * runSpeed;
        hInput = Input.GetAxis("Horizontal") * rotationSpeed;
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        rb.MovePosition(this.transform.position +
        this.transform.forward * vInput * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angleRot);
    }
    /*private void Move()
    {
        inputMove = new Vector3(joystickMove.Direction.y, 0, 0);
        inputMove = transform.TransformDirection(inputMove); // изменить направление осей в соответствии с поворотом игрока
        rb.MovePosition(rb.position + inputMove * runSpeed * Time.deltaTime);

        transform.Rotate(new Vector3(0, -joystickMove.Direction.x, 0) * rotationSpeed * Time.deltaTime);
    }*/
}
