using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    Animator anim;
   
    public float moveSpeed =5;
    public float LeftRightSpeed;
    public ParticleSystem particle;
    public static bool PlayerLive ;
    //static healdPlayer
    public GameObject HomeGui;
    public GameObject WinGui;
    public GameObject BotDie;
    [SerializeField] Text TextWarning;
    public AudioSource CoinAudio;
    public AudioClip lose;
    public AudioClip GameOverAudio;
    public AudioClip WinAudio;
   
    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(TapPlay());
    }

    void LateUpdate()
    {
      
        if(PlayerLive)
        {
            Playermove(true);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBounDary.LeftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * LeftRightSpeed);
            }

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBounDary.RightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * LeftRightSpeed * -1);
            }
        }

    }

    
    public void Playermove(bool move)
    {

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
       
    }
    public void Die()
    {
        PlayerLive = false;
        // load lại chính khung cảnh sence của mình

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obs" || collision.gameObject.tag =="enemy")
        {
            CoinAudio.PlayOneShot(lose);
            vacham(true);
            StartCoroutine(time());
            GameManager.Health -= 1;
            CoinAudio.PlayOneShot(lose);
           // CoinAudio.PlayOneShot(GameOverAudio);
        }

      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.inst.scores>26 &&  other.gameObject.tag== "win")
        {
            GroundTile groundTile = GameObject.FindObjectOfType<GroundTile>();
            groundTile.spawn = false;
            groundTile.EnemySpawn();
            CoinAudio.PlayOneShot(WinAudio);
            StartCoroutine(timeWin());
            
        }


        if (other.gameObject.tag== "CoinSpeed")
        {
            moveSpeed = 11f;
            StartCoroutine(timeSpeed());
        }

        if (other.gameObject.tag == "coin" || other.gameObject.tag == "CoinSpeed")
        {
            CoinAudio.Play();
            Instantiate(particle, transform.position + new Vector3(0, 0, 0), transform.rotation);
            
        }

    }

    IEnumerator timeSpeed()
    {


        yield return new WaitForSeconds(.6f);

        moveSpeed = 5f;
    }


    private void vacham(bool vacham)
    {
        anim.SetBool("vacham", vacham);

    }

    private void danceWin(bool dance)
    {
        anim.SetBool("danceWin", dance);
    }


    IEnumerator time()
    {
        PlayerLive = false;
       
        yield return new WaitForSeconds(1f);
        PlayerLive = true;
        vacham(false);
    }

    IEnumerator timeWin()
    {

        PlayerLive = false;
        BotDie.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        BotDie.gameObject.SetActive(false);
        yield return new WaitForSeconds(.5f);
        danceWin(true);
        yield return new WaitForSeconds(3f);
        WinGui.gameObject.SetActive(true);
    }
    public void TapToPLay()
    {
        PlayerLive = false;
        HomeGui.gameObject.SetActive(false);
        //TextWarning.gameObject.SetActive(false);
        PlayerLive = true;
        
    }

    IEnumerator TapPlay()
    {
        TextWarning.text = "Chú ý : Khi Bạn ăn đồng xu vàng sẽ được cộng 1 điểm ,ăn đồng xanh sẽ tăng tốc độ chạy";
        yield return new WaitForSeconds(2f);
        TextWarning.text = "Chú ý : Nếu bạn đi vào vũng bùn sẽ giảm tốc độ chạy";
        yield return new WaitForSeconds(2f);
        TextWarning.text = "Chú ý : Hãy tránh các chướng ngại vật để thoát khỏi BOT";
        yield return new WaitForSeconds(2f);
        TextWarning.text = "GOOD LUCK";
        
    }
}