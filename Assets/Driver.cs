using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    
    [SerializeField] private float steerSpeed = 100.0f;
    [SerializeField] private float offRoadSpeed = 5.0f;
    [SerializeField] private float onRoadSpeed = 10.0f;
    [SerializeField] private float moveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0,moveAmount, 0);
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Road")) moveSpeed = onRoadSpeed;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Road")) moveSpeed = offRoadSpeed;
    }
}
