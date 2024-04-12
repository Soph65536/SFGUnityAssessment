using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    const float shootForce = 100;

    public GameObject AmmoObject;

    private bool isShooting;

    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0) && !isShooting) { StartCoroutine("BallShoot"); }
    }

    private IEnumerator BallShoot()
    {
        isShooting = true;

        GameObject newAmmoObject = Instantiate(AmmoObject, transform.position, transform.rotation);
        newAmmoObject.GetComponent<Rigidbody>().velocity = transform.forward * shootForce;
        yield return new WaitForSeconds(1);

        isShooting = false;
    }
}
