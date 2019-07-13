using System;
using System.Collections.Generic;
using System.Text;

namespace Truco
{
    class Jugador
    {
        public string nombre;
        const int num_cartas = 3;
        private Carta[] mano;
        private Boolean mesa;
        private int puntos;
        public char equipo;

        public Jugador(char e)
        {
            this.mano = new Carta[num_cartas];  //constructor de mazo
            this.puntos = 0;
            this.nombre = "";
            this.mesa = false;
            this.equipo = e;
        }

        //Contructor
        public Jugador(string n, char e)
        {
            this.mano = new Carta[num_cartas];  //constructor de mazo
            this.puntos = 0;
            this.nombre = n;
            this.mesa = false;
            this.equipo = e;
        }

        //Constructor asignando el nombre
        public Carta GetCartaMano(int i) { return mano[i]; }

        //Obtener carta de la mano

        public Carta[] MyMano { get { return mano; } }

        //Obtener mano completa

        public Boolean GetMesa()
        {
            return mesa;
        }

        public String GetNombre()
        {
            return nombre;
        }

        public int GetPuntos()
        {
            return puntos;
        }

        public void SetUpMano(Carta a, int i)
        {
            mano[i] = a;
        }

        //Asignar carta a la mano

        public void SetMesa(Boolean b)
        {
            this.mesa = b;
        }

        //Hacerlo o deshacerlo mesa

        public void SetNombre(string n)
        {
            this.nombre = n;
        }

        //Cambiar nombre

        public void CartaManoUsada(int i)
        {
            mano[i].Usada();
        }

        public void ResetManoUsada()
        {
            for (int i = 0; i < 3;i++)
            mano[i].ResetUsada();
        }

        public void AddPuntos(int p)
        {
            this.puntos += p;
        }

        //Agregar puntos

        public void ResetPuntos()
        {
            this.puntos = 0;
        }

        //Resetear puntos

        public Boolean Ganador()
        {
            if (puntos >= 24)
                return true;
            return false;
        }

        //Revisa si ya hay ganador

        public Boolean Flor(Carta vira)
        {
            string a = mano[0].GetPinta();
            string b = mano[1].GetPinta();
            string c = mano[2].GetPinta();

            if (a == b && a == c)
                return true;
            else if (Perica(vira) == true || Perico(vira) == true)
            {

                return true;
            }
            return false;
        }

        //Verifica si la mano tienen la misma pinta

        public Boolean Doble()
        {
            string a = this.mano[0].GetPinta();
            string b = this.mano[1].GetPinta();
            string c = this.mano[2].GetPinta();

            if (a == b || a == c || b == c)
                return true;
            return false;
        }

        //Verifica si hay un doble en la mano

        public int Mayor()
        {
            int a = mano[0].GetIndice();
            int b = mano[1].GetIndice();
            int c = mano[2].GetIndice();

            if (a >= b)
            {
                if (a >= c)
                {
                    return a;
                }
                else return c;
            }
            else if (b >= c)
            {
                return b;
            }
            return c;
        }

        //Devuelve la carta de mayor indice

        public int MayorV()
        {
            int a = mano[0].GetValor();
            int b = mano[1].GetValor();
            int c = mano[2].GetValor();

            if (a >= b)
            {
                if (a >= c)
                {
                    return a;
                }
                else return c;
            }
            else if (b >= c)
            {
                return b;
            }
            return c;
        }

        //Devuelve la carta de mayor valor

        public int MenorV()
        {
            int a = mano[0].GetValor();
            int b = mano[1].GetValor();
            int c = mano[2].GetValor();

            if (a >= b)
            {
                if (b >= c)
                {
                    return c;
                }
                else return b;
            }
            else if (a >= c)
            {
                return c;
            }
            return a;
        }

        //Devuelve la carta de mayor valor

        public int MedioV()
        {
            int a = mano[0].GetValor();
            int b = mano[1].GetValor();
            int c = mano[2].GetValor();

            if (a >= b)
            {
                if (a >= c)
                {
                    if (b >= c)
                    {
                        return b;
                    }
                    else return c;
                }
                else return a;
            }
            else if (b >= c)
            {
                if (a >= c)
                {
                    return a;
                }
                else return c;
            }
            return b;
        }

        //Devuelve la carta de medio valor

        public int IdMayorV()
        {
            int a = mano[0].GetValor();
            int b = mano[1].GetValor();
            int c = mano[2].GetValor();

            if (a >= b)
            {
                if (a >= c)
                {
                    return 0;
                }
                else return 2;
            }
            else if (b >= c)
            {
                return 1;
            }
            return 2;
        }

        //Devuelve la carta de mayor valor

        public int IdMedioV()
        {
            int a = mano[0].GetValor();
            int b = mano[1].GetValor();
            int c = mano[2].GetValor();

            if (a >= b)
            {
                if (a >= c)
                {
                    if (b >= c)
                    {
                        return 1;
                    }
                    else return 2;
                }
                else return 0;
            }
            else if (b >= c)
            {
                if (a >= c)
                {
                    return 0;
                }
                else return 2;
            }
            return 1;
        }

        public int IdMenorV()
        {
            int a = mano[0].GetValor();
            int b = mano[1].GetValor();
            int c = mano[2].GetValor();

            if (a >= b)
            {
                if (b >= c)
                {
                    return 2;
                }
                else return 1;
            }
            else if (a >= c)
            {
                return 2;
            }
            return 0;
        }

        public Boolean Perico(Carta v)
        {
            string tipo = v.GetTipo();
            string pinta = v.GetPinta();

            for (int i = 0; i < 2; i++)
            {
                if (mano[i].GetTipo() == "CABALLO" && tipo != "SOTA" && tipo != "REY" && tipo != "CABALLO")
                {
                    if (mano[i].GetPinta() == pinta)
                        return true;
                }
                else if (mano[i].GetTipo() == "REY" && tipo == "CABALLO")
                {
                    if (mano[i].GetPinta() == pinta)
                        return true;
                }
            }
            return false;
        }

        //Chequea si hay perico en la mano

        public Boolean Perico(Carta v, Carta m)
        {
            string tipo = v.GetTipo();
            string pinta = v.GetPinta();
            
            if (m.GetTipo() == "CABALLO" && tipo != "SOTA" && tipo != "REY" && tipo != "CABALLO")
            {
                if (m.GetPinta() == pinta)
                    return true;
            }
            else if (m.GetTipo() == "REY" && tipo == "CABALLO")
            {
                if (m.GetPinta() == pinta)
                    return true;
            }
            return false;
        }

        public Boolean Perica(Carta v)
        {
            string tipo = v.GetTipo();
            string pinta = v.GetPinta();

            for (int i = 0; i < 2; i++)
            {
                if (mano[i].GetTipo() == "SOTA" && tipo != "SOTA" && tipo != "REY" && tipo != "CABALLO")
                {
                    if (mano[i].GetPinta() == pinta)
                        return true;
                }
                if (mano[i].GetTipo() == "REY" && tipo == "SOTA")
                {
                    if (mano[i].GetPinta() == pinta)
                        return true;
                }
            }
            return false;
        }

        //Chequea si hay perica en la mano

        public Boolean Perica(Carta v, Carta m)
        {
            string tipo = v.GetTipo();
            string pinta = v.GetPinta();


            if (m.GetTipo() == "SOTA" && tipo != "SOTA" && tipo != "REY" && tipo != "CABALLO")
            {
                if (m.GetPinta() == pinta)
                        return true;
            }
            if (m.GetTipo() == "REY" && tipo == "SOTA")
            {
                if (m.GetPinta() == pinta)
                        return true;
            }
            return false;
        }

        public int CalculoMano(Carta vira)
        {
            string ap = mano[0].GetPinta();
            string bp = mano[1].GetPinta();
            string cp = mano[2].GetPinta();
            int ai = mano[0].GetIndice();
            int bi = mano[1].GetIndice();
            int ci = mano[2].GetIndice();
            Boolean Po = Perico(vira);
            Boolean Pa = Perica(vira);

            if (Flor(vira) == false)
            {
                if (Po == false && Pa == false)
                {
                    if (Doble() == true)
                    {
                        if (ap == bp)
                            return ai + bi + 20;
                        else if (ap == cp)
                            return ai + ci + 20;
                        else if (bp == cp)
                            return bi + ci + 20;
                    }
                    else
                        return Mayor();
                }
                else if (Po == true && Pa == false)
                {
                    return Mayor() + 30;
                }
                else if (Po == false && Pa == true)
                {
                    return Mayor() + 29;
                }
                else
                {
                    return 29 + 30 + Mayor();
                }
            }
            else if (Flor(vira) == true && !(Po == true && Pa == true))
            {
                return ai + bi + ci + 20;
            }
            else if (Flor(vira) == true && Po == true && Pa == true)
                return 29 + 30 + Mayor();
            return 0;
        }

        //Calcula cuantos puntos hay en la mano segun ENVIDO o Flor (segun lo que se tenga)
    }
}
