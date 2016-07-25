using UnityEngine;
using System.Collections;

public class PlayerStatsControl : MonoBehaviour
{

    /// <summary>
    /// Qui andremo a gestire tutte le statistiche e gli incrementi del mago
    /// </summary>
    [System.Serializable]
    public class IncrementiMago
    {
        // HP
        public int hpPerForza;
        public int hpPerDestrezza;
        public int hpPerSpirito;

        // MP
        public int mpPerForza;
        public int mpPerDestrezza;
        public int mpPerSpirito;

        // Att melee
        public int attMeleePerForza;
        public int attMeleePerDestrezza;
        public int attMeleePerSpirito;

        // Att Magico
        public int attMagicoPerForza;
        public int attMagicoPerDestrezza;
        public int attMagicoPerSpirito;

        // Att Distanza
        public int attDistanzaPerForza;
        public int attDistanzaPerDestrezza;
        public int attDistanzaPerSpirito;

        // Dif Fisica
        public int difFisicaPerForza;
        public int difFisicaPerDestrezza;
        public int difFisicaPerSpirito;

        // Dif Magica
        public int difMagicaPerForza;
        public int difMagicaPerDestrezza;
        public int difMagicaPerSpirito;

        // Evasione
        public int evasionePerForza;
        public int evasionePerDestrezza;
        public int evasionePerSpirito;

        // Precisione
        public int precisionePerForza;
        public int precisionePerDestrezza;
        public int precisionePerSpirito;

        // Velocità
        public int velocitaPerForza;
        public int velocitaPerDestrezza;
        public int velocitaPerSpirito;


    }

    [System.Serializable]
    public class StatsMago
    {
        //Statistiche
        public int livello;

        public int hpMax;
        public int hp;
        public int mpMax;
        public int mp;

        public int forza;
        public int destrezza;
        public int Spirito;

        public int attMelee;
        public int attMagico;
        public int attDistanza;

        public int difFisica;
        public int difMagica;

        public int evasione;
        public int precisione;
        public int velocita;

        public bool[] abilitaSbloccate = new bool[5];
        public int costoForza = 100;
        public int costoDestrezza = 100;
        public int costoSpirito = 100;
        public int[] costoAbilita = new int[5];
    }

    /// <summary>
    /// Qui andremo a gestire tutte le statistiche e gli incrementi del tank
    /// </summary>
    [System.Serializable]
    public class IncrementiTank
    {
        // HP
        public int hpPerForza;
        public int hpPerDestrezza;
        public int hpPerSpirito;

        // MP
        public int mpPerForza;
        public int mpPerDestrezza;
        public int mpPerSpirito;

        // Att melee
        public int attMeleePerForza;
        public int attMeleePerDestrezza;
        public int attMeleePerSpirito;

        // Att Magico
        public int attMagicoPerForza;
        public int attMagicoPerDestrezza;
        public int attMagicoPerSpirito;

        // Att Distanza
        public int attDistanzaPerForza;
        public int attDistanzaPerDestrezza;
        public int attDistanzaPerSpirito;

        // Dif Fisica
        public int difFisicaPerForza;
        public int difFisicaPerDestrezza;
        public int difFisicaPerSpirito;

        // Dif Magica
        public int difMagicaPerForza;
        public int difMagicaPerDestrezza;
        public int difMagicaPerSpirito;

        // Evasione
        public int evasionePerForza;
        public int evasionePerDestrezza;
        public int evasionePerSpirito;

        // Precisione
        public int precisionePerForza;
        public int precisionePerDestrezza;
        public int precisionePerSpirito;

        // Velocità
        public int velocitaPerForza;
        public int velocitaPerDestrezza;
        public int velocitaPerSpirito;
    }

    [System.Serializable]
    public class StatsTank
    {
        //Statistiche
        public int livello;

        public int hpMax;
        public int hp;
        public int mpMax;
        public int mp;

        public int forza;
        public int destrezza;
        public int Spirito;

        public int attMelee;
        public int attMagico;
        public int attDistanza;

        public int difFisica;
        public int difMagica;

        public int evasione;
        public int precisione;
        public int velocita;

        public bool[] abilitaSbloccate = new bool[5];
        public int costoForza = 100;
        public int costoDestrezza = 100;
        public int costoSpirito = 100;
        public int[] costoAbilita = new int[5];

    }
    /// <summary>
    /// Qui andremo a gestire tutte le statistiche e gli incrementi del Dps
    /// </summary>
    [System.Serializable]
    public class IncrementiDps
    {
        // HP
        public int hpPerForza;
        public int hpPerDestrezza;
        public int hpPerSpirito;

        // MP
        public int mpPerForza;
        public int mpPerDestrezza;
        public int mpPerSpirito;

        // Att melee
        public int attMeleePerForza;
        public int attMeleePerDestrezza;
        public int attMeleePerSpirito;

        // Att Magico
        public int attMagicoPerForza;
        public int attMagicoPerDestrezza;
        public int attMagicoPerSpirito;

        // Att Distanza
        public int attDistanzaPerForza;
        public int attDistanzaPerDestrezza;
        public int attDistanzaPerSpirito;

        // Dif Fisica
        public int difFisicaPerForza;
        public int difFisicaPerDestrezza;
        public int difFisicaPerSpirito;

        // Dif Magica
        public int difMagicaPerForza;
        public int difMagicaPerDestrezza;
        public int difMagicaPerSpirito;

        // Evasione
        public int evasionePerForza;
        public int evasionePerDestrezza;
        public int evasionePerSpirito;

        // Precisione
        public int precisionePerForza;
        public int precisionePerDestrezza;
        public int precisionePerSpirito;

        // Velocità
        public int velocitaPerForza;
        public int velocitaPerDestrezza;
        public int velocitaPerSpirito;
    }

    [System.Serializable]
    public class StatsDps
    {
        public int livello;
        //Statistiche
        public int hpMax;
        public int hp;
        public int mpMax;
        public int mp;

        public int forza;
        public int destrezza;
        public int Spirito;

        public int attMelee;
        public int attMagico;
        public int attDistanza;

        public int difFisica;
        public int difMagica;

        public int evasione;
        public int precisione;
        public int velocita;

        public bool[] abilitaSbloccate = new bool[5];
        public int costoForza = 100;
        public int costoDestrezza = 100;
        public int costoSpirito = 100;
        public int[] costoAbilita = new int[5];
    }

    public IncrementiDps incrementiDps;
    public StatsDps statsDps;
    public IncrementiTank incrementiTank;
    public StatsTank statsTank;
    public IncrementiMago incrementiMago;
    public StatsMago statsMago;

    public int nPotionHealth;
    public int nPotionMana;

    public int esperience;
    public int soldi;

    void Awake ()
    {
        DontDestroyOnLoad(this.gameObject);
        AggiornaStatsDps();
        AggiornaStatsMago();
        AggiornaStatsTank();
	}
	
    void AggiornaStatsDps()
    {
        statsDps.hpMax = 35 + (statsDps.forza * incrementiDps.hpPerForza) + (statsDps.destrezza * incrementiDps.hpPerDestrezza) + (statsDps.Spirito * incrementiDps.hpPerSpirito);
        statsDps.hp = 35 + (statsDps.forza * incrementiDps.hpPerForza) + (statsDps.destrezza * incrementiDps.hpPerDestrezza) + (statsDps.Spirito * incrementiDps.hpPerSpirito);
        statsDps.mpMax = 15 + (statsDps.forza * incrementiDps.mpPerForza) + (statsDps.destrezza * incrementiDps.mpPerDestrezza) + (statsDps.Spirito * incrementiDps.mpPerSpirito);
        statsDps.mp = 15 + (statsDps.forza * incrementiDps.mpPerForza) + (statsDps.destrezza * incrementiDps.mpPerDestrezza) + (statsDps.Spirito * incrementiDps.mpPerSpirito);

        statsDps.attMelee = 10 + (statsDps.forza * incrementiDps.attMeleePerForza) + (statsDps.destrezza * incrementiDps.attMeleePerDestrezza) + (statsDps.Spirito * incrementiDps.attMeleePerSpirito);
        statsDps.attMagico = 5 + (statsDps.forza * incrementiDps.attMagicoPerForza) + (statsDps.destrezza * incrementiDps.attMagicoPerDestrezza) + (statsDps.Spirito * incrementiDps.attMagicoPerSpirito);
        statsDps.attDistanza = 15 + (statsDps.forza * incrementiDps.attDistanzaPerForza) + (statsDps.destrezza * incrementiDps.attDistanzaPerDestrezza) + (statsDps.Spirito * incrementiDps.attDistanzaPerSpirito);

        statsDps.difFisica = 15 + (statsDps.forza * incrementiDps.difFisicaPerForza) + (statsDps.destrezza * incrementiDps.difFisicaPerDestrezza) + (statsDps.Spirito * incrementiDps.difFisicaPerSpirito);
        statsDps.difMagica = 15 + (statsDps.forza * incrementiDps.difMagicaPerForza) + (statsDps.destrezza * incrementiDps.difMagicaPerDestrezza) + (statsDps.Spirito * incrementiDps.difMagicaPerSpirito);

        statsDps.evasione = 15 + (statsDps.forza * incrementiDps.evasionePerForza) + (statsDps.destrezza * incrementiDps.evasionePerDestrezza) + (statsDps.Spirito * incrementiDps.evasionePerSpirito);
        statsDps.precisione = 15 + (statsDps.forza * incrementiDps.precisionePerForza) + (statsDps.destrezza * incrementiDps.precisionePerDestrezza) + (statsDps.Spirito * incrementiDps.precisionePerSpirito);
        statsDps.velocita = 10 + (statsDps.forza * incrementiDps.velocitaPerForza) + (statsDps.destrezza * incrementiDps.velocitaPerDestrezza) + (statsDps.Spirito * incrementiDps.velocitaPerSpirito);
       }

    void AggiornaStatsTank()
    {
        statsTank.hpMax = 50 + (statsTank.forza * incrementiTank.hpPerForza) + (statsTank.destrezza * incrementiTank.hpPerDestrezza) + (statsTank.Spirito * incrementiTank.hpPerSpirito);
        statsTank.hp = 50 + (statsTank.forza * incrementiTank.hpPerForza) + (statsTank.destrezza * incrementiTank.hpPerDestrezza) + (statsTank.Spirito * incrementiTank.hpPerSpirito);
        statsTank.mp = 10 + (statsTank.forza * incrementiTank.mpPerForza) + (statsTank.destrezza * incrementiTank.mpPerDestrezza) + (statsTank.Spirito * incrementiTank.mpPerSpirito);
        statsTank.mpMax = 10 + (statsTank.forza * incrementiTank.mpPerForza) + (statsTank.destrezza * incrementiTank.mpPerDestrezza) + (statsTank.Spirito * incrementiTank.mpPerSpirito);

        statsTank.attMelee = 20 + (statsTank.forza * incrementiTank.attMeleePerForza) + (statsTank.destrezza * incrementiTank.attMeleePerDestrezza) + (statsTank.Spirito * incrementiTank.attMeleePerSpirito);
        statsTank.attMagico = 5 + (statsTank.forza * incrementiTank.attMagicoPerForza) + (statsTank.destrezza * incrementiTank.attMagicoPerDestrezza) + (statsTank.Spirito * incrementiTank.attMagicoPerSpirito);
        statsTank.attDistanza = 10 + (statsTank.forza * incrementiTank.attDistanzaPerForza) + (statsTank.destrezza * incrementiTank.attDistanzaPerDestrezza) + (statsTank.Spirito * incrementiTank.attDistanzaPerSpirito);

        statsTank.difFisica = 15 + (statsTank.forza * incrementiTank.difFisicaPerForza) + (statsTank.destrezza * incrementiTank.difFisicaPerDestrezza) + (statsTank.Spirito * incrementiTank.difFisicaPerSpirito);
        statsTank.difMagica = 5 + (statsTank.forza * incrementiTank.difMagicaPerForza) + (statsTank.destrezza * incrementiTank.difMagicaPerDestrezza) + (statsTank.Spirito * incrementiTank.difMagicaPerSpirito);

        statsTank.evasione = 5 + (statsTank.forza * incrementiTank.evasionePerForza) + (statsTank.destrezza * incrementiTank.evasionePerDestrezza) + (statsTank.Spirito * incrementiTank.evasionePerSpirito);
        statsTank.precisione = 10 + (statsTank.forza * incrementiTank.precisionePerForza) + (statsTank.destrezza * incrementiTank.precisionePerDestrezza) + (statsTank.Spirito * incrementiTank.precisionePerSpirito);
        statsTank.velocita = 5 + (statsTank.forza * incrementiTank.velocitaPerForza) + (statsTank.destrezza * incrementiTank.velocitaPerDestrezza) + (statsTank.Spirito * incrementiTank.velocitaPerSpirito);
      }

    void AggiornaStatsMago()
    {
        statsMago.hpMax = 25 + (statsMago.forza * incrementiMago.hpPerForza) + (statsMago.destrezza * incrementiMago.hpPerDestrezza) + (statsMago.Spirito * incrementiMago.hpPerSpirito);
        statsMago.hp = 25 + (statsMago.forza * incrementiMago.hpPerForza) + (statsMago.destrezza * incrementiMago.hpPerDestrezza) + (statsMago.Spirito * incrementiMago.hpPerSpirito);
        statsMago.mp = 25 + (statsMago.forza * incrementiMago.mpPerForza) + (statsMago.destrezza * incrementiMago.mpPerDestrezza) + (statsMago.Spirito * incrementiMago.mpPerSpirito);
        statsMago.mpMax = 25 + (statsMago.forza * incrementiMago.mpPerForza) + (statsMago.destrezza * incrementiMago.mpPerDestrezza) + (statsMago.Spirito * incrementiMago.mpPerSpirito);

        statsMago.attMelee = 5 + (statsMago.forza * incrementiMago.attMeleePerForza) + (statsMago.destrezza * incrementiMago.attMeleePerDestrezza) + (statsMago.Spirito * incrementiMago.attMeleePerSpirito);
        statsMago.attMagico = 20 + (statsMago.forza * incrementiMago.attMagicoPerForza) + (statsMago.destrezza * incrementiMago.attMagicoPerDestrezza) + (statsMago.Spirito * incrementiMago.attMagicoPerSpirito);
        statsMago.attDistanza = 5 + (statsMago.forza * incrementiMago.attDistanzaPerForza) + (statsMago.destrezza * incrementiMago.attDistanzaPerDestrezza) + (statsMago.Spirito * incrementiMago.attDistanzaPerSpirito);

        statsMago.difFisica = 5 + (statsMago.forza * incrementiMago.difFisicaPerForza) + (statsMago.destrezza * incrementiMago.difFisicaPerDestrezza) + (statsMago.Spirito * incrementiMago.difFisicaPerSpirito);
        statsMago.difMagica = 15 + (statsMago.forza * incrementiMago.difMagicaPerForza) + (statsMago.destrezza * incrementiMago.difMagicaPerDestrezza) + (statsMago.Spirito * incrementiMago.difMagicaPerSpirito);

        statsMago.evasione = 15 + (statsMago.forza * incrementiMago.evasionePerForza) + (statsMago.destrezza * incrementiMago.evasionePerDestrezza) + (statsMago.Spirito * incrementiMago.evasionePerSpirito);
        statsMago.precisione = 5 + (statsMago.forza * incrementiMago.precisionePerForza) + (statsMago.destrezza * incrementiMago.precisionePerDestrezza) + (statsMago.Spirito * incrementiMago.precisionePerSpirito);
        statsMago.velocita = 8 + (statsMago.forza * incrementiMago.velocitaPerForza) + (statsMago.destrezza * incrementiMago.velocitaPerDestrezza) + (statsMago.Spirito * incrementiMago.velocitaPerSpirito);        
    }
}
