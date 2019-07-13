using System;
using System.Collections.Generic;
using System.Text;

namespace Truco
{
    class Mazo : Carta
    {
        const int num_cartas = 40;
        public Carta[] deck;

        public Mazo()
        {
            deck = new Carta[num_cartas];  
            SetUpMazo();
        }

        //constructor de mazo

        public Carta[] MyDeck { get { return deck; } }

        //obtener mazo actual

        public Carta GetCarta(int n) { return deck[n]; }

        //traer carta

        public void SetUpMazo()
        {
            string[] Pinta = new string[] { "COPA", "BASTO", "ESPADA", "ORO" };
            string[] Tipo = new string[] { "AS", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "SOTA", "CABALLO", "REY" };
            int i = 0;
            foreach (var p in Pinta)
            {
                foreach (var t in Tipo)
                {
                    deck[i] = new Carta(t,p);
                    i++;
                }
            }
            RevolverDeck();
        }

        // Se llena el mazo y se revuelve el mazo

        
        public void RestetCartas()
        {
            for (int i = 0; i < num_cartas; i++)
                deck[i].ResetUsada();
        }
        

        public void RevolverDeck()  //barajeamos
        {
            Random rand = new Random();
            Carta temp;
            for (int shuffletimes = 0; shuffletimes < 1000; shuffletimes++)
            {
                for (int i = 0; i < num_cartas; i++)
                {
                    int index = rand.Next(15);
                    temp = deck[i];
                    deck[i] = deck[index];
                    deck[index] = temp;
                }
            }
            RestetCartas();
        }

        //Desordena el mazo
    }
}
