using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform FirePosition;
    public GameObject bullet;
    PhotonView view;

    public float force = 100f;
    public float m_StartingHealth = 100f;
    public Slider m_Slider;
    public Image m_FillImage;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    public GameObject m_ExplosionPrefab;


    private AudioSource m_ExplosionAudio;
    private ParticleSystem m_ExplosionParticles;
    private float m_CurrentHealth;
    private bool m_Dead;
    private float dame = 20;

    private void Start() {
        view = GetComponent<PhotonView>();
    }

    private void Update() {
        if (view.IsMine) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                view.RPC("Shoot", RpcTarget.All, FirePosition.position);
            }
        }
    }
    

    private void Awake() {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();

        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }


    private void OnEnable() {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        SetHealthUI();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("bullet") && view.IsMine) {
            m_CurrentHealth -= dame;

            SetHealthUI();

            if (m_CurrentHealth <= 0f && !m_Dead) {
                OnDeath();
            }
        }
    }

    private void SetHealthUI() {
        m_Slider.value = m_CurrentHealth;

        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }


    private void OnDeath() {
        m_Dead = true;

        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);

        m_ExplosionParticles.Play();

        m_ExplosionAudio.Play();

        // Turn the tank off.
        gameObject.SetActive(false);
    }
    [PunRPC]
    void Shoot(Vector3 position) {
        GameObject trans = Instantiate(bullet, position,Quaternion.Euler(transform.TransformDirection(transform.forward)));
        trans.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * force);
    }

}
