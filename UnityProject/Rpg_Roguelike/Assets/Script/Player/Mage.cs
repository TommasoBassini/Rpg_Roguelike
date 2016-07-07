using UnityEngine;
using System.Collections;
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
    public int mpPerSprito;

    // Atk Melee
    public int atkMeleePerForza;
    public int atkMeleeePerDestrezza;
    public int atkMeleePerSpirito;

    // Atk Magico
    public int atkMagicoPerForza;
    public int atkMagicoPerDestrezza;
    public int atkMagicoPerSpirito;

    // Atk Distanza
    public int atkDistanzaPerForza;
    public int atkDistanzaPerDestrezza;
    public int atkDistanzaPerSpirito;

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
    public int velocitàPerForza;
    public int velocitàPerDestrezza;
    public int velocitàPerSpirito;
}

public class Mage : Player
{
    public IncrementiMago incrementi;

    void start()
    {
       
    }
}
