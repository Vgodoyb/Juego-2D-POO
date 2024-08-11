using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class ConfiguracionPlayer : ScriptableObject
{
    [Header("Datos")]
    public int Nivel;
    public string Nombre;
    public Sprite Icono;

    [Header("Valores")]
    public float SaludActual;
    public float SaludMax;
    public float Armadura;
    public float ArmaduraMax;
    public float Energia;
    public float EnergiaMax;
    public float ChanceCritico; //Posibilidad de hacer daño critico
    public float PoderCritico;


    
}
