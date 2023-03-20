using System.Linq;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyCharacteristics _characteristics;
    private KatanaDamage katana;
    
    private Attack _at;

    private void Start()
    {
        _characteristics = GetComponent<EnemyCharacteristics>();
        katana = GetComponent<EnemyCharacteristics>().katana;

        _at = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<Attack>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Katana" && _at.hit && _characteristics.HP > 0)
            _characteristics.HP -= katana.Damage;
    }

    public void DisableColliderAndUseGravity()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
    }
}
