using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;

    [SerializeField] float moveSpeed = 15f;

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = Move();
        transform.position += delta;
    }

    private Vector3 Move()
    {
        return rawInput * moveSpeed * Time.deltaTime;
    }

    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
