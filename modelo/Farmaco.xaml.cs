using System;

public class Farmaco
{
    private int codigo;
    private char[] idFarmaco = new char[10];
    private char[] fechaInicio = new char[10];
    private char[] hora = new char[5];
    private char[] valido = new char[1];

    public char[] IdFarmaco
    {
        get { return idFarmaco; }
        set { idFarmaco = value; }
    }

    public char[] FechaInicio
    {
        get { return fechaInicio; }
        set { fechaInicio = value; }
    }

    public int Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }

    public char[] Hora
    {
        get { return hora; }
        set { hora = value; }
    }

    public char[] Valido
    {
        get { return valido; }
        set { valido = value; }
    }

    public Farmaco()
    {
    }

    public Farmaco(string idFarmaco)
    {
        this.codigo = 1;
        this.idFarmaco = idFarmaco.ToCharArray();
        this.fechaInicio = null;
        this.hora = null;
        char[] validoIntermedio = new char[1];
        validoIntermedio[0] = 'b';
        this.valido = validoIntermedio;
    }
}
