using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public DragMe dragme;
    public GameObject touchpos;
    public Rigidbody rb;
    public AudioSource audio;
    public float tilt;
    void Start()
    {
        dragme = GetComponent<DragMe>();
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        CalibrateAccelerometer();
    }
    public GameObject shot;
    public Transform shotspawn;
    public float fireRate;
    private float nextFire;
    public Vector3 wantedPos;
    public GameObject SpeedPack;
    private GameObject InstSpeedPack;
    private bool SpeedPackCheck;
    public float speed;
    private Quaternion calibrationQuaternion;
    
    
    void Update()
    {
        if(dragme.checkFire() &&Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotspawn.position, shotspawn.rotation);
            audio.Play();
        }
    }
    public float depth;

    void FixedUpdate ()
    {
        // Vector2 mousePos = Input.mousePosition;

        //wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depth));

        //transform.position = wantedPos;
        /*   float moveHorizontal = Input.GetAxis("Horizontal");
           float moveVertical = Input.GetAxis("Vertical");
          Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        */

        // Vector3 accelerationRaw = Input.acceleration;
        //   Vector3 acceleration = FixAcceleration(accelerationRaw);
        //   Vector3 movement = new Vector3(acceleration.x,0.0f,acceleration.y);

        /*   Vector2 direction = touchPad.GetDirection();
        */


        /* rb.velocity = movement*speed;
              rb.position = new Vector3
              (
                  Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
                  0.0f,
                  Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
               );
        */
      //  rb.position = dragme.getPosition();
     //   rb.rotation = Quaternion.Euler(0.0f, 0.0f, touchpos.transform.position.x* -tilt);
             
    } 
    public void IncreaseFireRate()
    {
        if (SpeedPackCheck == false)
        {
            
            StartCoroutine(WaitForIt());
            
        }
    }
    
    IEnumerator WaitForIt()
    {
        SpeedPackCheck = true;
        fireRate = 0.05f;
        InstSpeedPack = (GameObject)Instantiate(SpeedPack, transform.position, transform.rotation);
        yield return new WaitForSeconds(4);
        Destroy(InstSpeedPack);
        fireRate = 0.25f;
        SpeedPackCheck = false;
    }

    void CalibrateAccelerometer()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    Vector3 FixAcceleration (Vector3 acceleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
        return fixedAcceleration;
    }
}
