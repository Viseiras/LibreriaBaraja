using System;
using System.IO;
using System.Collections;
using libreria;

namespace libreria
{
    public enum ePalo
    {
        Treboles,
        Corazones,
        Diamantes,
        Picas
    }

    public enum eValor
    {
        As = 1,
        Dos = 2,
        Tres = 3,
        Cuatro = 4,
        Cinco = 5,
        Seis = 6,
        Siete = 7,
        Ocho = 8,
        Nueve = 9,
        Diez = 10,
        Jack = 11,
        Queen = 12,
        King = 13

    }

    public class Carta
    {
        //atributos
        private ePalo palo;
        private eValor valor;
        // Contructores
        public Carta(ePalo palo, eValor valor)
        {
            this.palo = palo;
            this.valor = valor;
        }
        public Carta()
        {
            
        }

        //métodos
        public String MuestraCarta()
        {
            int cont = 1;
            /*
            char p = 'T';
            int v = 4;

            return "┌───────┐\n" + "│" + v + "      |\n" + "│       |\n" + "│       |\n" + "│       |\n" + "│      " + p + "|\n" + "└───────┘";*/
            switch(palo)
            {
                case ePalo.Treboles:
                    return "┌───────┐\n" + "│" + cont + "      |\n" + "│       |\n" + "│       |\n" + "│       |\n" + "│" + "Tréboles" + "|\n" + "└───────┘"; break;

                case ePalo.Corazones:
                    return "┌───────┐\n" + "│" + cont + "      |\n" + "│       |\n" + "│       |\n" + "│       |\n" + "│" + "Corazones" + "|\n" + "└───────┘"; break;

                case ePalo.Diamantes:
                    return "┌───────┐\n" + "│" + cont + "      |\n" + "│       |\n" + "│       |\n" + "│       |\n" + "│" + "Diamantes" + "|\n" + "└───────┘"; break;

                case ePalo.Picas:
                    return "┌───────┐\n" + "│" + cont + "      |\n" + "│       |\n" + "│       |\n" + "│       |\n" + "│  " + "Picas" + "|\n" + "└───────┘"; break;
            }
            return "fin de la baraja";
        }
    } //fin de la clase Carta

    public class Baraja
    {
        private List<Carta> baraja; //la sintaxis es List<Carta> baraja = new List<Carta>(tamaño);
        
        //constructores
        public Baraja()
        {
            baraja = new List<Carta>(52);
        }

        //métodos
        public void RellenaBaraja()
        {
            for (int p = 0; p < 4; p++)// Bucle de palos, 4 pasadas
            {
                for (int v = 1; v < 14; v++)// Bucle de cartas, 13 pasadas
                {
                    Carta c = new Carta((ePalo)p, (eValor)v); //creamos una carta 
                    baraja.Add(c); //la añadimos a la List
                }
            }
        }

        public void MuestraCartas()
        {
            foreach(Carta c in baraja)
            {
                Console.WriteLine(c.MuestraCarta());   
            }
        }

    } //fin de la clase Baraja

    public class programa
    {
        static void Main(string[] args)
        {
            Baraja baraja = new Baraja();
            baraja.RellenaBaraja();
            baraja.MuestraCartas();
        }
    }
}
