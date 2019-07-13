using System;
using System.Collections.Generic;
using System.Text;

namespace Truco
{
    class Game
    {
        public Jugador j1 { get; set; }
        public Jugador j2 { get; set; }

        public Mazo mazo;
        public int ptsA;
        public int ptsB;

        public Game(string nombreJ1, char e1, string nombreJ2, char e2, int i)
        {
            j1 = new Jugador(nombreJ1, e1);
            j2 = new Jugador(nombreJ2, e2);
            ptsA = 0;
            ptsB = 0;
            if (i == 0)
                mazo = new Mazo();
        }
        public void Repartir2J()
        {
            for (int i = 0; i < 3; i++)
            {
                j1.SetUpMano(mazo.GetCarta(i*2), i);
                j2.SetUpMano(mazo.GetCarta(i*2 + 1), i);
            }
        }
        public string SimulacionPlay2()
        {
            while (ptsA != 2 && ptsB != 2)
            {
                j1.ResetPuntos();
                j2.ResetPuntos();
                while (j1.Ganador() == false && j2.Ganador() == false)
                {
                    Truco();
                    mazo.RevolverDeck();
                }
                if (j1.Ganador() == true)
                {
                    ptsA++;
                    Console.WriteLine(String.Concat("Ronda ganada ", j1.nombre));
                }
                else
                {
                    ptsB++;
                    Console.WriteLine(String.Concat("Ronda ganada ", j2.nombre));
                }
            }
            if (ptsA == 2)
                return String.Concat("El ganador de este juego fue ", j1.GetNombre(), " FELICIDADES");
            else
                return String.Concat("El ganador de este juego fue ", j2.GetNombre(), " FELICIDADES");
        }
        public void Truco()
        {
            Random r = new Random();
            int pt1 = 0;
            int pt2 = 0;
            int pt = 1;
            Carta vira = mazo.GetCarta(39);
            Repartir2J();
            int _ValorCartaMesaj1 = 0;
            int _ValorCartaMesaj2 = 0;


            if (r.Next(0, 1) == 0)
                j1.SetMesa(true);
            else
                j2.SetMesa(true);

            _ValorCartaMesaj1 = j1.MayorV();
            j1.CartaManoUsada(j1.IdMayorV());
            _ValorCartaMesaj2 = j2.MayorV();
            j2.CartaManoUsada(j2.IdMayorV());

            if (_ValorCartaMesaj1 > _ValorCartaMesaj2)
            {
                pt1++;
                Console.WriteLine(String.Concat("jugador 1 gano con: ", j1.GetCartaMano(j1.IdMayorV()).GetTipo(), " de ", j1.GetCartaMano(j1.IdMayorV()).GetPinta(), " a ", j2.GetCartaMano(j2.IdMayorV()).GetTipo(), " de ", j2.GetCartaMano(j2.IdMayorV()).GetPinta()));
            }

            else if (_ValorCartaMesaj1 < _ValorCartaMesaj2)
            {
                pt2++;
                Console.WriteLine(String.Concat("jugador 2 gano con: ", j2.GetCartaMano(j2.IdMayorV()).GetTipo(), " de ", j2.GetCartaMano(j2.IdMayorV()).GetPinta(), " a ", j1.GetCartaMano(j1.IdMayorV()).GetTipo(), " de ", j1.GetCartaMano(j1.IdMayorV()).GetPinta()));
            }

            else
            {
                pt1++;
                pt2++;
                Console.WriteLine(String.Concat("empate con ", j1.GetCartaMano(j1.IdMayorV()).GetTipo(), " de ", j1.GetCartaMano(j1.IdMayorV()).GetPinta(), " a ", j2.GetCartaMano(j2.IdMayorV()).GetTipo(), " de ", j2.GetCartaMano(j2.IdMayorV()).GetPinta()));
            }

            _ValorCartaMesaj1 = j1.MedioV();
            j1.CartaManoUsada(j1.IdMedioV());
            _ValorCartaMesaj2 = j2.MedioV();
            j2.CartaManoUsada(j2.IdMedioV());

            if (_ValorCartaMesaj1 > _ValorCartaMesaj2)
            {
                pt1++;
                Console.WriteLine(String.Concat("jugador 1 gano con: ", j1.GetCartaMano(j1.IdMedioV()).GetTipo(), " de ", j1.GetCartaMano(j1.IdMedioV()).GetPinta(), " a ", j2.GetCartaMano(j2.IdMedioV()).GetTipo(), " de ", j2.GetCartaMano(j2.IdMedioV()).GetPinta()));
            }
            else if (_ValorCartaMesaj1 < _ValorCartaMesaj2)
            {
                pt2++;
                Console.WriteLine(String.Concat("jugador 2 gano con: ", j2.GetCartaMano(j2.IdMedioV()).GetTipo(), " de ", j2.GetCartaMano(j2.IdMedioV()).GetPinta(), " a ", j1.GetCartaMano(j1.IdMedioV()).GetTipo(), " de ", j1.GetCartaMano(j1.IdMedioV()).GetPinta()));
            }
            else
            {
                pt1++;
                pt2++;
                Console.WriteLine(String.Concat("empate con ", j1.GetCartaMano(j1.IdMedioV()).GetTipo(), " de ", j1.GetCartaMano(j1.IdMedioV()).GetPinta(), " a ", j2.GetCartaMano(j2.IdMedioV()).GetTipo(), " de ", j2.GetCartaMano(j2.IdMedioV()).GetPinta()));
            }

            if (pt1 == 2 && pt1 != pt2)
            {
                j1.AddPuntos(pt);
                Console.WriteLine(String.Concat("Punto para ", j1.nombre));
            }
            else if (pt2 == 2 && pt1 != pt2)
            {
                j2.AddPuntos(pt);
                Console.WriteLine(String.Concat("Punto para ", j2.nombre));
            }

            else
            {

                _ValorCartaMesaj1 = j1.MenorV();
                j1.CartaManoUsada(j1.IdMenorV());
                _ValorCartaMesaj2 = j2.MenorV();
                j1.CartaManoUsada(j2.IdMenorV());

                if (_ValorCartaMesaj1 > _ValorCartaMesaj2)
                {
                    pt1++;
                    Console.WriteLine(String.Concat("jugador 1 gano con: ", j1.GetCartaMano(j1.IdMenorV()).GetTipo(), " de ", j1.GetCartaMano(j1.IdMenorV()).GetPinta(), " a ", j2.GetCartaMano(j2.IdMenorV()).GetTipo(), " de ", j2.GetCartaMano(j2.IdMenorV()).GetPinta()));
                }
                else if (_ValorCartaMesaj1 < _ValorCartaMesaj2)
                {
                    pt2++;
                    Console.WriteLine(String.Concat("jugador 2 gano con: ", j2.GetCartaMano(j2.IdMenorV()).GetTipo(), " de ", j2.GetCartaMano(j2.IdMenorV()).GetPinta(), " a ", j1.GetCartaMano(j1.IdMenorV()).GetTipo(), " de ", j1.GetCartaMano(j1.IdMenorV()).GetPinta()));
                }
                else
                {
                    pt1++;
                    pt2++;
                    Console.WriteLine(String.Concat("empate con ", j1.GetCartaMano(j1.IdMenorV()).GetTipo(), " de ", j1.GetCartaMano(j1.IdMenorV()).GetPinta(), " a ", j2.GetCartaMano(j2.IdMenorV()).GetTipo(), " de ", j2.GetCartaMano(j2.IdMenorV()).GetPinta()));
                }
                if (pt1 > pt2)
                {
                    j1.AddPuntos(pt);
                    Console.WriteLine(String.Concat("Punto para ", j1.nombre));
                }
                else if (pt2 > pt1)
                {
                    j2.AddPuntos(pt);
                    Console.WriteLine(String.Concat("Punto para ", j2.nombre));
                }
                else
                {
                    if (j1.GetMesa() == true)
                    {
                        j1.AddPuntos(pt);
                        j1.SetMesa(false);
                        Console.WriteLine(String.Concat("Punto para ", j1.nombre));
                    }
                    else
                    {
                        j2.AddPuntos(pt);
                        j2.SetMesa(false);
                        Console.WriteLine(String.Concat("Punto para ", j2.nombre));
                    }
                }
            }
            j1.ResetManoUsada();
            j2.ResetManoUsada();
        }

    }

}
