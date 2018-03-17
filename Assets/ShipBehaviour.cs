using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour {

    public float Acceleration = 1.0f;
    public float Deaccelleration = 1.0f;
    public float MaxSpeed = 1.0f;
    public float RotationSpeed = 45.0f;
    public float AirResistance = 0.0f;

    private float speed;

	// Use this for initialization
	void Start () {
        speed = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
            speed += Acceleration * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            speed -= Deaccelleration * Time.deltaTime;

        speed = Mathf.Lerp(0.0f, speed, Mathf.Pow((1.0f - AirResistance), Time.deltaTime));

        if (speed > MaxSpeed) speed = MaxSpeed;
        if (speed < -MaxSpeed) speed = -MaxSpeed;

        this.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            this.transform.Rotate(0.0f, -RotationSpeed * speed / MaxSpeed * Time.deltaTime, 0.0f);
        if (Input.GetKey(KeyCode.RightArrow))
            this.transform.Rotate(0.0f, RotationSpeed * speed / MaxSpeed * Time.deltaTime, 0.0f);
    }
}
