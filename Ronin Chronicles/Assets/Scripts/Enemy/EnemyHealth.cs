using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemyHealth : MonoBehaviour
{
    public AudioClip[] hitSounds;
    private EnemyCharacteristics _characteristics;
    private float damage;
    private CharacterController controller;


    private AudioSource audioSource;
    private Attack _at;
    private Animator _anim;

    private void Start()
    {
        _characteristics = GetComponent<EnemyCharacteristics>();
        damage = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<PlayerCharacteristics>().KatanaDamage;
        
        _anim = GetComponent<Animator>();
        _at = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<Attack>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Katana" && _at.hit && _characteristics.HP > 0)
        {
            _characteristics.HP -= damage;
            _anim.Play("Hit Enemy");
            audioSource.PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length)]);
        }
    }

    public void DisableColliderAndUseGravity()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
    }
}
