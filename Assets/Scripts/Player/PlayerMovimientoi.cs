using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovimientoi : MonoBehaviour
{
    [Header("Dash")]
    [SerializeField] private float velocidadDash = 20f;
    [SerializeField] private float tiempoDash= 0.5f;
    [SerializeField] private float transparencia = 0.2f;



    [Header("Config")]
    [SerializeField] private float velocidadMovimiento = 10f;

    private Rigidbody2D rb2D;
    private PlayerAcciones acciones;

    private bool usandoDash;
    private float velocidadActual;
    private Vector2 direccionMovimiento;
    private SpriteRenderer spriteRenderer;




    public void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        acciones = new PlayerAcciones();    
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Start()
    {
        velocidadActual = velocidadMovimiento;
        acciones.Movimiento.Dash.performed += ctx => Dash();
    }

    private void Update()
    {
        CapturarInput();
        RotarPlayer();
    }

    private void FixedUpdate()
    {
        MoverPlayer();
    }

    private void ModificarSpriteRenderer(float valor)
    {
        Color color = spriteRenderer.color;
        color = new Color(color.r, color.g, color.b, a:valor);
        spriteRenderer.color = color;
    }
    private void MoverPlayer()
    {
        rb2D.MovePosition(rb2D.position + direccionMovimiento * (velocidadMovimiento * Time.fixedDeltaTime));

    }

    private void RotarPlayer()
    {
        if( direccionMovimiento.x >= 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (direccionMovimiento.x < 0)
        {
            spriteRenderer.flipX=true;        
        }
    }
    private void Dash()
    {
        if(usandoDash)
        {
            return;
        }

        usandoDash = true;
        StartCoroutine(IEDash());


    }

    private IEnumerator IEDash()
    { 
        velocidadActual = velocidadDash;
        ModificarSpriteRenderer( transparencia);
        yield return new WaitForSeconds(tiempoDash);
        ModificarSpriteRenderer(1f);
        velocidadActual = velocidadMovimiento;
        usandoDash = false;

    }
    private void OnEnable()
    {
        acciones.Enable();
    }

    private void OnDisable()
    {
        acciones.Disable();
    }

    private void CapturarInput()
    {
        direccionMovimiento = acciones.Movimiento.Mover.ReadValue<Vector2>().normalized;
    }

}
