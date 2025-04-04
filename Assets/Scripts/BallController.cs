using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    Rigidbody rigid;
    private bool isJumping;
    public int itemCount;
    AudioSource audio;
    public GamaManager manager;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        isJumping = false;
        itemCount = 0;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            rigid.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);            
        }
        if(transform.position.y < -5.0f)
        {
            rigid.angularVelocity = Vector3.zero;
            rigid.linearVelocity = Vector3.zero;
            transform.position = new Vector3(0, 0.5f, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v)* 0.5f, ForceMode.Impulse);
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            CoinController coin = other.GetComponent<CoinController>();
            itemCount++;
            audio.Play();
            coin.gameObject.SetActive(false);
            manager.GetCoin(itemCount);
        }
        else if(other.tag == "Goal")
        {
            if(manager.TotalCoinCount == itemCount)
            {
                if(manager.Stage < 2)
                {
                    //다음 스테이지
                    SceneManager.LoadScene("BallPlayStage" + (manager.Stage + 1).ToString());
                }
                else
                {
                    //클리어 화면
                    SceneManager.LoadScene("BallPlayClear");
                }               
            }
            else
            {
                //스테이지 초기화
                SceneManager.LoadScene("BallPlayStage" + manager.Stage);
            }
        }
    }

    public void Jump()
    {
        rigid.AddForce(Vector3.up * 50, ForceMode.Impulse);
    }
}
