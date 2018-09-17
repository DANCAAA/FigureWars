using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {
	[SerializeField]
	private Button[] botones = new Button[1];

	public Store tienda;

    #region Tienda
    [SerializeField]
    private GameObject tiendaUI;
    [SerializeField]
    private GameObject inventarioUI;
    [SerializeField]
    private GameObject campaignUI;
    #endregion

    [SerializeField]
    private GameObject compra;
    [SerializeField]
    private GameObject sindinero;

    [SerializeField]
    private GameObject tiendaActiva;
    [SerializeField]
    private GameObject inventarioActivo;
    [SerializeField]
    private GameObject campaingActivo;
    [SerializeField]
    private Text currencyInventario;
    [SerializeField]
    private Text currecyTienda;
    [SerializeField]
    private Inventory inventario;

    [SerializeField]
    private Text cantidadPowerVelocidad;
    [SerializeField]
    private Text cantidadPowerAtk;
    [SerializeField]
    private Text cantidadPowerDef;

    [SerializeField]
    private GameObject descartarSpeed;
    [SerializeField]   
    private GameObject descartarAtk;
    [SerializeField]   
    private GameObject descartarDef;

    [SerializeField]
    private GameObject ConsumirSpeed;
    [SerializeField]
    private GameObject ConsumirAtk;
    [SerializeField]
    private GameObject ConsumirDef;

    [SerializeField]
    private Text descartablesSpeed;
    [SerializeField]
    private Text descartablesAtk;
    [SerializeField]
    private Text descartablesDef;

    private int defDescartar;
    private int atkDescartar;
    private int velDescartar;

    [SerializeField]
    private GameObject consumido;

    [SerializeField]
    private GameObject sinconsumir;

    [SerializeField]
    private GameObject descarteexitoso;

    [SerializeField]
    private Text oroDescarte;
    [SerializeField]
    private Sprite[] imagenesItems;
    
    [SerializeField]
    private GameObject[] espacioImagenes;

    [SerializeField]
    private GameObject[] espacioEquipados;

    [SerializeField]
    private GameObject yaLoTienes;

    private int contadorEspacio;

    // Use this for initialization
    void Start () {
		for (int i = 0; i < botones.Length; i++) {

			//botones[i].onClick.AddListener(delegate {tienda.Sell(i);});	
			}

        currecyTienda.text = inventario.oro.ToString();
        currencyInventario.text = inventario.oro.ToString();
		}

	
	// Update is called once per frame
	void Update () {
		
	}


    public void Tienda()
    {
        tiendaUI.SetActive(true);
        inventarioUI.SetActive(false);
        campaignUI.SetActive(false);
        inventarioActivo.SetActive(false);
        tiendaActiva.SetActive(true);
        campaingActivo.SetActive(false);
    }

    public void Inventario()
    {
        tiendaUI.SetActive(false);
        inventarioUI.SetActive(true);
        campaignUI.SetActive(false);
        inventarioActivo.SetActive(true);
        tiendaActiva.SetActive(false);
        campaingActivo.SetActive(false);
    }

    public void Lobby()
    {
        tiendaUI.SetActive(false);
        inventarioUI.SetActive(false);
        campaignUI.SetActive(true);
        inventarioActivo.SetActive(false);
        tiendaActiva.SetActive(false);
        campaingActivo.SetActive(true);
    }


    public void CompraExitosa(int index)
    {
        compra.SetActive(true);
        currecyTienda.text = inventario.oro.ToString();
        currencyInventario.text = inventario.oro.ToString();

        cantidadPowerAtk.text = inventario.powerUps[1].cantidad.ToString();
        cantidadPowerDef.text = inventario.powerUps[2].cantidad.ToString();
        cantidadPowerVelocidad.text = inventario.powerUps[0].cantidad.ToString();

        if (index <= 11)
        {
            espacioImagenes[contadorEspacio].GetComponent<Image>().sprite = imagenesItems[index];
            contadorEspacio += 1;
        }

        StartCoroutine(Desactivar(compra, 0.5f));
    }

    public void Equipar(int index, int indexItem)
    {
        espacioEquipados[index].GetComponent<Image>().sprite = espacioImagenes[indexItem].GetComponent<Image>().sprite;
    }

    public void Desequipar(int index)
    {
        espacioEquipados[index].GetComponent<Image>().sprite = imagenesItems[12];
    }

    public void SinDinero()
    {
        sindinero.SetActive(true);
        StartCoroutine(Desactivar(sindinero,0.5f));
    }


    IEnumerator Desactivar(GameObject objeto, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        objeto.SetActive(false);
    }

    public void AumentarDinero()
    {
        inventario.oro += 50;
        currecyTienda.text = inventario.oro.ToString();
        currencyInventario.text = inventario.oro.ToString();
    }

    public void ReducirDinero()
    {
        inventario.oro -= 50;
        currecyTienda.text = inventario.oro.ToString();
        currencyInventario.text = inventario.oro.ToString();
    }

    public void MenuConsumibleSpeed()
    {
        descartarSpeed.SetActive(true);
        ConsumirSpeed.SetActive(true);
        StartCoroutine(Desactivar(descartarSpeed, 5f));
        StartCoroutine(Desactivar(ConsumirSpeed, 5f));
    }

    public void MenuConsumibleAtk()
    {
        descartarAtk.SetActive(true);
        ConsumirAtk.SetActive(true);
        StartCoroutine(Desactivar(descartarAtk, 5f));
        StartCoroutine(Desactivar(ConsumirAtk, 5f));
    }

    public void MenuConsumibleDef()
    {
        descartarDef.SetActive(true);
        ConsumirDef.SetActive(true);
        StartCoroutine(Desactivar(descartarDef,5f));
        StartCoroutine(Desactivar(ConsumirDef,5f));
    }

    public void Consumido()
    {
        consumido.SetActive(true);
        cantidadPowerAtk.text = inventario.powerUps[1].cantidad.ToString();
        cantidadPowerDef.text = inventario.powerUps[2].cantidad.ToString();
        cantidadPowerVelocidad.text = inventario.powerUps[0].cantidad.ToString();
        StartCoroutine(Desactivar(consumido, 0.5f));

        velDescartar = 0;
        descartablesSpeed.text = velDescartar.ToString();
        atkDescartar = 0;
        descartablesAtk.text = atkDescartar.ToString();
        defDescartar = 0;
        descartablesDef.text = atkDescartar.ToString();
    }

    public void SinConsumible()
    {
        sinconsumir.SetActive(true);
        StartCoroutine(Desactivar(sinconsumir,0.5f));
    }

    public void LoTienes()
    {
        yaLoTienes.SetActive(true);
        StartCoroutine(Desactivar(yaLoTienes, 0.5f));
    }


    public void Descartar(int index)
    {
        if (index == 0)
        {
            inventario.Discard(0, velDescartar);
        }

        if (index == 1)
        {
            inventario.Discard(1, atkDescartar);
        }

        if (index == 2)
        {
            inventario.Discard(2, defDescartar);
        }
    }


    public void AumentarCantidadDescarte(int index)
    {
        if (index == 0 && (inventario.powerUps[0].cantidad > velDescartar))
        {
            velDescartar += 1;
            descartablesSpeed.text = velDescartar.ToString();
        }

        if (index == 1 && (inventario.powerUps[1].cantidad > atkDescartar))
        {
            atkDescartar += 1;
            descartablesAtk.text = atkDescartar.ToString();
        }

        if (index == 2 && (inventario.powerUps[2].cantidad > defDescartar))
        {
            defDescartar += 1;
            descartablesDef.text = defDescartar.ToString();
        }
    }

    public void RestarCantidadDescarte(int index)
    {
        if (index == 0 && (velDescartar>0))
        {
            velDescartar -= 1;
            descartablesSpeed.text = velDescartar.ToString();

        }

        if (index == 1 && (atkDescartar >0))
        {
            atkDescartar -= 1;
            descartablesAtk.text = atkDescartar.ToString();
        }

        if (index == 2 && (defDescartar>0))
        {
            defDescartar -= 1;
            descartablesDef.text = defDescartar.ToString();
        }
    }

    public void DescarteExitoso(int valor)
    {
        descarteexitoso.SetActive(true);
        cantidadPowerAtk.text = inventario.powerUps[1].cantidad.ToString();
        cantidadPowerDef.text = inventario.powerUps[2].cantidad.ToString();
        cantidadPowerVelocidad.text = inventario.powerUps[0].cantidad.ToString();

        oroDescarte.text = valor.ToString();

        currecyTienda.text = inventario.oro.ToString();
        currencyInventario.text = inventario.oro.ToString();

        atkDescartar = 0;
        defDescartar = 0;
        velDescartar = 0;
        descartablesDef.text = defDescartar.ToString();
        descartablesAtk.text = atkDescartar.ToString();
        descartablesSpeed.text = velDescartar.ToString();

        StartCoroutine(Desactivar(descarteexitoso, 0.5f));
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene("Nivel");
    }

}
