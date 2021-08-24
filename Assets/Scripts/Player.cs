using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player :  GameController
{

    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.8f;
    [SerializeField]
    private GameObject _muzzleflash;
    [SerializeField]
    private GameObject _hitmarkerPrefab;
    [SerializeField]
    private int currentammo;
    private int maxAmmo = 120;

    private bool _isreloading = false;

    private UI_Manager _uiManager;

    [SerializeField]
    private AudioSource _weaponAudio;

    
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        _controller = GetComponent<CharacterController>();
        //hide mouse cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        currentammo = maxAmmo;
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        // reloadText = GameObject.FindGameObjectWithTag("Reload");

       

    }

    // Update is called once per frame
    void Update()
    {
        //if left click
        //case ray from center point main camera

        if (Input.GetMouseButton(0) && currentammo > 0)
        {
             shoot();
        }
        else 
        {
            _muzzleflash.SetActive(false);
            _weaponAudio.Stop();
           


        }

        if (Input.GetKeyDown(KeyCode.R) && _isreloading == false)
        {
            _isreloading = true;
            StartCoroutine(Reload());
            
        }

        //if escape key pressed
        //unhide mouse cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        CalculateMovement();

        money();

    }
    void shoot()
    {
        _muzzleflash.SetActive(true);
        currentammo--;
        _uiManager.UpdateAmmo(currentammo);
        //if audio is not plyaing
        //play music

        if (_weaponAudio.isPlaying == false)
        {
            _weaponAudio.Play();
        }
        Ray rayorigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitinfo;

        if (Physics.Raycast(rayorigin, out hitinfo))
        {
            Debug.Log("hit" + hitinfo.transform.name);
            GameObject hitmarker = (GameObject)Instantiate(_hitmarkerPrefab, hitinfo.point, Quaternion.LookRotation(hitinfo.normal));
            Destroy(hitmarker, 1f);
            
        }
        //check if we hit the crate
        CharacterStats Zombie = hitinfo.transform.GetComponent<CharacterStats>();
        

        if (Zombie != null)
        {
           Zombie.destroyZombie();
           scoreInc();           
        }
       

    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.2f);
        currentammo = maxAmmo;
        _uiManager.UpdateAmmo(currentammo);
        _isreloading = false;
      
    }

   
}