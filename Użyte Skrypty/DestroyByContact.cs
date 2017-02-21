using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerexplosion;
    public int scorevalue;
    private GameController gameController;
    private PlayerController playerController;
    public int healthpoints;
    

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController==null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<PlayerController>();
        }
        if (playerController == null)
        {
            Debug.Log("Cannot find 'PlayerController' script");
        }

    }

	void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "TimePack")
        {
            if (other.CompareTag("Player"))
            {
                gameController.SlowMotion();
                Destroy(gameObject);
                return;
            }
            else
            {
                return;
            }
        }
        if (gameObject.tag == "SpeedPack")
        {
            if(other.CompareTag("Player"))
            {
                playerController.IncreaseFireRate();
                Destroy(gameObject);
                return;
            }
            else
            {
                return;
            }
        }
        if(other.CompareTag("Boundary") || other.CompareTag("Enemy")|| other.CompareTag("Boss") || other.CompareTag("PowerUp") || other.CompareTag("SpeedPack") || other.CompareTag("TimePack"))
        {
            return;
        }
        if(gameObject.tag == "PowerUp" && other.CompareTag("PlayerBolt"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        
        if (other.CompareTag ("Player"))
        {
            if (gameObject.tag == "PowerUp")
            {
                gameController.HigherHP();
                Destroy(gameObject);
                return;
            }
            else
            {
                if (gameController.hp == false)
                {
                    if (playerexplosion != null)
                    {
                        Instantiate(playerexplosion, transform.position, transform.rotation);
                    }
                    gameController.GameOver();
                    Destroy(other.gameObject);
                }
                else
                {
                    if (playerexplosion != null)
                    {
                        Instantiate(playerexplosion, transform.position, transform.rotation);
                    }
                    gameController.LowerHP();
                    if(gameObject.tag != "Boss")
                    Destroy(gameObject);
                }
            }
            
        }
        
        if(other.tag != "Player")
        Destroy(other.gameObject);
        if (healthpoints <= 1)
        {
            Destroy(gameObject);
            gameController.Addscore(scorevalue);
            if(gameObject.tag == "Boss")
            {
                gameController.BossOver();
            }
        }
        else
            healthpoints--;

    }
	
	
}
