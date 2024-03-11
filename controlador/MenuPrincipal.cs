using aplicacionFarmacos.modelo;
using System;
using System.Collections.Generic;

public class Menu_Principal
{
    public void MenuPrincipal()
    {
        Console.WriteLine("Bienvenido");

        string opcion = "";
        GestionaFicheros gf = new GestionaFicheros();
        FileStream accesoDirecto = gf.CargaFichero();
        Farmaco actual = gf.LeeFicheroActivo(accesoDirecto);

        switch (opcion)
        {
            case "CargarNuevoFarmaco":
                if (actual != null)
                    actual = CargaNuevoFarmaco();
                break;
            case "ModificarFarmaco":
                ModificarFarmaco(actual);
                break;
            case "EliminarFarmaco":
                EliminarFarmaco(actual);
                break;
            case "InsertarFechas":
                InsertarFechas(actual);
                break;
            case "ModificarFechas":
                ModificarFechas(actual);
                break;
            case "EliminarFechas":
                EliminarFechas(actual);
                break;
            case "InsertarHora":
                InsertarHora(actual);
                break;
            case "ModificarHora":
                ModificarHora(actual);
                break;
            case "EliminarHora":
                EliminarHora(actual);
                break;
            default:
                break;
        }
    }

    private void EliminarHora(Farmaco actual)
    {
        actual.Hora = null;
    }

    private void ModificarHora(Farmaco actual)
    {
        string cadena = "introducido por el txtArea";
        actual.Hora = cadena.ToCharArray();
    }

    private void InsertarHora(Farmaco actual)
    {
        string cadena = "introducido por txtArea";
        actual.Hora = cadena.ToCharArray();
    }

    private void EliminarFechas(Farmaco actual)
    {
        actual.FechaInicio = null;
    }

    private void InsertarFechas(Farmaco actual)
    {
        string cadena = "nueva Fecha";
        actual.FechaInicio = cadena.ToCharArray();
    }

    private void ModificarFarmaco(Farmaco actual)
    {
        actual.IdFarmaco = null;
    }

    private void EliminarFarmaco(Farmaco actual)
    {
        actual.Codigo = -1;
    }

    private void ModificarFechas(Farmaco actual)
    {
        actual.FechaInicio = null;
    }

    private Farmaco CargaNuevoFarmaco()
    {
        return new Farmaco("nuevo id");
    }

    public static List<Farmaco> CargaFuncion()
    {
        // Cargará la api de los objetos:
        // https://cima.aemps.es/cima/rest/medicamento?nregistro=51347
        List<Farmaco> listado = new List<Farmaco>();
        return listado;
    }
}
