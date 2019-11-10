using UnityEngine;

public class Boy : MonoBehaviour
{
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;
    [Header("跳躍高度"), Range(10, 1500)]
    public int jump = 20;
    [Header("是否在地面上")]
    public bool isgdground = false;
    [Header("音效檔")]
    public AudioClip J;

    private Animator anima;//動畫控制器
    private AudioSource Audio;
    private Rigidbody RG2D;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        RG2D = GetComponent<Rigidbody>();
        anima = GetComponent<Animator>();
    }


    private void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.Space))
        {
            hmjump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "地板")
        {
            isgdground = true;
            anima.SetBool("跳躍開關", false);
        }
    }

    private void Move()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    public void hmjump()
    {
        if (isgdground == true)
        {
            Audio.PlayOneShot(J, 1f);
            anima.SetBool("跳躍開關", true);
            RG2D.AddForce(transform.up * jump);// 剛體.推力(二維向量)
            isgdground = false;
        }

    }

}
