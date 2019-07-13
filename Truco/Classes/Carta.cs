using System;
using System.Collections.Generic;
using System.Text;

namespace Truco
{
    class Carta
    {
        private string pinta;
        private string tipo;
        private int valor;
        private int indice;
        private Boolean usada;

        public Carta()
        {
            pinta = " ";
            tipo = " ";
            valor = 0;
            indice = 0;
            usada = false;
        }

        //Constructor
        public Carta(string t, string p)
        {
            SetCarta(t, p);
            usada = false;
        }

        //Constructor ya teniendo pinta y tipo

        
        public void Usada()
        {
            usada = true;
        }

        public void ResetUsada()
        {
            usada = false;
        }
        

        public string GetTipo()
        {
            return this.tipo;
        }

        //Devuelve el tipo de la carta
        public string GetPinta()
        {
            return this.pinta;
        }

        //Devuelve la pinta de la carta

        public int GetIndice()
        {
            return this.indice;
        }

        //Devuelve el indice de la carta

        public int GetValor()
        {
            return this.valor;
        }

        //Devuelve el valor segun los criterios de truco

        public void SetCarta(string t, string p)
        {
            this.tipo = t;
            this.pinta = p;
 
            if (this.tipo == "CUATRO")
            {
                this.valor = 1;
                this.indice = 4;
            }
            if (this.tipo == "CINCO")
            {
                this.valor = 2;
                this.indice = 5;
            }
            if (this.tipo == "SEIS")
            {
                this.valor = 3;
                this.indice = 6;
            }
            if (this.tipo == "SIETE")
            {
                if (this.pinta == "BASTO" || this.pinta == "COPA")
                {
                    this.valor = 4;
                    this.indice = 7;
                }
                if (this.pinta == "ORO")
                {
                    this.valor = 11;
                    this.indice = 7;
                }
                if (this.pinta == "ESPADA")
                {
                    this.valor = 12;
                    this.indice = 7;
                }
            }
            if (this.tipo == "SOTA")
            {
                this.valor = 5;
                this.indice = 0;
            }
            if (this.tipo == "CABALLO")
            {
                this.valor = 6;
                this.indice = 0;
            }
            if (this.tipo == "REY")
            {
                this.valor = 7;
                this.indice = 0;
            }
            if (this.tipo == "AS")
            {
                if (this.pinta == "ORO" || this.pinta == "COPA")
                {
                    this.valor = 8;
                    this.indice = 1;
                }
                if (this.pinta == "BASTO")
                {
                    this.valor = 13;
                    this.indice = 1;
                }
                if (this.pinta == "ESPADA")
                {
                    this.valor = 14;
                    this.indice = 1;
                }
            }
            if (this.tipo == "DOS")
            {
                this.valor = 9;
                this.indice = 2;
            }
            if (this.tipo == "TRES")
            {
                this.valor = 10;
                this.indice = 3;
            }
            if (this.tipo == " " && this.pinta == " ")
            {
                this.valor = 0;
                this.indice = 0;
            }
        }

        //Asigna el indice y valor sabiendo la pinta y el tipo de la carta
    }
}
