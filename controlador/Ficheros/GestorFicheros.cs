using aplicacionFarmacos.modelo;
using System;
using System.IO;

public class GestionaFicheros
{
    private string str;

    public FileStream CargaFichero()
    {
        FileStream registro = new FileStream("registro.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        return registro;
    }

    public void EscribeObjeto(Farmaco farmaco, FileStream accesoDirecto)
    {
        try
        {
            accesoDirecto.Seek(accesoDirecto.Length, SeekOrigin.Begin);
            try
            {
                accesoDirecto.SetLength(UtiliesFarmacos.TAMANYO_OBJETO);
                accesoDirecto.Seek(UtiliesFarmacos.TAMANYO_OBJETO, SeekOrigin.Begin);
                accesoDirecto.Write(BitConverter.GetBytes(farmaco.Codigo), 0, sizeof(int));

                for (int i = 0; i < 10; i++)
                {
                    accesoDirecto.Write(BitConverter.GetBytes(farmaco.IdFarmaco[i]), 0, sizeof(char));
                }
                for (int i = 0; i < 10; i++)
                {
                    accesoDirecto.Write(BitConverter.GetBytes(farmaco.FechaInicio[i]), 0, sizeof(char));
                }
                for (int i = 0; i < 5; i++)
                {
                    accesoDirecto.Write(BitConverter.GetBytes(farmaco.Hora[i]), 0, sizeof(char));
                }
                accesoDirecto.Write(BitConverter.GetBytes(farmaco.Valido[0]), 0, sizeof(char));
                Console.WriteLine("\nRegistrado correctamente! :)");
                Console.WriteLine("\n-------------------\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        catch (Exception e)
        {
        }
    }

    public Farmaco LeeFicheroActivo(FileStream accesoDirecto)
    {
        long tamano = CalculaTamanyo(accesoDirecto);
        int numRegistro = (int)(tamano / UtiliesFarmacos.TAMANYO_OBJETO);
        int valorPedido = -1;
        int codigo = -1;
        bool correcto = true;
        char[] arrayChar = new char[10];
        int cantidadCarac = 0;

        Farmaco temporal = null;

        do
        {
            Console.WriteLine("Dígame que posición quiere");
            valorPedido = 1; // Pedir entero por comando

        } while ((valorPedido <= 0 || valorPedido > numRegistro));
        long posId = 0;
        try
        {
            accesoDirecto.Seek(0, SeekOrigin.Begin);
            do
            {
                if ((codigo = accesoDirecto.ReadByte()) != -1 && codigo == valorPedido)
                {

                    temporal = new Farmaco();
                    temporal.Codigo = codigo;
                    arrayChar = new char[10];
                    while (cantidadCarac <= 9)
                    {
                        char caracter = (char)accesoDirecto.ReadByte();
                        arrayChar[cantidadCarac] = caracter;
                        cantidadCarac++;
                    }
                    temporal.IdFarmaco = arrayChar;

                    cantidadCarac = 0;
                    arrayChar = new char[10];
                    while (cantidadCarac <= 9)
                    {
                        char caracter = (char)accesoDirecto.ReadByte();
                        arrayChar[cantidadCarac] = caracter;
                        cantidadCarac++;
                    }
                    temporal.IdFarmaco = arrayChar;

                    cantidadCarac = 0;
                    arrayChar = new char[5];
                    while (cantidadCarac <= 4)
                    {
                        char caracter = (char)accesoDirecto.ReadByte();
                        arrayChar[cantidadCarac] = caracter;
                        cantidadCarac++;
                    }
                    temporal.Hora = arrayChar;

                    arrayChar = new char[1];
                    char caracter = (char)accesoDirecto.ReadByte();
                    arrayChar[0] = caracter;
                    temporal.Valido = arrayChar;

                    Console.WriteLine("\tCodigo: " + temporal.IdFarmaco);
                    Console.WriteLine("\n\tFecha: " + temporal.FechaInicio);
                    Console.WriteLine("\n\tHora: " + temporal.Hora);
                    Console.WriteLine("\n\tValido: " + temporal.Valido);
                    str = str + "\tCodigo: " + temporal.IdFarmaco + "\n\tFecha: " + temporal.FechaInicio + "\n\tHora: " + temporal.Hora + "\n\tValido: " + temporal.Valido;
                    Console.WriteLine(str);
                    Console.WriteLine("\n-------------------\n");

                    correcto = false;

                }
                else if (codigo == -1 && valorPedido == accesoDirecto.Position / UtiliesFarmacos.TAMANYO_OBJETO)
                {
                    correcto = false;
                }
                else
                {
                    posId = accesoDirecto.Position;
                    posId += UtiliesFarmacos.TAMANYO_OBJETO;
                    if (posId < tamano)
                    {
                        accesoDirecto.Seek(posId, SeekOrigin.Begin);
                    }
                }
            } while ((correcto));
        }
        catch (IOException e)
        {
            Console.WriteLine("Error de Entrada Salida en la lectura de fichero.");
            Console.WriteLine(e.StackTrace);
        }
        return null;
    }

    public long CalculaTamanyo(FileStream accesoDirecto)
    {
        try
        {
            return accesoDirecto.Length;
        }
        catch (IOException e)
        {
            Console.WriteLine(e.StackTrace);
        }
        return 0;
    }
}
