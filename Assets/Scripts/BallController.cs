using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private Animator ballAnimator;
    private Rigidbody ballRigidbody;
    public Image bar;

    public float maxBallForce;
    public bool isThrowed = false;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();
        ballAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ballAnimator.speed = ballRigidbody.velocity.z / 20;
        if (Input.GetKey(KeyCode.Space) && bar.fillAmount != 1 && !isThrowed)
        {
            bar.fillAmount += 0.01f;
        }

        if (Input.GetKeyUp(KeyCode.Space) || bar.fillAmount == 1)
        {
            if (!isThrowed)
            {
                ballRigidbody.AddForce(transform.forward * (bar.fillAmount + 0.6f) * maxBallForce);
                GameManager.instance.spaceText.SetActive(false);
                GameManager.instance.camText.SetActive(true);
            }
        }

        if (ballRigidbody.velocity.z > 0)
        {
            isThrowed = true;
            ballAnimator.SetBool("isSpin", true);
        }

        if (isThrowed && ballRigidbody.velocity.z == 0)
        {
            //GameManager.instance.endGame = true;
            ballRigidbody.mass = 0.1f;
            isThrowed = true;
            //ballAnimator.SetBool("isSpin", false);
            //ballAnimator.speed = 0;
        }

        //Debug.Log(pointCount);
        /*if (bar.fillAmount == 1 && !isThrowed)
        {
            ballRigidbody.AddForce(transform.forward * (bar.fillAmount + 0.6f) * maxBallForce);
            isThrowed = true;
        }*/

        if (GameManager.instance.pointCount < 0)
        {
            //GameManager.instance.pointCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("+5"))
        {
            GameManager.instance.pointCount += 5;
        }

        if (other.CompareTag("+10"))
        {
            GameManager.instance.pointCount += 10;
        }

        if (other.CompareTag("+25"))
        {
            GameManager.instance.pointCount += 25;
        }

        if (other.CompareTag("+50"))
        {
            GameManager.instance.pointCount += 50;
        }

        if (other.CompareTag("-5"))
        {
            GameManager.instance.pointCount -= 5;
        }

        if (other.CompareTag("-10"))
        {
            GameManager.instance.pointCount -= 10;
        }

        if (other.CompareTag("-25"))
        {
            GameManager.instance.pointCount -= 25;
        }

        if (other.CompareTag("-50"))
        {
            GameManager.instance.pointCount -= 50;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("+5"))
        {
            GameManager.instance.pointCount -= 5;
        }

        if (other.CompareTag("+10"))
        {
            GameManager.instance.pointCount -= 10;
        }

        if (other.CompareTag("+25"))
        {
            GameManager.instance.pointCount -= 25;
        }

        if (other.CompareTag("+50"))
        {
            GameManager.instance.pointCount -= 50;
        }
    }
}
