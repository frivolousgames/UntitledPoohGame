using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoohPlatformController : MonoBehaviour
{
    public Animator anim;
    BoxCollider2D groundCollider;
    Rigidbody2D rb;

    public LayerMask groundLayer;

    bool isGrounded;
    bool isRunning;
    bool isShooting;
    bool isHit;
    

    public float jumpForce;
    public float movement;
    public float runForce;

    float direction = 1;

    Camera mainCam;
    Transform mainCanvas;

    //Shoot
    public Transform bulletSpawn;
    public Transform snipeSpawn;
    bool shootReady;

    float shootWait;
    float shotReset;
    Animator shootBodyAnim;
    AnimatorClipInfo[] clipInfo;

    public GameObject exclaim;

    //Animation
    public GameObject idleBody;
    public GameObject shootBody;
    public GameObject runBody;
    public GameObject snipeBody;
    public GameObject reload;
    public GameObject idleLegs;
    public GameObject runLegs;
    public GameObject jumpLegs;

    //HIT & RELOAD
    public GameObject bodies;
    public GameObject screenBlocker;
    public GameObject physCol;

    public static BoxCollider2D poohCol;

    //VINES
    public static Transform vine;
    public static bool isVineHanging;

    //SHADOW
    public GameObject shadow;
    float vForce;
    public float vForceOffset;

    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        shotReset = .15f;
        poohCol = physCol.GetComponent<BoxCollider2D>();

    }

    private void Start()
    {
        shootBodyAnim = shootBody.GetComponent<Animator>();
        clipInfo = shootBodyAnim.GetCurrentAnimatorClipInfo(0);
        shootWait = clipInfo[0].clip.length;
        shootBody.SetActive(false);
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas").transform;
    }

    private void Update()
    {
        anim.SetBool("isHit", isHit);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isVineHanging", isVineHanging);

        SetBody();
        //Sniping();

        //if (!idleBody.activeInHierarchy && !shootBody.activeInHierarchy && !runBody.activeInHierarchy)
        //{
        //    Debug.Log("NO BODY");
        //}
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.IsTouchingLayers(groundCollider, groundLayer);
        Movement();

        
        //Debug.Log("Force: " + vForce);
        //Direction(direction);
        //Debug.Log("Grounded: " + isGrounded);
    }

    public void Jump()
    {
        if(TouchController.isTouching != true)
        {
            if (isGrounded == true)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                //Debug.Log("Jump");
            }
            if(isVineHanging == true)
            {
                isVineHanging = false;
                bodies.SetActive(true);
                shadow.SetActive(true);
                rb.isKinematic = false;
                vForce = GetComponentInParent<Rigidbody2D>().rotation;
                float force = vForce * vForceOffset;
                transform.parent = null;
                transform.localRotation = Quaternion.identity;
                rb.AddForce(new Vector2(force, jumpForce * vForceOffset), ForceMode2D.Impulse);
                //rb.velocity =new Vector2(rb.velocity.x * force, rb.velocity.y);

            }
        }
    }

    void Sniping()
    {
        if(TouchController.isTouching == true)
        {
            if (!screenBlocker.activeInHierarchy)
            {
                screenBlocker.SetActive(true);
            }
        }
        else
        {
            screenBlocker.SetActive(false);
        }
    }

    void Movement()
    {
        if (TouchController.isTouching != true)
        {
            if (isGrounded == true && isHit != true)
            {
                movement = Input.acceleration.x;
                if (movement > 0.06f)
                {
                    rb.velocity = new Vector2(runForce, rb.velocity.y);
                    isRunning = true;
                    transform.localScale = new Vector2(1, transform.localScale.y);
                    direction = 1;
                }
                else if (movement < -0.06)
                {
                    rb.velocity = new Vector2(-runForce, rb.velocity.y);
                    isRunning = true;
                    transform.localScale = new Vector2(-1, transform.localScale.y);
                    direction = -1;
                }
                else
                {
                    isRunning = false;
                }
            }
        }
    }

    public void Shoot()
    {
        isShooting = true;
        if (shootReady == false)
        {
            shootReady = true;
            shootBodyAnim.Play("ShootBody", 0, 0f);
            GameObject bullet = BulletPooler.instance.GetPooledObject();
            if (bullet != null)
            {
                
                if (snipeBody.activeInHierarchy)
                {
                    bullet.transform.position = snipeSpawn.position;
                    bullet.transform.rotation = snipeSpawn.rotation;
                }
                else
                {
                    bullet.transform.position = bulletSpawn.position;
                    bullet.transform.rotation = Quaternion.identity;
                }

                bullet.transform.localScale = transform.localScale;
                bullet.SetActive(true);
                
                Debug.Log("BULLET");
            }
            GameObject flame = FlamePooler.instance.GetPooledObject();
            if (flame != null)
            {
                if (snipeBody.activeInHierarchy)
                {
                    flame.transform.position = snipeSpawn.position;
                    flame.transform.rotation = snipeSpawn.rotation;
                }
                else
                {
                    flame.transform.position = bulletSpawn.position;
                    flame.transform.rotation = Quaternion.identity;
                }
                flame.transform.localScale = transform.localScale;
                flame.SetActive(true);
                Debug.Log("FLAME");
            }

            //Instantiate(smoke, bulletSpawn.position, Quaternion.identity, null);
            StopCoroutine("ShootingEnd");
            StartCoroutine("ShootWait");
        }
    }

    public void Shooting()
    {
        isShooting = true;
        StopCoroutine("ShootingEnd");
        StartCoroutine("ShootTime");
    }

    IEnumerator ShootTime()
    {
        while(isShooting == true && isHit == false && isVineHanging == false)
        {
            if (shootReady == false)
            {
                shootReady = true;
                if (shootBody.activeInHierarchy)
                {
                    shootBodyAnim.Play("ShootBody", 0, 0f);
                } 
                GameObject bullet = BulletPooler.instance.GetPooledObject();
                if (bullet != null)
                {
                    if (snipeBody.activeInHierarchy)
                    {
                        bullet.transform.position = snipeSpawn.position;
                        bullet.transform.rotation = snipeSpawn.rotation;
                    }
                    else
                    {
                        bullet.transform.position = bulletSpawn.position;
                        bullet.transform.rotation = Quaternion.identity;
                    }

                    bullet.transform.localScale = transform.localScale;
                    bullet.SetActive(true);
                    //Debug.Log("BULLET");
                }
                GameObject flame = FlamePooler.instance.GetPooledObject();
                if (flame != null)
                {
                    if (snipeBody.activeInHierarchy)
                    {
                        flame.transform.position = snipeSpawn.position;
                        flame.transform.rotation = snipeSpawn.rotation;
                    }
                    else
                    {
                        flame.transform.position = bulletSpawn.position;
                        flame.transform.rotation = Quaternion.identity;
                    }
                    flame.transform.localScale = transform.localScale;
                    flame.SetActive(true);
                    //Debug.Log("FLAME");
                }
                //GameObject exFab = Instantiate(exclaim, new Vector2(mainCam.WorldToViewportPoint(bullet.transform.localPosition).x + Random.Range(-.2f, .2f), mainCam.WorldToViewportPoint(bullet.transform.localPosition).y + Random.Range(.2f, .4f)), Quaternion.identity, mainCanvas);
                Instantiate(exclaim, new Vector3(bullet.transform.localPosition.x + Random.Range(-.7f, -.2f), bullet.transform.position.y + Random.Range(1.6f, 2.2f), mainCanvas.transform.localPosition.z), Quaternion.identity, mainCanvas);

                //Debug.Log(exFab.transform.position);
                yield return new WaitForSeconds(shotReset);
                shootReady = false;
                
                yield return null;
            }
        }
 
    }

    public void EndShooting()
    {
        shootReady = false;
        StopCoroutine("ShootTime");
        StartCoroutine("ShootingEnd");
    }

    IEnumerator ShootWait()
    {
        yield return new WaitForSeconds(shotReset);
        shootReady = false;
        StartCoroutine("ShootingEnd");
    }
    IEnumerator ShootingEnd()
    {
        yield return new WaitForSeconds(shootWait + shotReset + .01f);
        isShooting = false;
    }

    //Animation

    void SetBody()
    {
        if (isGrounded == false)
        {
            if (!jumpLegs.activeInHierarchy)
            {
                jumpLegs.SetActive(true);
            }
            if (idleLegs.activeInHierarchy)
            {
                idleLegs.SetActive(false);
            }
            if (runLegs.activeInHierarchy)
            {
                runLegs.SetActive(false);
            }
            if (snipeBody.activeInHierarchy)
            {
                snipeBody.SetActive(false);
            }
            if (isShooting == true)
            {
                ShootBody();
            }
            else
            {
                if (!idleBody.activeInHierarchy)
                {
                    idleBody.SetActive(true);
                }
                if (shootBody.activeInHierarchy)
                {
                    shootBody.SetActive(false);
                }
                if (runBody.activeInHierarchy)
                {
                    runBody.SetActive(false);
                }
                if (snipeBody.activeInHierarchy)
                {
                    snipeBody.SetActive(false);
                }
            }
        }
        else
        {
            if (jumpLegs.activeInHierarchy)
            {
                jumpLegs.SetActive(false);
            }

            if(TouchController.isTouching == true)
            {
                if (idleBody.activeInHierarchy)
                {
                    idleBody.SetActive(false);
                }
                if (shootBody.activeInHierarchy)
                {
                    shootBody.SetActive(false);
                }
                if (runBody.activeInHierarchy)
                {
                    runBody.SetActive(false);
                }
                if (!snipeBody.activeInHierarchy)
                {
                    snipeBody.SetActive(true);
                }
                if (runLegs.activeInHierarchy)
                {
                    runLegs.SetActive(false);
                }
                if (!idleLegs.activeInHierarchy)
                {
                    idleLegs.SetActive(true);
                }
            }

            else
            {
                if (isShooting == true)
                {
                    ShootBody();
                }
                else
                {
                    if (isRunning == true)
                    {
                        if (!runBody.activeInHierarchy)
                        {
                            runBody.SetActive(true);
                        }
                        if (shootBody.activeInHierarchy)
                        {
                            shootBody.SetActive(false);
                        }
                        if (idleBody.activeInHierarchy)
                        {
                            idleBody.SetActive(false);
                        }
                        if (snipeBody.activeInHierarchy)
                        {
                            snipeBody.SetActive(false);
                        }
                    }
                    else
                    {
                        if (!idleBody.activeInHierarchy)
                        {
                            idleBody.SetActive(true);
                        }
                        if (shootBody.activeInHierarchy)
                        {
                            shootBody.SetActive(false);
                        }
                        if (runBody.activeInHierarchy)
                        {
                            runBody.SetActive(false);
                        }
                        if (snipeBody.activeInHierarchy)
                        {
                            snipeBody.SetActive(false);
                        }
                    }
                }
                if (isRunning == true)
                {
                    if (!runLegs.activeInHierarchy)
                    {
                        runLegs.SetActive(true);
                    }
                    if (idleLegs.activeInHierarchy)
                    {
                        idleLegs.SetActive(false);
                    }
                }
                else
                {
                    if (!idleLegs.activeInHierarchy)
                    {
                        idleLegs.SetActive(true);
                    }
                    if (runLegs.activeInHierarchy)
                    {
                        runLegs.SetActive(false);
                    }
                }
            }
            
        }
    }
    void ShootBody()
    {
            if (!shootBody.activeInHierarchy)
            {
                shootBody.SetActive(true);
            }
            if (idleBody.activeInHierarchy)
            {
                idleBody.SetActive(false);
            }
            if (runBody.activeInHierarchy)
            {
                runBody.SetActive(false);
            }
            if (snipeBody.activeInHierarchy)
            {
                snipeBody.SetActive(false);
            }
    }

    public void IsHit()
    {
        if(isHit == false)
        {
            isHit = true;
            bodies.SetActive(false);
            screenBlocker.SetActive(true);
            physCol.SetActive(false);
            rb.velocity = Vector2.zero;
            StartCoroutine("HitWait");
        } 
    }

    IEnumerator HitWait()
    {
        float upSpeed = 20;
        float backSpeed = -20;
        yield return new WaitForSeconds(.01f);
        if(isGrounded == true)
        {
            rb.AddForce(new Vector2(backSpeed * transform.localScale.x, upSpeed), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(backSpeed * transform.localScale.x, upSpeed), ForceMode2D.Impulse);
        }
         
    }

    public void HitOver()
    {
        isHit = false;
        bodies.SetActive(true);
        screenBlocker.SetActive(false);
        physCol.SetActive(true);
        
    }

    public void VineHang()
    {
        if(isVineHanging == false && isGrounded == false)
        {
            isVineHanging = true;
            bodies.SetActive(false);
            transform.parent = vine;
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            shadow.SetActive(false);
            //-10.08y
            StartCoroutine("VineDelay");
        }
    }

    IEnumerator VineDelay()
    {
        yield return new WaitForSeconds(.01f);
        float y = transform.localPosition.y;
        if (transform.localPosition.y < -10.08f)
        {
            y = -10.08f;
        }
        if (transform.localScale.x < 0)
        {
            transform.localPosition = new Vector2(.59f, y);
            transform.localRotation = Quaternion.Euler(0f, 0f, -1.09f);
        }
        else
        {
            transform.localPosition = new Vector2(-.59f, y);
            transform.localRotation = Quaternion.Euler(0f, 0f, 1.09f);
        }
    }
}
