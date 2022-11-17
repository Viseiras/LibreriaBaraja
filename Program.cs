using System;
using System.IO;
using System.Collections.Generic;
using libreriaNueva;
using System.Runtime.ConstrainedExecution;

namespace libreriaNueva
{
    //enum llamado ePalo con los cuatro palos de la baraja del Poker
    public enum ePalo
    {
        Treboles,
        Corazones,
        Diamantes,
        Picas
    }

    //enum llamado eValor con los valores del 1 al 13 para cada carta
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

    //clase Carta con atributos palo y valor
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

        //setters y getters
        public int getPalo()
        {
            return (int)palo;
        }

        public int getValor()
        {
            return (int)valor;
        }
        //métodos
        public String MuestraCarta()
        {

            int p = getPalo();
            int v = getValor();
            char simbolo = ' ';//♠', '♦', '♥', '♣'

            switch (p)
            {
                case 0:
                    simbolo = '♣';
                    break;
                case 1:
                    simbolo = '♥';
                    break;
                case 2:
                    simbolo = '♦';
                    break;
                case 3:
                    simbolo = '♠';
                    break;
            }

            if (v > 9) //si el valor es mayor que 9 hay que quitar algun espacio en blanco porque el nº de chars aumenta
            {
                return "┌───────┐\n" + "│" + v + "     |\n" + "│       |\n" + "│       |\n" + "│       |\n" + "│      " + simbolo + "|\n" + "└───────┘\n";
            }
            return "┌───────┐\n" + "│" + v + "      |\n" + "│       |\n" + "│       |\n" + "│       |\n" + "│      " + simbolo + "|\n" + "└───────┘\n";
        }
    } //fin de la clase Carta

    //clase Baraja con un list de cartas como atributo, un contador de cartas pedidas y un tamaño de baraja
    public class Baraja
    {
        private List<Carta> baraja; //la sintaxis es List<Carta> baraja = new List<Carta>(tamaño);
        private int contPedidos = 0; //contador que nos sirve para evitar que el metodo PideCarta devuelva repetidas.
        private const int TAM = 52; //constante con el tamaño de la baraja

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
                    baraja.Add(c); //la añadimos a la List baraja
                }
            }
        }

        public void MuestraCartas()
        {
            for (int i = 0; i < TAM; i++)
            {
                Console.WriteLine(baraja[i].MuestraCarta());
            }
        }
        //metodo que necesita como parametro el numero de cartas a mostrar
        public String MuestraCartasHorizontal(int numC)
        {
            String lineaCarta = "";

            int p; //palo
            int v; //valor
            char simbolo = ' ';//♠', '♦', '♥', '♣

            //bucle en el que se crea la parte superior de la carta tantas veces como numero se le haya pasado al metodo como parametro
            for (int i = 0; i < numC; i++) 
                lineaCarta += "┌───────┐";
            lineaCarta += "\n"; 

            for (int i = 0; i < numC; i++)
            {
                v = baraja[i].getValor();
                if (v > 9)
                    lineaCarta += "│" + v + "     |";
                else
                    lineaCarta += "│" + v + "      |";
            }
            lineaCarta += "\n";

            for (int i = 0; i < (numC * 3); i++)
            {
                if (i % numC != numC - 1)
                    lineaCarta += "│       |";
                else
                    lineaCarta += "│       |\n";
            }

            for (int i = 0; i < numC; i++)
            {
                //nos devuelve el palo de la carta para que en simbolo se almacene el del correspondiente palo
                p = baraja[i].getPalo();
                switch (p)
                {
                    case 0:
                        simbolo = '♣';
                        break;
                    case 1:
                        simbolo = '♥';
                        break;
                    case 2:
                        simbolo = '♦';
                        break;
                    case 3:
                        simbolo = '♠';
                        break;
                }
                lineaCarta += "│      " + simbolo + "|";
            }
            lineaCarta += "\n";

            for (int i = 0; i < numC; i++)
                lineaCarta += "└───────┘";
            lineaCarta += "\n";

            return lineaCarta;
        }

        public Carta PideCarta()
        {
            try
            {
                contPedidos++;
                return baraja[contPedidos];
            }
            catch(Exception e)
            {
                Console.WriteLine("Fin de la baraja");
                return null;
            }
        }

        public void MezclaBaraja()
        {
            try //try que controla que salte un mensaje de error cuandos se llame a este metodo sin haber rellenado la baraja
            {
                contPedidos = 0;
                var random = new Random();
                Carta aux;

                for (int i = 0; i < TAM; i++)
                {
                    int a2 = random.Next(1, 52);

                    aux = baraja[i];
                    baraja[i] = baraja[a2];
                    baraja[a2] = aux;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al mezclar, no hay cartas en la baraja.");
            }
            
        }
        public int getTamActual()
        {
            return TAM-contPedidos;
        }

    } //fin de la clase Baraja

    public class programa
    {
        static void Main(string[] args)
        {
            Baraja baraja = new Baraja();
            
            baraja.RellenaBaraja();
            baraja.MezclaBaraja();

            //probando el metodo PideCarta
            
            Carta c;
            while ( (c = baraja.PideCarta()) != null )
            {
                Console.WriteLine(c.MuestraCarta());
            }

            //probando el metodo MuestraCartasHorizontal
            //Console.WriteLine(baraja.MuestraCartasHorizontal(8));
        }
    }
}
