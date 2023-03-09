using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image Bar;
    
    private EnemyCharacteristics _characteristics;
    public Canvas _canvas;
    void Start()
    {
        _characteristics = GetComponent<EnemyCharacteristics>();
    }

    void Update()
    {
        Bar.fillAmount = _characteristics.HP / _characteristics.MaxHP;
        Vector3 direction = (_characteristics.target.transform.position - _canvas.transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        _canvas.transform.rotation = Quaternion.Lerp(_canvas.transform.rotation, LookRotation, (float)0.1);
    }
}
