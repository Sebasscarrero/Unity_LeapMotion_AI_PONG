using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIA : MonoBehaviour
{

    public float speed;

    public GameObject ball;
    public Vector3 ballPos;

    private float topBound = 10.30f;
    private float bottomBound = -10.40f;

    public Ball ballController;

    private Vector3 initialIAPosition;

    private Vector3 ballZPos;

    public Rigidbody rb;

    //Booleanos que actian la heurística que escoja el usuario
    public bool isHeuristic1;
    public bool isHeuristic2;
    public bool isHeuristic3;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialIAPosition = new Vector3(24.5f, 0.75f, 0);

        //Inicializa booleanos de heurísticas en falso
        isHeuristic1 = false;
        isHeuristic2 = false;
        isHeuristic3 = false;
    }

    private void Update()
    {
        ballZPos = new Vector3(24.5f, 0.75f, ballPos.z);

        Move();
    }

  

    void Move()
    {
        if (!ball)
        {
            ball = GameObject.FindGameObjectWithTag("ball");
        }
           

        if (ball && ballController.isIAbounce == false)
        {

            ballPos = ball.transform.localPosition;
          
            //Movimiento de la IA hacia ABAJO

            if (transform.localPosition.z > bottomBound && ballPos.z < transform.localPosition.z)


            {

                if (isHeuristic1)
                {
                    //Heurística 1a: Desplazarse progresivamente hacia ABAJO hasta la pelota e intentar respoderla

                    transform.localPosition += new Vector3(0, 0, (-speed * Time.deltaTime));
                }


                else if (isHeuristic3)
                {
                    //Heurística 2a: Desplazarse inmediatamente hacia la posición de la pelota y seguir su trayectoria hasta que se pueda responder la pelota

                    transform.localPosition = Vector3.Lerp(transform.localPosition, ballZPos, (speed));
                }


                else if (isHeuristic2)
                {
                    //Heurística 3a: Añadir un impulso hacia ABAJO que permita a la IA acercarse a la pelota e intentar responder la pelota

                    rb.AddForce(new Vector3(0, 0, -1) * speed);
                }
            }

            //Movimiento de la IA hacia ARRIBA

            else if (transform.localPosition.z < topBound && ballPos.z > transform.localPosition.z)


            {
                if (isHeuristic1)
                {
                    //Heurística 1b: Desplazarse progresivamente hacia ARRIBA hasta la pelota e intentar respoderla
                    transform.localPosition += new Vector3(0, 0, (speed * Time.deltaTime));
                }


                else if (isHeuristic3)
                {
                    //Heurística 2a: Desplazarse inmediatamente hacia la posición de la pelota y seguir su trayectoria hasta que se pueda responder la pelota
                    transform.localPosition = Vector3.Lerp(transform.localPosition, ballZPos, (speed));
                }


                else if (isHeuristic2)
                {
                    //Heurística 3a: Añadir un impulso hacia ARRIBA que permita a la IA acercarse a la pelota e intentar responder la pelota
                    rb.AddForce(new Vector3(0, 0, 1) * speed);
                }
            }
        }

        else if (ball && ballController.isIAbounce == true)
            {
           
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialIAPosition, (Time.deltaTime));
            //rb.AddForce(new Vector3(0, 0, 0) * speed);
        }
    }









}
