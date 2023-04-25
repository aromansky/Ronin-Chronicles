using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbsorbLifeCooldown : MonoBehaviour
{
    public Image image;

    void Update()
    {
        var _ch = Camera.main.GetComponent<AbsorbLife>();
        if (!_ch.cooldown)
            image.color = Color.gray;
        else
            image.color = Color.white;

        if (_ch.absorb)
            image.color = Color.red;

    }
}
