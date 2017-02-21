using UnityEngine;
using System.Collections;

public class BossFight : MonoBehaviour {

    
    public Transform shotSpawn;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
    public Transform shotSpawn4;
    public Transform shotSpawn5;
    public Transform sawSpawn;
    public Transform sawSpawn2;
    public Transform sawSpawn3;
    public Transform sawSpawn4;
    public Transform sawSpawn5;
    public GameObject saw1;
    public GameObject saw2;
    public Transform laserspawn;
    public GameObject particle;
    public GameObject rocket;
    public GameObject rocketExplosion;
    public float tumble;
    public GameObject warningaura;
    public GameObject warningaura2;
    public GameObject laserbeam;
    private int myhp;
    private DestroyByContact destroybycontact;
   

    private GameObject rocket1;
    private GameObject rocket2;
    private GameObject rocket3;
    private GameObject rocket4;
    private GameObject rocket5;
    private bool allowRotate;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        
        destroybycontact = GetComponent<DestroyByContact>();
        allowRotate = false;
        StartCoroutine(FireRockets());
        Instantiate(particle, transform.position, transform.rotation);
        
    }
    void Update()
    {
        if(allowRotate)
        {
            transform.Rotate(0, 0, Time.deltaTime*tumble, Space.World);
        }
        myhp = destroybycontact.healthpoints;
        UpdateHP();
    }

   
	
	
	
    IEnumerator FireRockets()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(1);
            rocket1 = (GameObject)Instantiate(rocket, shotSpawn.position, shotSpawn.rotation);
            yield return new WaitForSeconds(2);
            Instantiate(rocketExplosion, rocket1.transform.position, rocket1.transform.rotation);
            Destroy(rocket1);
            rocket2 = (GameObject)Instantiate(rocket, shotSpawn2.position, shotSpawn2.rotation);
            yield return new WaitForSeconds(2.5f);
            Instantiate(rocketExplosion, rocket2.transform.position, rocket2.transform.rotation);
            Destroy(rocket2);
            rocket3 = (GameObject)Instantiate(rocket, shotSpawn3.position, shotSpawn3.rotation);
            yield return new WaitForSeconds(3);
            Instantiate(rocketExplosion, rocket3.transform.position, rocket3.transform.rotation);
            Destroy(rocket3);
            rocket4 = (GameObject)Instantiate(rocket, shotSpawn4.position, shotSpawn4.rotation);
            yield return new WaitForSeconds(2.5f);
            Instantiate(rocketExplosion, rocket4.transform.position, rocket4.transform.rotation);
            Destroy(rocket4);
            rocket5 = (GameObject)Instantiate(rocket, shotSpawn5.position, shotSpawn5.rotation);
            yield return new WaitForSeconds(2);
            Instantiate(rocketExplosion, rocket5.transform.position, rocket5.transform.rotation);
            Destroy(rocket5);
            yield return new WaitForSeconds(3);

            allowRotate = true;
            yield return new WaitForSeconds(2);
            allowRotate = false;
            transform.rotation = Quaternion.identity;



            InvokeRepeating("RocketSpamFunction", 1, 1);
            yield return new WaitForSeconds(10);



            CancelInvoke("RocketSpamFunction");



            allowRotate = true;
            yield return new WaitForSeconds(2);
            allowRotate = false;
            transform.rotation = Quaternion.identity;

            Instantiate(warningaura, laserspawn.position, laserspawn.rotation);
            yield return new WaitForSeconds(2);


            InvokeRepeating("RocketSpamFunction", 1, 1);
            Instantiate(laserbeam, laserspawn.position, laserspawn.rotation);
            yield return new WaitForSeconds(10);
            CancelInvoke("RocketSpamFunction");



            allowRotate = true;
            yield return new WaitForSeconds(2);
            allowRotate = false;
            transform.rotation = Quaternion.identity;

            Instantiate(warningaura2, sawSpawn.position, sawSpawn.rotation);
            Instantiate(warningaura2, sawSpawn2.position, sawSpawn2.rotation);
            Instantiate(warningaura2, sawSpawn3.position, sawSpawn3.rotation);
            Instantiate(warningaura2, sawSpawn4.position, sawSpawn4.rotation);
            Instantiate(warningaura2, sawSpawn5.position, sawSpawn5.rotation);


            yield return new WaitForSeconds(2);

            Instantiate(saw1, sawSpawn.position, sawSpawn.rotation);
            Instantiate(saw1, sawSpawn2.position, sawSpawn2.rotation);
            Instantiate(saw1, sawSpawn3.position, sawSpawn3.rotation);
            Instantiate(saw2, sawSpawn4.position, sawSpawn4.rotation);
            Instantiate(saw2, sawSpawn5.position, sawSpawn5.rotation);

            yield return new WaitForSeconds(5);

            allowRotate = true;
            yield return new WaitForSeconds(2);
            allowRotate = false;
            transform.rotation = Quaternion.identity;


        }

    }

    void RocketSpamFunction()
    {
        Instantiate(rocket, shotSpawn.position, shotSpawn.rotation);

        Instantiate(rocket, shotSpawn2.position, shotSpawn2.rotation);

        Instantiate(rocket, shotSpawn3.position, shotSpawn3.rotation);

        Instantiate(rocket, shotSpawn4.position, shotSpawn4.rotation);

        Instantiate(rocket, shotSpawn5.position, shotSpawn5.rotation);
    }
    void UpdateHP()
    {
        if (myhp <= 200)
            gameController.bosshp.text = "||||||||||||||||||||";
        if (myhp < 190)
            gameController.bosshp.text = "|||||||||||||||||||";
        if (myhp < 180)
            gameController.bosshp.text = "||||||||||||||||||";
        if (myhp < 170)
            gameController.bosshp.text = "|||||||||||||||||";
        if (myhp < 160)
        {
            gameController.bosshp.material.color = new Color(227,164,0,255);
            gameController.bosshp.text = "||||||||||||||||";
        }
        if (myhp < 150)
            gameController.bosshp.text = "|||||||||||||||";
        if (myhp < 140)
            gameController.bosshp.text = "||||||||||||||";
        if (myhp < 130)
            gameController.bosshp.text = "|||||||||||||";
        if (myhp < 120)
            gameController.bosshp.text = "||||||||||||";
        if (myhp < 110)
            gameController.bosshp.text = "|||||||||||";
        if (myhp < 100)
            gameController.bosshp.text = "||||||||||";
        if (myhp < 90)
            gameController.bosshp.text = "|||||||||";
        if (myhp < 80)
            gameController.bosshp.text = "||||||||";
        if (myhp < 70)
            gameController.bosshp.text = "|||||||";
        if (myhp < 60)
        {
            gameController.bosshp.material.color = new Color(255,69,0,255);
            gameController.bosshp.text = "||||||";
        }
        if (myhp < 50)
            gameController.bosshp.text = "|||||";
        if (myhp < 40)
            gameController.bosshp.text = "||||";
        if (myhp < 30)
            gameController.bosshp.text = "|||";
        if (myhp < 20)
            gameController.bosshp.text = "||";
        if (myhp < 10)
            gameController.bosshp.text = "|";
        if (myhp  <= 1)
            gameController.bosshp.text = "";
    }
}
