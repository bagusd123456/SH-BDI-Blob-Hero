using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    public float mouseSpeed;
    public float moveSpeed;
    private void Update()
    {
        float X = Input.GetAxis("Mouse X") * mouseSpeed;
        transform.Rotate(0, X, 0);

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        transform.position += Vector3.forward * v * moveSpeed;
        transform.position += Vector3.right * h * moveSpeed;
    }
}
