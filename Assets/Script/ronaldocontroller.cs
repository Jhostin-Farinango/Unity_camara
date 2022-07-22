using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ronaldocontroller : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;
    private Animator animator;
    //Rigidbody rb;

    //bool isJump = false;
    //public float jumpForce = 5.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");

        float desplazamiento = translation * speed * Time.deltaTime;
        float rotacion = rotation * rotationSpeed * Time.deltaTime;

        //Detener al personaje
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
        Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("caminar", false);
            animator.SetBool("saltar", false);
            animator.SetBool("atras", false);
        }

        //correr hacia adelante y atras
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("caminar", true);
            transform.Translate(0, 0, desplazamiento);
        }else if (Input.GetKey(KeyCode.DownArrow)) 
        {
            //
            animator.SetBool("atras", true);
            transform.Translate( 0, 0, desplazamiento );
        }

        //Girar a la izquierda o a la derecha
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("caminar", true);
            transform.Rotate(0, rotacion, 0);
        }

        //saltar
        //isJump = Input.GetButtonDown("Jump");

        if (Input.GetKey(KeyCode.Space))
        {            
            animator.SetBool("saltar", true);
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 20, 0));
        }

    }
}
