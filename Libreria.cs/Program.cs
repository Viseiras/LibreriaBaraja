using System;
using System.IO;
using System.Collections.Generic;
using libreriaNueva;

namespace libreriaNueva
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
            char simbolo  = ' ';//♠', '♦', '♥', '♣

            switch (p)
            {
                case 0:
                    simbolo  = '♣';
                    break;
                case 1:
                    simbolo = '♥';
                    break;
                case 2:
                    simbolo = '♦';
                    break;
                case 3:
                    simbolo ='♠';
                    break;
            }

            if  (v  >  9)
            {
                return "┌───────┐\n" + "│" + v + "     |\n" + "│       |\n" + "│       |\n" + "│       |\n" + "│      " + simbolo + "|\n" + "└───────┘\n";
            }
            return "┌───────┐\n" + "│" + v + "      |\n" + "│       |\n" + "│       |\n" + "│       |\n" + "│      " + simbolo + "|\n" + "└───────┘\n";
        }
    } //fin de la clase Carta
   
    public class Baraja
    {
        private List<Carta> baraja; //la sintaxis es List<Carta> baraja = new List<Carta>(tamaño);
        private int contPedidos=0;

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
            for(int i=0;i<baraja.Count;i++)
            {
                Console.WriteLine(baraja[i].MuestraCarta());
            }
        }

        public String MuestraCartasHorizontal(int numC)
        {   
            String lineaCarta="";

            int p=3;
            int v=9;
            char simbolo  = ' ';//♠', '♦', '♥', '♣

            

            for(int i=0; i<numC;i++)
                lineaCarta=lineaCarta+"┌───────┐";
            lineaCarta=lineaCarta+"\n";

            for(int i=0;i<numC;i++)
            {
                //v = getValor();
                if  (v  >  9)
                    lineaCarta=lineaCarta+"│" + v + "     |";  
                else
                    lineaCarta=lineaCarta+"│" + v + "      |";   
            }
            lineaCarta=lineaCarta+"\n";

            for(int i=0;i<(numC*3);i++)
            {
                if(i%numC!=numC-1)
                    lineaCarta=lineaCarta+"│       |";
                else
                    lineaCarta=lineaCarta+"│       |\n";
            }
        
            for(int i=0;i<numC;i++)
            {
                //p= getPalo();
                //Nos dice el palo que tiene la carta cambiandolo a char
                switch (p)
                {
                    case 0:
                        simbolo  = '♣';
                        break;
                    case 1:
                        simbolo = '♥';
                        break;
                    case 2:
                        simbolo = '♦';
                        break;
                    case 3:
                        simbolo ='♠';
                        break;
                }
                lineaCarta=lineaCarta+"│      " + simbolo + "|";
            }
            lineaCarta=lineaCarta+"\n";

            for(int i=0; i<numC;i++)
                lineaCarta=lineaCarta+"└───────┘";
            lineaCarta=lineaCarta+"\n";

            return lineaCarta;
        }

        public Carta PideCarta()
        {    
            if(contPedidos<51)
            {
                contPedidos++;
                return baraja[contPedidos];
            }
            else
            {
                Console.WriteLine("Fin de la baraja");
                return null;
            }
        }

        public void MezclaBaraja()
        {
            contPedidos=0;
            var random = new Random();
            //int indice = random.Next(1,baraja.Count);

            Carta aux;   

            for  (int i  =  0;  i  <  baraja.Count;  i++)
            {
                //int a1 = random.Next(1,52);
                int a2 = random.Next(1,52);

                aux = baraja[i];
                baraja[i] = baraja[a2];
                baraja[a2] = aux;
            }
        }

    } //fin de la clase Baraja

    public class programa
    {
        static void Main(string[] args)
        {
            /*Baraja baraja = new Baraja();
            baraja.RellenaBaraja();
            baraja.MezclaBaraja();
            //baraja.MuestraCartas();

            Carta c=baraja.PideCarta();
            //while(c!=null)
            for(int i=0;i<24;i++)
            {
                Console.WriteLine("Dame una carta:");
                Console.ReadLine();
                c=baraja.PideCarta();
                if(c!=null)
                    Console.WriteLine(c.MuestraCarta());
            }
            //baraja.MuestraCartas();*/
            Baraja baraja = new Baraja();
            baraja.RellenaBaraja();
            baraja.MezclaBaraja();

            Console.WriteLine(baraja.MuestraCartasHorizontal(5));
        }
    }
} 
