using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Truco
{
    class Conector
    {
        private string userID;

        public string USID { get { return userID; } set { userID = value; } }

        string dataO = string.Empty; //origen
        string dataD = string.Empty; //destino
        string dataA = string.Empty; //accion
        string dataN = string.Empty; //numero
        string dataP = string.Empty; //pinta
        string dataT = string.Empty; //tipo


        public void Control(string data)
        {
            Flush(ref dataO, ref dataD, ref dataA, ref dataN, ref dataP, ref dataT);
            RepartirData(data, ref dataO, ref dataD, ref dataA, ref dataN, ref dataP, ref dataT);
        }

        public void Flush(ref String dataO, ref String dataD, ref String dataA, ref String dataN, ref String dataP, ref String dataT)
        {
            dataO = string.Empty;
            dataD = string.Empty;
            dataA = string.Empty;
            dataN = string.Empty;
            dataP = string.Empty;
            dataT = string.Empty;
        }
        public void RepartirData(string data, ref string dataO, ref string dataD, ref string dataA, ref string dataN, ref string dataP, ref string dataT)
        {
            int comp = 0;
            foreach (char c in data.ToCharArray())
            {
                ++comp;
                if (comp == 1)                        //Llena los bits de jugador origen 
                {                                     
                    dataO += c;                       
                }                                     
                else if (comp == 2)                   //Llena los bits de jugador destino
                {                                     
                    dataD += c;                       
                }                                     
                else if (comp >= 3 && comp < 6)       //Llena los bits de accion
                {                                     
                    dataA += c;                       
                }                                     
                else if (comp >= 6 && comp < 8)       //Llena los bits de Numero
                {                                     
                    dataN += c;                       
                }                                     
                else if (comp >= 8 && comp < 10)      //Llena los bits de pinta
                {                                     
                    dataP += c;                       
                }                                     
                else if (comp >= 10 && comp < 17)     //Llena los bits de tipo
                {
                    dataT += c;
                }
            }

        }
        public string JugadorO(string dataO)
        {
            switch (dataO)
            {
                case "0":
                    return "Jugador 1";
                case "1":
                    return "Jugador 2";
            }
            return "Jugador Invalido"; //error
        }
        public string JugadorD(string dataD)
        {
            switch (dataD)
            {
                case "0":
                    return "Jugador 1";
                case "1":
                    return "Jugador 2";
            }
            return "Jugador Invalido"; //error
        }
        public int Accion(string dataA)
        {
            switch (dataA)
            {
                case "000":
                    return 1; //Lanzar carta
                case "001":
                    return 2; //Proponer apuesta
                case "010":
                    return 3; //Aceptar apuesta
                case "011":
                    return 4; //Cancelar apuesta
                case "100":
                    return 5; //Irse al mazo
                case "101":
                    return 6; //Repartir carta para mano
            }
            return 0; // error
        }

        public int Numero(string dataN)
        {
            switch (dataN)
            {
                case "00":
                    return 0; //Carta0 de la mano/Envido
                case "01":
                    return 1; //Carta1 de la mano/Truco
                case "10":
                    return 2; //Carta2 de la mano/flor
                case "11":
                    return 3; //vira/retirarse
            }
            return 4; // error
        }

        public String Pinta(string dataP)
        {
            string[] _Pinta = new string[] { "COPA", "BASTO", "ESPADA", "ORO" };
            switch (dataP)
            {
                case "00":
                    return _Pinta[0]; //copa
                case "01":
                    return _Pinta[1]; //basto
                case "10":
                    return _Pinta[2]; //espada
                case "11":
                    return _Pinta[3]; //oro
            }
            return " ";
        }

        public String Tipo(string dataT)
        {
            string[] _Tipo = new string[] { "AS", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "SOTA", "CABALLO", "REY" };
            switch (dataT)
            {
                case "0000000":
                    return _Tipo[0];
                case "0000001":  
                    return _Tipo[1];
                case "0000010":  
                    return _Tipo[2];
                case "0000011":  
                    return _Tipo[3];
                case "0000100":
                    return _Tipo[4];
                case "0000101":
                    return _Tipo[5];
                case "0000110":
                    return _Tipo[6];
                case "0000111":
                    return _Tipo[7];
                case "0001000":
                    return _Tipo[8];
                case "0001001":
                    return _Tipo[9];
            }
            return " ";
        }

        public string getDataO()
        {
            return dataO;
        }

        public string getDataD()
        {
            return dataD;
        }

        public string getDataA()
        {
            return dataA;
        }

        public string getDataN()
        {
            return dataN;
        }

        public string getDataP()
        {
            return dataP;
        }

        public string getDataT()
        {
            return dataT;
        }
    }
}
