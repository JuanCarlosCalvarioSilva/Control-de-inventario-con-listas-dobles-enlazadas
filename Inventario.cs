using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_inventario
{
    class Inventario
    {
        Producto inicio, ultimo;

        public void agregar(Producto nuevo)
        {
            if (inicio == null)
                inicio = nuevo;
            else
                ultimo.siguiente = nuevo;
            nuevo.anterior = ultimo;
            ultimo = nuevo;
        }

        public Producto buscar(int codigo)
        {
            Producto actual = inicio;
            while (actual != null)
            {
                if (actual.codigo == codigo)
                    return actual;
                actual = actual.siguiente;
            }
            return null;
        }

        public void borrar(int codigo)
        {
            if (inicio != null)
            {
                Producto actual, anterior;
                anterior = buscarAnteriorPadre(codigo);

                if (anterior == null)
                {
                    actual = inicio;
                    inicio = inicio.siguiente;
                    anterior = inicio;
                }
                else
                {
                    actual = anterior.siguiente;
                    actual.siguiente.anterior = actual.anterior;
                    anterior.siguiente = actual.siguiente;
                }
                actual = null;

                if (anterior == null || anterior.siguiente == null)
                    ultimo = anterior;
            }
        }

        private Producto buscarAnteriorPadre(int codigo)
        {
            Producto anteriorPadre, actual;
            actual = inicio;
            anteriorPadre = null;

            while (actual != null)
            {
                if (actual.codigo == codigo)
                    break;
                anteriorPadre = actual;
                actual = actual.siguiente;
            }
            return anteriorPadre;
        }

        public string reporte()
        {
            string cad = "";

            if (inicio != null)
            {
                Producto actual = inicio;
                while (actual != null)
                {
                    cad += actual.ToString() + Environment.NewLine;
                    actual = actual.siguiente;
                }
            }
            return cad;
        }

        public void insertar(Producto nuevo, int posicion)
        {
            Producto anteriorPadre, actual;
            actual = inicio;
            anteriorPadre = null;
            int contador = 1;

            do
            {
                if (contador == posicion)
                {
                    nuevo.anterior = anteriorPadre;
                    anteriorPadre.siguiente.anterior = nuevo;
                    anteriorPadre.siguiente = nuevo;
                    nuevo.siguiente = actual;
                }
                anteriorPadre = actual;
                actual = actual.siguiente;
                contador++;
            }
            while (actual != null);
        }

        public void AgregarEnInicio(Producto nuevo)
        {
            if (inicio == null)
                inicio = nuevo;
            else
            {
                inicio.anterior = nuevo;
                nuevo.siguiente = inicio;
                inicio = nuevo;
            }
        }

        public string reporteInv()
        {
            string reporte = "";
            Producto temp = inicio;
            if (temp == null)
                return reporte;
            else
                return reporteInver(temp);
        }

        private string reporteInver(Producto temp)
        {
            if (temp.siguiente == null)
                return temp.ToString() + Environment.NewLine;
            else
                return reporteInver(temp.siguiente) + temp.ToString() + Environment.NewLine;
        }

        public void eliminarUltimo()
        {
            Producto anteriorPadre, actual;
            actual = inicio;
            anteriorPadre = null;
            int contador = 1;

            do
            {
                if (actual.siguiente == null) //contador == posicion
                {
                    ultimo = actual.anterior;
                    actual.anterior.siguiente = null;
                }
                anteriorPadre = actual;
                actual = actual.siguiente;
                contador++;
            }
            while (actual != null);
        }

        public void eliminarPrimero()
        {
            if (inicio != null)
            {
                inicio.siguiente.anterior = null;
                inicio = inicio.siguiente;                
            }            
        }
    }
}
