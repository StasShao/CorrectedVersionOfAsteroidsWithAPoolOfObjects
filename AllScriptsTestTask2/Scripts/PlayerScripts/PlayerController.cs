using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 120f;
    public float Rotatespeed = 3f;
    public float curentMass;
    public float curentDrag;

    
    
    public float distance;
    public bool finishing;
    public bool inFinishZone;
    
    public GameObject gan;
    public GameObject spaceToKeel;
    public Transform plBones;
  
    public GameObject sword;
    public SpawnEnemy spawn;
    SpawnerChelnok chelnok;
    Camera _camera;
    Test test;
    public LayerMask mask;
    public Transform target;
    public Transform player;
    public Transform curentPos;
    
    
    public Transform chestPivot;
    public Transform pivot;
    public Vector3 offSet;
    public Vector3 rot;
    public Quaternion quaternion;
    
    
   Animator animator;
   public Animator animEnemy;
   Rigidbody _rb;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody>();
        test = GetComponent<Test>();
        _camera = Camera.main;
        curentMass = _rb.mass;
        curentDrag = _rb.drag;
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnEnemy>();
        chelnok = GameObject.FindGameObjectWithTag("Chelnok").GetComponent<SpawnerChelnok>();
        
    }

    void Update()
    {
        if(target)
        {
          target = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
        if(Input.GetMouseButton(1))
        {
          animator.SetBool("Targeting", true);
        }
        else
        {
          animator.SetBool("Targeting", false);
        }
        
      
    }
    void FixedUpdate()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, mask))
        {
           pivot.position = hit.point + offSet;
        }
        
         
        
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        distance =  Vector3.Distance(player.position, target.transform.position);

        _rb.AddForce(transform.forward * ver * speed);
        transform.Rotate(0,hor * Rotatespeed,0);
        animator.SetFloat("RunF", ver);
        if(inFinishZone == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
           {
            
             StartCoroutine(FinishingAnim());
           }
        }
        
       

     
        if(finishing == true)
        {
             _rb.AddForce(transform.forward * speed *2f);
             transform.LookAt(target.transform.position);
             animator.SetFloat("AimingY", 0);
             animator.SetFloat("Aiming", 0);
             animator.SetFloat("RunF", 1);
          if(distance <= 2f)
          {
           Vector3 pos = target.position - transform.position;
           Quaternion rotation = Quaternion.LookRotation(pos, Vector3.up);
           plBones.transform.rotation  = rotation;
            _rb.mass = 200;
            _rb.drag = 10f;
            animator.SetFloat("RunF", ver);
            StopCoroutine(FinishingAnim());
            StartCoroutine(FinishingAnim2());
          }
        }
       
    }
    void OnAnimatorIK()
    {
        animator.SetIKPosition(AvatarIKGoal.RightHand, pivot.position);
        animator.SetLookAtWeight(1);
    }
     IEnumerator FinishingAnim()
    {
        yield return new WaitForSeconds(0.1f);
        finishing = true;
        gan.SetActive(false);
        sword.SetActive(true);
        
        
        
       
    }
    IEnumerator FinishingAnim2()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider>().enabled = false;
        spaceToKeel.SetActive(false);
        inFinishZone = false;
        test.rot = new Vector3(0,0,0);
        test.enabled = false;
        animator.SetBool("Finishing", true);
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("Finishing", false);
        yield return new WaitForSeconds(0.3f);
        animEnemy.enabled = false;
        finishing = false;
        animator.SetBool("Finishing", false);
        yield return new WaitForSeconds(0.5f);
           Vector3 pos = curentPos.position - transform.position;
           Vector3 pos2 = transform.position - transform.position;
           Quaternion rotation = Quaternion.LookRotation(pos, Vector3.up);
           Quaternion rotationX = Quaternion.LookRotation(pos2, Vector3.right * 0);
           Quaternion rotationZ = Quaternion.LookRotation(pos2, Vector3.forward * 0);
           plBones.transform.rotation  = rotation;
           transform.rotation = rotationX;
           transform.rotation = rotationZ;
        gan.SetActive(true);
        sword.SetActive(false);
        test.enabled = true;
        _rb.drag = curentDrag;
        _rb.mass = curentMass;
        yield return new WaitForSeconds(5f);
         
        if(chelnok.spawn == false)
        {
          chelnok.spawn = true;
        }
        yield return new WaitForSeconds(0.1f);

        if(chelnok.spawn == true)
        {
          chelnok.spawn = false;
        }
        
        
    }
}
