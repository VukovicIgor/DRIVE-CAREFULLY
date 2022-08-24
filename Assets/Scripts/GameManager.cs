using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    { 
        meni,
        pauza,
        voznja,
        udes,
        kraj
    }
    public static GameState gameState;
    public UIManager uiManager;
    public KontrolaIgraca kontrolaIgraca;
    public Toggle toggle;
    public JedanSmer[] jedanSmer;
    public DvaSmera[] dvaSmera;
    public Zvuk zvuk;

    private bool pauza = false;
    private float vreme;
    string imeScene;
    public static bool noc;

    private void Start()
    {
        vreme = 40;
        Scene trenutnaScena = SceneManager.GetActiveScene();
        imeScene = trenutnaScena.name;
    }

    void Update()
    {
        uiManager.PostaviVreme(vreme);
        if (gameState == GameState.voznja || gameState == GameState.pauza)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauza)
                {
                    UgasiPauzu();
                }
                else
                {
                    UpaliPauzu();
                }
            }
        }
        if (imeScene == "Nivo2")
        {
            vreme -= Time.deltaTime;
            uiManager.PostaviVreme(vreme);
        }
        if (vreme<0)
            IstekloVreme();
    }
    public void Meni()
    {
        if(imeScene!="Meni")
            SceneManager.LoadScene("Meni");
        uiManager.PocetniMeni();
        gameState = GameState.meni;
        ResetPozicija();
        noc = false;
    }
    public void IzaberiNivo()
    {
        uiManager.IzborNivoa();
        gameState = GameState.meni;
    }
    public void IzborNivoa1()
    {
        SceneManager.LoadScene("Nivo1");
        uiManager.PocetakIgre();
        gameState = GameState.voznja;
        ResetPozicija();
    }
    public void IzborNivoa2()
    {
        SceneManager.LoadScene("Nivo2");
        uiManager.PocetakIgre();
        gameState = GameState.voznja;
        ResetPozicija();
    }
    public void IzborNivoa3()
    {
        SceneManager.LoadScene("Nivo3");
        uiManager.PocetakIgre();
        gameState = GameState.voznja;
        ResetPozicija();
    }
    public void Udes()
    {
        gameState = GameState.udes;
        Time.timeScale = 0;
        uiManager.Udes();
    }
    public void Cilj()
    {
        gameState = GameState.kraj;
        Time.timeScale = 0;
        uiManager.Cilj();
    }
    public void Reset()
    {
        ResetPozicija();
        vreme = 40;
        gameState = GameState.voznja;
        uiManager.PocetakIgre();
        uiManager.PostaviVreme(vreme);
    }
    public void ResetPozicija()
    {
        for (int i = 0; i < jedanSmer.Length; i++)
        {
            jedanSmer[i].Reset();
        }
        for (int i = 0; i < dvaSmera.Length; i++)
        {
            dvaSmera[i].Reset();
        }      
        kontrolaIgraca.ResetVozila();
        Time.timeScale = 1;
    }
    public void UpaliPauzu()
    {
        gameState = GameState.pauza;
        uiManager.Pauza();
        Time.timeScale = 0;
        pauza = true;
    }
    public void UgasiPauzu()
    {
        gameState = GameState.voznja;
        uiManager.PocetakIgre();
        Time.timeScale = 1;
        pauza = false;
    }
    public void DetekcijaBonusa()
    {
        vreme += 5;
        uiManager.PostaviVreme(vreme);
        zvuk.DodatnoVreme();
    }
    public void IstekloVreme()
    {
        Time.timeScale = 0;
        gameState = GameState.kraj;
        uiManager.IstekloVreme();
    }
    public void DobaDana()
    {
        if (toggle.isOn)
            noc = true;
        else
            noc = false;
    }
    public void Izlaz()
    {
        gameState = GameState.kraj;
        Application.Quit();
    }
    public void Opcije()
    {
        gameState = GameState.meni;
        uiManager.Opcije();
    }
}
