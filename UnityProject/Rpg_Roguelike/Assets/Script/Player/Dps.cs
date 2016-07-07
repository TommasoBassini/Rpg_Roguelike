using UnityEngine;
using System.Collections;

[System.Serializable]
public class IncrementiDps
{
    // HP
    public int hpPerForza = 10;
    public int hpPerDestrezza = 15;
    public int hpPerSpirito = 10;

    // MP
    public int mpPerForza = 0;
    public int mpPerDestrezza = 5;
    public int mpPerSpirito = 10;

    // Att melee
    public int attMeleePerForza = 7;
    public int attMeleePerDestrezza = 5;
    public int attMeleePerSpirito = 0;

    // Att Magico
    public int attMagicoPerForza = 0;
    public int attMagicoPerDestrezza = 2;
    public int attMagicoPerSpirito = 5;

    // Att Distanza
    public int attDistanzaPerForza = 3;
    public int attDistanzaPerDestrezza = 10;
    public int attDistanzaPerSpirito = 3;

    // Dif fisica
    public int difFisicaPerForza = 5;
    public int difFisicaPerDestrezza = 3;
    public int difFisicaPerSpirito = 0;

    // Dif Magica
    public int difMagicaPerForza = 0;
    public int difMagicaPerDestrezza = 3;
    public int difMagicaPerSpirito = 5;

    // Evasione
    public int evasionePerForza = 0;
    public int evasionePerDestrezza = 5;
    public int evasionePerSpirito = 5;

    // Precisione
    public int precisionePerForza = 0;
    public int precisionePerDestrezza = 5;
    public int precisionePerSpirito = 0;

    // velocita
    public int velocitaPerForza = 3;
    public int velocitaPerDestrezza = 5;
    public int velocitaPerSpirito = 5;

}

public class Dps : Player
{
 public IncrementiDps incrementi;

    new void Start()
    {
        statistiche.hp = 35 + (statistiche.forza * incrementi.hpPerForza) + (statistiche.destrezza * incrementi.hpPerDestrezza) + (statistiche.Spirito * incrementi.hpPerSpirito);
        statistiche.mp = 15 + (statistiche.forza * incrementi.mpPerForza) + (statistiche.destrezza * incrementi.mpPerDestrezza) + (statistiche.Spirito * incrementi.mpPerSpirito);

        statistiche.attMelee = 10 + (statistiche.forza * incrementi.attMeleePerForza) + (statistiche.destrezza * incrementi.attMeleePerDestrezza) + (statistiche.Spirito * incrementi.attMeleePerSpirito);
        statistiche.attMagico = 5 + (statistiche.forza * incrementi.attMagicoPerForza) + (statistiche.destrezza * incrementi.attMagicoPerDestrezza) + (statistiche.Spirito * incrementi.attMagicoPerSpirito);
        statistiche.attDistanza = 15 + (statistiche.forza * incrementi.attDistanzaPerForza) + (statistiche.destrezza * incrementi.attDistanzaPerDestrezza) + (statistiche.Spirito * incrementi.attDistanzaPerSpirito);

        statistiche.difFisica = 15 + (statistiche.forza * incrementi.difFisicaPerForza) + (statistiche.destrezza * incrementi.difFisicaPerDestrezza) + (statistiche.Spirito * incrementi.difFisicaPerSpirito);
        statistiche.difMagica = 15 + (statistiche.forza * incrementi.difMagicaPerForza) + (statistiche.destrezza * incrementi.difMagicaPerDestrezza) + (statistiche.Spirito * incrementi.difMagicaPerSpirito);

        statistiche.evasione = 15 + (statistiche.forza * incrementi.evasionePerForza) + (statistiche.destrezza * incrementi.evasionePerDestrezza) + (statistiche.Spirito * incrementi.evasionePerSpirito);
        statistiche.precisione = 15 + (statistiche.forza * incrementi.precisionePerForza) + (statistiche.destrezza * incrementi.precisionePerDestrezza) + (statistiche.Spirito * incrementi.precisionePerSpirito);
        statistiche.velocita = 10 + (statistiche.forza * incrementi.velocitaPerForza) + (statistiche.destrezza * incrementi.velocitaPerDestrezza) + (statistiche.Spirito * incrementi.velocitaPerSpirito);

    }
}
