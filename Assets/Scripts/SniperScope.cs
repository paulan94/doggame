using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SniperScope : MonoBehaviour
{
    public CinemachineVirtualCamera playerCam;
    public CinemachineVirtualCamera bulletCam;
    public GameObject sniperScope;
    public GameObject hipFireCrosshair;
    public GameObject sniperGun;
    public CinemachineBrain mainBrain;

    public int fov = 15;
    public int fovDefault = 60;
    public bool isScoped = false;

    public GameObject bulletPrefab;
    public float shootSpeed = 5f;

    private float fixedDeltaTime;
    public bool canShoot = true;

    public SniperGameManager sniperGameManager;

    private void Awake() {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Start() {
        Debug.Log("starting game now");
        sniperGameManager.gameStart = true;
        Debug.Log("starting scoring coroutine");
        sniperGameManager.StartScoringCoroutine();
        //start game here show timer
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canShoot){
            playerCam.m_Lens.FieldOfView = fov;
            sniperScope.SetActive(true);
            hipFireCrosshair.SetActive(false);
            sniperGun.SetActive(false);
        }

        if (Input.GetMouseButtonUp(1) && canShoot){
            playerCam.m_Lens.FieldOfView = fovDefault;
            sniperScope.SetActive(false);
            hipFireCrosshair.SetActive(true);
            sniperGun.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            Debug.Log("player rotation: " + transform.rotation);
            shootBullet();
        }
    }

    void shootBullet()
    {
        // Instantiate a new bullet at the players position and rotation
        // later you might want to add an offset here or 
        // use a dedicated spawn transform under the player
        mainBrain.m_DefaultBlend.m_Time = 0;
        sniperScope.SetActive(false);
        if (Time.timeScale == 1.0f){
            Time.timeScale = 0.1f;
        }
        else{
            Time.timeScale = 1.0f;
        }
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        
        // Quaternion bulletRotation = Quaternion.Euler(transform.rotation.x - 90f, transform.rotation.y, transform.rotation.z);
        Vector3 temp = transform.rotation.eulerAngles;
        temp.x -= 90f;
        var projectile = Instantiate (bulletPrefab, playerCam.transform.position, Quaternion.Euler(temp));
        bulletCam.Priority = 100;

        Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();
        MouseLook mouseLook = GetComponent<MouseLook>();
        mouseLook.enabled = !mouseLook.enabled; //enable if i want to use again later
        //Shoot the Bullet in the forward direction of the player
        rigidbody.velocity = playerCam.transform.forward * shootSpeed;

        Vector3 bulletCamTransform = projectile.transform.position;
        bulletCamTransform.z -= 100;
        bulletCam.transform.position = bulletCamTransform;
        bulletCam.LookAt = projectile.gameObject.transform;
        bulletCam.Follow = projectile.gameObject.transform;
        //maybe reset prior if missed? 
        canShoot = false;
        Cursor.lockState = CursorLockMode.None;

    }
}
