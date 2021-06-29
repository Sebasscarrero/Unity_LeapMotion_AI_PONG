using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    //Variables to control the ball movement
    public Vector3 direction;
    public float Initialspeed;
    public float speed;
    public float bounceAngle;
    public float vx, vz;

    //Variables to control the score
    [SerializeField]
    private int playerOneScore;
    [SerializeField]
    private int playerTwoScore;

    public Text playerScoreText;
    public Text IAScoreText;

    public bool isIAbounce = false;
    public bool isIAbounce_IA2 = false;

    public Vector3 spawnPoint;

    //Bool que inicializa todo
    public bool startAll;

    public Text winText;
    public int winPoints;

    public bool isHumanvsIA;

    //Sounds
    public AudioClip[] sounds;
    public AudioSource audioSource;

    private void Start()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        winText.gameObject.SetActive(false);
        startAll = false;



        /*
        bounceAngle = GetRandomBounce();
        vx = Mathf.Abs(speed * Mathf.Cos(bounceAngle) * 100);
        vz = Mathf.Abs(speed * -Mathf.Sin(bounceAngle) * 100);
        */

        /* if (startAll)
         {
             speed = Initialspeed;
             this.direction = new Vector3(1f, 0f, 1f);
         }
         */

        //this.direction = new Vector3(direction.x * vx * Time.deltaTime, 0, vz * Time.deltaTime);
    }

    public void StartMovingBall()
    {
        speed = Initialspeed;
        this.transform.position = new Vector3(0f, 0.75f, 0f);    
        this.direction = new Vector3(1f, 0f, 1f);
        isIAbounce_IA2 = false;
        isIAbounce = false;
    }




    private void Update()
    {
        if (startAll)
        {
            this.transform.position += direction * speed;

            //this.transform.position += new Vector3(direction.x * vx * Time.deltaTime, 0, vz * Time.deltaTime);

            //Function that update the scores
            UpdateScores();

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartMovingBall();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }

            //Check the speed of the ball and avoid to be faster and broke the game
            if (speed >= 1.20f)
            {
                speed = 1f;
            }

        }


    }

    private void OnCollisionEnter(Collision col)
    {
        //Control the ball bounce on objects
        //SetRandomBounce();
        Vector3 normal = col.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);

        if (col.gameObject.name == "Player")
        {
            IncreaseSpeedByBounce();
            isIAbounce = false;
            isIAbounce_IA2 = true;

            audioSource.PlayOneShot(sounds[0]);
        }
        else if (col.gameObject.name == "IA")
        {
            IncreaseSpeedByBounce();
            isIAbounce = true;
            isIAbounce_IA2 = false;

            audioSource.PlayOneShot(sounds[1]);
        }

        //Control the points
        else if (col.gameObject.name == "Wall_Right")
        {
            playerOneScore++;
            transform.position = spawnPoint;
            isIAbounce = true;
            isIAbounce_IA2 = false;
            speed = Initialspeed;
            audioSource.PlayOneShot(sounds[3]);
        }

        else if (col.gameObject.name == "Wall_Left")
        {
            playerTwoScore++;
            transform.position = spawnPoint;
            isIAbounce = false;
            isIAbounce_IA2 = true;
            speed = Initialspeed;
            audioSource.PlayOneShot(sounds[3]);
        }

        else
        {
            audioSource.PlayOneShot(sounds[2]);
        }

        /*
        else if (col.gameObject.name == "Wall_Up")
        {
            vz = Mathf.Abs(vz) * -1;
        }

        else if (col.gameObject.name == "Wall_Down")
        {
            vz = Mathf.Abs(vz);
        }

        else if (col.gameObject.name == "Player" || col.gameObject.name == "IA")
        {
            SetRandomBounce();
        }
        */
    }

    public void UpdateScores()
    {
        playerScoreText.text = playerOneScore.ToString();
        IAScoreText.text = playerTwoScore.ToString();

        if (isHumanvsIA)
        {
            if (playerOneScore >= winPoints)
            {
                startAll = false;
                winText.gameObject.SetActive(true);
                winText.text = "GANA  EL  HUMANO";
                isIAbounce_IA2 = false;
                isIAbounce = false;

                StartCoroutine(ResetAllAfterWinning());
            }
            else if (playerTwoScore >= winPoints)
            {
                startAll = false;
                winText.gameObject.SetActive(true);
                winText.text = "GANA  LA  IA";
                isIAbounce_IA2 = false;
                isIAbounce = false;

                StartCoroutine(ResetAllAfterWinning());
            }
        }

        else
        {
            if (playerOneScore >= winPoints)
            {
                startAll = false;
                winText.gameObject.SetActive(true);
                winText.text = "GANA  LA  IA  1";
                isIAbounce_IA2 = false;
                isIAbounce = false;

                StartCoroutine(ResetAllAfterWinning());
            }
            else if (playerTwoScore >= winPoints)
            {
                startAll = false;
                winText.gameObject.SetActive(true);
                winText.text = "GANA  LA  IA  2";
                isIAbounce_IA2 = false;
                isIAbounce = false;

                StartCoroutine(ResetAllAfterWinning());
            }
        }

    }


    public IEnumerator ResetAllAfterWinning()
    {
        audioSource.PlayOneShot(sounds[4]);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }



/*
    float GetRandomBounce(float minDegrees = 187.5f, float maxDegrees = 232.5f)
    {
        float minRad = minDegrees * Mathf.PI / 180;
        float maxRad = maxDegrees * Mathf.PI / 180;

        return Random.Range(minDegrees, maxDegrees);
    }

    public void SetRandomBounce()
    {
        bounceAngle = GetRandomBounce();
        vx = Mathf.Abs(speed * Mathf.Cos(bounceAngle) * 100);
        vz = Mathf.Abs(speed * -Mathf.Sin(bounceAngle) * 100);

        if (vx < 2)
        {
            Debug.Log("vx era menor a 2 entonces se cambió");
            vx += Random.Range(3, 6);
        }
    }
*/

    public void IncreaseSpeedByBounce()
    {
        speed += 0.03f;
    }

}
