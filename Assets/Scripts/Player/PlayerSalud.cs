using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSalud : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private ConfiguracionPlayer configPlayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RecibirDanho(1f);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            RecuperarSalud(1f);

        }
    }
    public void RecuperarSalud(float cantidad)
    {
        configPlayer.SaludActual += cantidad;
        if (configPlayer.SaludActual > configPlayer.SaludMax)
        {
            configPlayer.SaludActual = configPlayer.SaludMax;
        }
    }
    public void RecibirDanho(float cantidad)
    {
        if (configPlayer.Armadura > 0)
        {
            float danhoRestante = cantidad - configPlayer.Armadura;
            configPlayer.Armadura = Mathf.Max(configPlayer.Armadura - cantidad, 0f);
            if (danhoRestante > 0f)
            {
                configPlayer.SaludActual = Mathf.Max(configPlayer.SaludActual - danhoRestante, 0f);
            }
        }
        else
        {
            configPlayer.SaludActual = Mathf.Max(configPlayer.SaludActual - cantidad, 0f);
        }

        if (configPlayer.SaludActual <= 0f)
        {
            PlayerDerrotado();
        }
    }

    private void PlayerDerrotado()
    {
        Destroy(gameObject);
    }

    
}


