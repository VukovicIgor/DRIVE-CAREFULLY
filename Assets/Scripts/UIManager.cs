using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject izborOpcije;
    public GameObject izborNivoa;
    public GameObject udes;
    public GameObject pauza;
    public GameObject cilj;
    public GameObject vreme;
    public GameObject brzina;
    public GameObject istekloVreme;
    public GameObject opcije;

    private string imeScene;
    public Text preostaloVreme;

    void Start()
    {
        Scene trenutnaScena = SceneManager.GetActiveScene();
        imeScene = trenutnaScena.name;
        if (imeScene == "Meni")
            PocetniMeni();
        else if (imeScene == "Nivo2")
        {
            showPanel(vreme);
        }
    }
    public void showPanel(GameObject panel)
    {
        izborOpcije.SetActive(false);
        izborNivoa.SetActive(false);
        udes.SetActive(false);
        pauza.SetActive(false);
        cilj.SetActive(false);
        vreme.SetActive(false);
        brzina.SetActive(false);
        istekloVreme.SetActive(false);
        opcije.SetActive(false);

        if (panel != null)
            panel.SetActive(true);
    }
    public void PocetniMeni()
    {
        showPanel(izborOpcije);
    }

    public void IzborNivoa()
    {
        showPanel(izborNivoa);
    }

    public void Pauza()
    {
        showPanel(pauza);
    }

    public void Udes()
    {
        showPanel(udes);
    }

    public void Cilj()
    {
        showPanel(cilj);
    }

    public void PocetakIgre()
    {
        showPanel(null);
        showPanel(brzina);
        if (imeScene == "Nivo2")
        {
            showPanel(vreme);
        }
    }
    public void PreostaloVreme()
    {
        showPanel(vreme);
    }
    public void IstekloVreme()
    {
        showPanel(istekloVreme);
    }
    public void PostaviVreme(float PrVreme)
    {
        preostaloVreme.text = "" + System.Math.Round(PrVreme,2);
    }
    public void Opcije()
    {
        showPanel(opcije);
    }
}
