using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMove : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    public float jumpFactor = 4f;

    public float moveFactor = 1f;

    private bool groundedPlayer;

    public float zeroVelocity = 0.8f;

    public AudioSource jumpAudio;

    private Vector3 fp; //First touch position

    private Vector3 lp; //Last touch position

    private float dragDistance; //minimum distance for a swipe to be registered

    public bool blockMovement;

    float lastTimeClick;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        blockMovement = false;
    }

    void Update()
    {
        //Freeze all rotations
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        /*
        if (Input.GetTouch(0).tapCount == 2)
        {
            Time.timeScale = 0;
        }
        */
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        float currentTimeClick = eventData.clickTime;

        if (Mathf.Abs(currentTimeClick - lastTimeClick) < 0.75f)
        {
            //double-click happened
            Debug.Log("double click");
        }

        lastTimeClick = currentTimeClick;
    }

    void FixedUpdate()
    {
        if (!blockMovement)
        {
            if (isAlmostZero(m_Rigidbody.velocity))
            {
                handleKeyboardEvents();
                handleTouchEvents();
            }
            else
            {
                // Debug.Log("BAD VELOCITY: " + m_Rigidbody.velocity);
            }
        }
    }

    private bool isAlmostZero(Vector3 velocity)
    {
        return Math.Abs(velocity.x) < zeroVelocity &&
        Math.Abs(velocity.y) < zeroVelocity &&
        Math.Abs(velocity.z) < zeroVelocity;
    }

    private void playJumpSound()
    {
        if (jumpAudio != null) jumpAudio.Play();
    }

    private void goForward()
    {
        playJumpSound();
        m_Rigidbody.transform.eulerAngles = new Vector3(0, 0, 0);
        m_Rigidbody
            .AddForce(0, jumpFactor, moveFactor, ForceMode.VelocityChange);
    }

    private void goBack()
    {
        playJumpSound();
        m_Rigidbody.transform.eulerAngles = new Vector3(0, -180, 0);
        m_Rigidbody
            .AddForce(0, jumpFactor, moveFactor * -1, ForceMode.VelocityChange);
    }

    private void goRight()
    {
        playJumpSound();
        m_Rigidbody.transform.eulerAngles = new Vector3(0, 90, 0);
        m_Rigidbody
            .AddForce(moveFactor, jumpFactor, 0, ForceMode.VelocityChange);
    }

    private void goLeft()
    {
        playJumpSound();
        m_Rigidbody.transform.eulerAngles = new Vector3(0, -90, 0);
        m_Rigidbody
            .AddForce(moveFactor * -1, jumpFactor, 0, ForceMode.VelocityChange);
    }

    private void handleKeyboardEvents()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            goForward();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            goBack();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            goRight();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            goLeft();
        }
    }

    private void handleTouchEvents()
    {
        if (
            Input.touchCount == 1 // user is touching the screen with a single touch
        )
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (
                touch.phase == TouchPhase.Began //check for the first touch
            )
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (
                touch.phase == TouchPhase.Moved // update the last position based on where they moved
            )
            {
                lp = touch.position;
            }
            else if (
                touch.phase == TouchPhase.Ended //check if the finger is removed from the screen
            )
            {
                lp = touch.position; //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (
                    Mathf.Abs(lp.x - fp.x) > dragDistance ||
                    Mathf.Abs(lp.y - fp.y) > dragDistance
                )
                {
                    //It's a drag
                    //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {
                        //If the horizontal movement is greater than the vertical movement...
                        if (
                            (lp.x > fp.x) //If the movement was to the right)
                        )
                        {
                            //Right swipe
                            Debug.Log("Right Swipe");
                            goRight();
                        }
                        else
                        {
                            //Left swipe
                            Debug.Log("Left Swipe");
                            goLeft();
                        }
                    }
                    else
                    {
                        //the vertical movement is greater than the horizontal movement
                        if (
                            lp.y > fp.y //If the movement was up
                        )
                        {
                            //Up swipe
                            Debug.Log("Up Swipe");
                            goForward();
                        }
                        else
                        {
                            //Down swipe
                            Debug.Log("Down Swipe");
                            goBack();
                        }
                    }
                }
                else
                {
                    //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }
    }
}
