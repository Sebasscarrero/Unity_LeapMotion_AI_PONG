using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStart_Controller : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuHumanovsIA;
    public GameObject menuIAvsIA;

    public Ball theBall;

    public PlayerIA playerIA;
    public PlayerIA_2 playerIA_2; //Humano

    public Text rulesHumanIA;
    public Text rulesIAIA;

    //Cameras to switch between them
    public GameObject Camera2D;
    public GameObject Camera3D;
    public bool isCamera2D;

    //Cambiar el color de la pared del personaje
    public GameObject myWall;
    public Material white;
    public Material transparente;

    private void Start()
    {
        playerIA = FindObjectOfType<PlayerIA>();
        playerIA_2 = FindObjectOfType<PlayerIA_2>();

        theBall = FindObjectOfType<Ball>();

        menuPrincipal.SetActive(true);
        menuHumanovsIA.SetActive(false);
        menuIAvsIA.SetActive(false);

        rulesHumanIA.gameObject.SetActive(false);
        rulesIAIA.gameObject.SetActive(false);

        Camera2D.SetActive(true);
        Camera3D.SetActive(false);
        isCamera2D = true;

    }

    private void Update()
    {
        //Function that allows change camera
        ChangeCamera();
    }

    //FUNCIÓN QUE ACTIVA EL MENÚ HUMANO VS IA
    public void ActivaMenuHumanovsIA()
    {
        menuHumanovsIA.SetActive(true);
        playerIA_2.GetComponent<PlayerIA_2>().enabled = false;
        playerIA_2.GetComponent<Player_Test>().enabled = true;
        theBall.isHumanvsIA = true;
    }

    //FUNCIÓN QUE ACTIVA EL MENÚ IA VS IA
    public void ActivaMenuIAvsIA()
    {
        menuIAvsIA.SetActive(true);
        playerIA_2.GetComponent<PlayerIA_2>().enabled = true;
        playerIA_2.GetComponent<Player_Test>().enabled = false;
        theBall.isHumanvsIA = false;
    }

    //FUNCIÓN QUE ACTIVA EL MENÚ PRINCIPAL
    public void BotonBack()
    {
        menuHumanovsIA.SetActive(false);
        menuIAvsIA.SetActive(false);

        //Resetea los valores de las heurísticas para no entrar en conflicto
        playerIA.isHeuristic1 = false;
        playerIA.isHeuristic2 = false;
        playerIA.isHeuristic3 = false;

        playerIA_2.isHeuristic1 = false;
        playerIA_2.isHeuristic2 = false;
        playerIA_2.isHeuristic3 = false;
    }


    //FUNCIONES QUE ACTIVAN LA HEURÍSTICA DE LA IA QUE EL USUARIO QUIERA
    public void SelectHeuristic1()
    {
        playerIA.isHeuristic1 = true;
        playerIA.isHeuristic2 = false;
        playerIA.isHeuristic3 = false;
    }
    public void SelectHeuristic2()
    {
        playerIA.isHeuristic2 = true;
        playerIA.isHeuristic1 = false;
        playerIA.isHeuristic3 = false;
    }
    public void SelectHeuristic3()
    {
        playerIA.isHeuristic3 = true;
        playerIA.isHeuristic2 = false;
        playerIA.isHeuristic1 = false;
    }

    //FUNCIONES QUE ACTIVAN LA HEURÍSTICA DE LA IA 2 QUE EL USUARIO QUIERA
    public void SelectHeuristic1_IA2()
    {
        playerIA_2.isHeuristic1 = true;
        playerIA_2.isHeuristic2 = false;
        playerIA_2.isHeuristic3 = false;
    }
    public void SelectHeuristic2_IA2()
    {
        playerIA_2.isHeuristic2 = true;
        playerIA_2.isHeuristic1 = false;
        playerIA_2.isHeuristic3 = false;
    }
    public void SelectHeuristic3_IA2()
    {
        playerIA_2.isHeuristic3 = true;
        playerIA_2.isHeuristic2 = false;
        playerIA_2.isHeuristic1 = false;
    }

    //FUNCION QUE INICIALIZA TODO TRAS HABER ESCOGIDO LAS CONFIGURACIONES DE LA IA
    public void StartGame()
    {
        theBall.StartMovingBall();

        menuPrincipal.SetActive(false);
        menuHumanovsIA.SetActive(false);
        menuIAvsIA.SetActive(false);
        theBall.startAll = true;
    }

    //FUNCIÓN QUE MUESTRA LAS INSTRUCCIONES AL PARARSE ENCIMA DEL BOTÓN CORRESPONDIENTE
    public void RulesHumanIA()
    {
        rulesHumanIA.gameObject.SetActive(true);
 
    }
    public void RulesIAIA()
    {
        rulesIAIA.gameObject.SetActive(true);
    }

    public void RulesHumanIAOut()
    {
        rulesHumanIA.gameObject.SetActive(false);

    }
    public void RulesIAIAOut()
    {
        rulesIAIA.gameObject.SetActive(false);
    }


    //Funcion que permite cambiar cámaras
    public void ChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCamera2D)
            {
                //3D
                Camera2D.SetActive(false);
                Camera3D.SetActive(true);

                myWall.GetComponent<MeshRenderer>().material = transparente;

                isCamera2D = false;
            }
            else
            {
                //2D
                Camera2D.SetActive(true);
                Camera3D.SetActive(false);

                myWall.GetComponent<MeshRenderer>().material = white;

                isCamera2D = true;
            }
        }
    }



}
