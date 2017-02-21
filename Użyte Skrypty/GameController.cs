using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public bool hp;
    private GameObject clone;
    public GameObject HPaura;

    public GUIText scoreText;
    private int score;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText bossText;
    public GUIText waveText;
    public GUIText bosshp;
    public GameObject restartButton;

    private bool gameOver;
    private bool bossOver;
    private bool restart;
    public bool TimeCheck;
    private int waves;
    public BGscroller bgscroller;
    public BossFight bossFight;
    public GameObject boss;
    GameObject hazard;
    public DragMe dragme;

    void Start()
    {
        restartButton.SetActive(false);
        bosshp.text = "";
        waves = 1;
        UpdateWaves();
        bossText.text = "";
        
        TimeCheck = false;
        hp = false;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        Updatescore();
        StartCoroutine (SpawnWaves());
    }

    void Update()
    {
      //  if(restart)
     //   {
     //       if(Input.GetKeyDown (KeyCode.R))
     //       {
      //          Application.LoadLevel(Application.loadedLevel);
      //      }
    //    }
        if (TimeCheck && dragme.checkFire())
        {
            
                Time.timeScale = 0.2F;
            
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
        if (TimeCheck==false && dragme.checkFire())
        {
           
                Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
        if (gameOver || bossOver )
        {
            //restartText.text = "Press 'R' for Restart";
            restartButton.SetActive(true);
            restart = true;
            
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (waves<10)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                if (waves == 1)
                {
                    hazard = hazards[Random.Range(0, 5)];
                }
                if (waves>=2 && waves<=5)
                {
                    hazard = hazards[Random.Range(0, 11)];
                }
                if (waves >5 && waves <= 7)
                {
                    hazard = hazards[Random.Range(0, 13)];
                }
                if (waves>7 )
                {
                    hazard = hazards[Random.Range(0, 20)];
                }
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            waves++;
            UpdateWaves();
        }
        bossText.text = "Boss Incoming";
        bgscroller.scrollSpeed = -200;
        yield return new WaitForSeconds(3);
        bossText.text = "";
        bgscroller.scrollSpeed = -0.35f;
        Instantiate(boss, boss.transform.position, boss.transform.rotation);
        
    }

    public void Addscore(int newScoreValue)
    {
        score += newScoreValue;
        Updatescore();
    }
    void Updatescore()
    {
        scoreText.text = "Score: " + score;
    }
    void UpdateWaves()
    {
        waveText.text = "Wave: " + waves;
    }

    public void GameOver()
    {
            gameOverText.text = "Game Over";
            gameOver = true;
         
    }
    public void BossOver()
    {
        gameOverText.text = "You did it!";
        bossOver = true;

    }
    public void HigherHP()
    {
        if (hp == false)
        {
            hp = true;
            clone = (GameObject)Instantiate(HPaura, transform.position, transform.rotation);
        }
    }
    public void LowerHP()
    {
        hp = false;
        Destroy(clone);
    }
    public void SlowMotion()
    {
        if(TimeCheck==false)
        StartCoroutine(SlowMo());
    }
    IEnumerator SlowMo()
    {
        TimeCheck = true;
        
        yield return new WaitForSecondsRealtime(3);
        TimeCheck = false;
        
        yield return new WaitForSecondsRealtime(1);
        
    }
    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    
}
