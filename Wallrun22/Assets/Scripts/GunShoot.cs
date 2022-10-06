using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunShoot : MonoBehaviour
{
    public int gunDamage;
    public float fireRate, spread, range, reloadTime, timeBetweenShot;
    public int magazineSize, bulletsPerTab;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    private float timeBetweenShoting;

    public GameObject muzzleFLash, bulletHoleGraphic;
    public TextMeshProUGUI text;
    public Animator anim;
    AudioSource ak47Sound;
   

    private void Start()
    {
        ak47Sound = GetComponent<AudioSource>();
    }


    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        text.SetText(bulletsLeft + " / " + magazineSize);
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTab;
            Shoot();
            ak47Sound.Play();
        }
    }

    private void Shoot()
    {
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);


        readyToShoot = false;

        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
                rayHit.collider.GetComponent<EnemyAiTutorial>().TakeDamage(gunDamage);
        }

        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFLash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShoting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShot);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
        anim.SetBool("Reload", true);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
        anim.SetBool("Reload", false);
    }
}