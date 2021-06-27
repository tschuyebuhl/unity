using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorRb : BehaviorRb
{

  private float vInput;
  private float hInput;

  public float distanceToGround = 0.1f;

  public LayerMask groundLayer;

  private Rigidbody _rb;

  private BoxCollider _col;

    void Start()
    {
    _rb = GetComponent<Rigidbody>();
    _col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    vInput = Input.GetAxis("Vertical") * moveSpeed;
    hInput = Input.GetAxis("Horizontal") * rotateSpeed;

    /* 
    this.transform.Translate(Vector3.forward * vInput *
    Time.deltaTime);
    this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
    */
    }
  //1
  void FixedUpdate()
	{
    //2
    Vector3 rotation = Vector3.up * hInput;

    if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))
		{
      _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
		}
    //3
    Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
    //4
    _rb.MovePosition(this.transform.position +
      this.transform.forward * vInput * Time.fixedDeltaTime);
    //5
    _rb.MoveRotation(_rb.rotation * angleRot);

	}
  public override void Pickup()
  {
    this.moveSpeed *= 2.0f;
  }
  public override void JumpPickup()
  {
    jumpVelocity *= 2.0f;
  }

  private bool IsGrounded()
	{
    Vector3 cubeBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);

    bool grounded = Physics.CheckCapsule(_col.bounds.center,
        cubeBottom, distanceToGround, groundLayer,
      QueryTriggerInteraction.Ignore);


    return grounded;
	}
}
/*
 * zmienna typu Rigidbody przechowuje informacje o komponencie Rigidbody gracza.
 * metoda Start nam inicjalizuje zmienną dołączonym komponentem
 * GetComponent zwróci null jeśli nie będzie tego komponentu, jeśli jest to po prostu go zwróci.
 * usunięto linijki o translacji i rotacji - nie są na ten moment potrzebne.
 */
/*
 * 1. Każdy kod który zawiera fizykę oraz Rigidbody idzie do FixedUpdate - jest to metoda niezależna od FPSów.
 * 2. zmienna Vector3 która przechowuje rotację lewo/prawo: 
 *  Vector3.up * hInput to to samo co rotacja w kodzie wyżej
 * 3. QuaternionEuler przyjmuje argument Vector3 i zwraca wartość rotacji w kątach Eulerowskich:
 *  Potrzebujemy wartości Quaternion zamiast wektora 3D żeby użyć metody MoveRotation. To po prostu konwersja do rotacji którą woli Unity.
 *  mnożymy przez Time.fixedDeltaTime z tego samego powodu co wcześniej.
 * 4. Wywołujemy MovePosition na naszym komponencie _rb, metodap rzyjmuje wektor 3D jako argument i nakłada siłę:
 *  użyty wektor może być rozbity na podczęści w ten sposób:
 *    pozycja Transform gracza w kierunku do przodu, mnożona przez wejście z klawiatury oraz Time.fixedDeltaTime
 *   komponent Rigidbody zajmuje się nakładaniem siły do wektora 3D z argumentu
 * 5. Wywołuje metodę MoveRotation na komponencie _rb, również przyjmuje Wektor 3D jako argument i nakłada siły:
 *  angleRot już ma wejście lewo/prawo z klawiatury, więc jedyne co trzeba zrobić to pomnożyć rotacje Rigidbody przezz angleRot żeby otrzymać tę samą rotację.
 */