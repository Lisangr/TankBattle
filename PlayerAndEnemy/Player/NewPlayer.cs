using TMPro;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float rotationSpeed;
    private Rigidbody rb;

    private float vInput;
    private float hInput;

    private HealAndDamagePlayer healAndDamage;
    public TextMeshProUGUI life_state;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        healAndDamage = GameObject.Find("Player").GetComponent<HealAndDamagePlayer>();
    }
    private void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationX 
                        | RigidbodyConstraints.FreezeRotationY 
                        | RigidbodyConstraints.FreezeRotationZ;
    }
    private void Update()
    {
        life_state.text = healAndDamage.HP.ToString();
    }

    private void FixedUpdate()
    {
        vInput = Input.GetAxis("Vertical") * runSpeed;
        hInput = Input.GetAxis("Horizontal") * rotationSpeed;
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        rb.MovePosition(this.transform.position +
        this.transform.forward * vInput * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angleRot);
    }
}
