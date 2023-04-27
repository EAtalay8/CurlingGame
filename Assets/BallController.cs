using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int pointCount = 0;

    private Rigidbody ballRigidbody;
    public Image bar;

    public float maxBallForce;
    public bool isThrowed = false;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && bar.fillAmount != 1 && !isThrowed)
        {
            bar.fillAmount += 0.01f;
        }

        if (Input.GetKeyUp(KeyCode.Space) || bar.fillAmount == 1)
        {
            if (!isThrowed)
            {
                ballRigidbody.AddForce(transform.forward * (bar.fillAmount + 0.6f) * maxBallForce);
                isThrowed = true;
            }
        }

        Debug.Log(pointCount);
        /*if (bar.fillAmount == 1 && !isThrowed)
        {
            ballRigidbody.AddForce(transform.forward * (bar.fillAmount + 0.6f) * maxBallForce);
            isThrowed = true;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("+5"))
        {
            pointCount += 5;
        }

        if (other.CompareTag("+10"))
        {
            pointCount += 10;
        }

        if (other.CompareTag("+25"))
        {
            pointCount += 25;
        }

        if (other.CompareTag("-5"))
        {
            pointCount -= 5;
        }

        if (other.CompareTag("-10"))
        {
            pointCount -= 10;
        }

        if (other.CompareTag("-25"))
        {
            pointCount -= 25;
        }

    }
}
