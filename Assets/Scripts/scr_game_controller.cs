using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scr_game_controller : MonoBehaviour
{
    public int gamestate;

    private int counter;
    private int activatetime;
    private float timer;

    public GameObject obstacle;
    public GameObject particles;

    public Text TimerText;
    public Text InstructionText;
    public Text GameOverText;

    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip music4;
    public AudioSource musicSource;

    void Start()
    {
        Application.targetFrameRate = 60;

        counter = 0;
        activatetime = 60;
        gamestate = 0;

        TimerText.text = "";
        GameOverText.text = "";
        InstructionText.text = "";

        musicSource.clip = music1;
        musicSource.Play();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        //Game Start State
        if (gamestate == 0)
        {
            InstructionText.text = "A / LeftArrow is left, D / RightArrow is right. \n Survive for 10 seconds. \n Avoid the collapse.";

            if ((Input.GetKey(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
            {
                counter = activatetime;
                timer = 0;
                Instantiate(particles);
                gamestate = 1;
            }
        }

        //Gameplay State
        if (gamestate == 1)
        {
            if (musicSource.clip != music2) { 
            musicSource.Stop();
            musicSource.clip = music2;
            musicSource.Play();
            }

            InstructionText.text = "";
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60f);
            int milliseconds = (Mathf.FloorToInt(timer * 1000)) % 1000;
            string displayTime = string.Format("{0:0}:{1:000}", seconds, milliseconds);
            TimerText.text = "Timer: " + displayTime;

            counter++;
            if ((counter >= activatetime) && (timer  < 8.5))
            {
                Instantiate(obstacle);
                counter = 0;
            }

            if (timer >= 10)
            {
                TimerText.text = "";
                gamestate = 2;
            }
        }

        //Win State
        if (gamestate == 2)
        {
            if (musicSource.clip != music3) { 
            musicSource.Stop();
            musicSource.clip = music3;
            musicSource.Play();
            }

            GameOverText.text = "Congratulations. \n You survived the collapse. \n Press ESC to close or R to play again.";

            if (Input.GetKey("r"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        //Lose State
        if (gamestate == 3)
        {

            if (musicSource.clip != music4)
            {
                musicSource.Stop();
                musicSource.clip = music4;
                musicSource.Play();
            }

            GameOverText.text = "You have fallen. \n Press R to restart";

            if (Input.GetKey("r"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }


    }
}
