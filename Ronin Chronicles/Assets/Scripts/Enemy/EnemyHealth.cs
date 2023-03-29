using System.Linq;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyCharacteristics _characteristics;
    private float damage;
    
    private Attack _at;

    private void Start()
    {
        _characteristics = GetComponent<EnemyCharacteristics>();
        damage = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<PlayerCharacteristics>().KatanaDamage;

        _at = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<Attack>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Katana" && _at.hit && _characteristics.HP > 0)
        {
            _characteristics.HP -= damage;
        }
    }

    public void DisableColliderAndUseGravity()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
    }
}
