using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace Truco
{
    public partial class Form1 : Form
    {
        private int Id;
        Mazo mazo;
        Carta j1c = new Carta();
        Carta j2c = new Carta();
        Carta vira = new Carta();
        public int ptsA; 
        public int ptsB;
        public int ptsj1;
        public int ptsj2;
        public int ptsT;
        public int ptsE;
        Conector connector = new Conector();
        Jugador j1 { get; set; }
        Jugador j2 { get; set; }
        String TramaIn;
        String TramaOut;

        public Form1(int i, String NombrePort)
        {
            InitializeComponent();
            this.Id = i;
            try
            {
                serialPort1.PortName = NombrePort;
                serialPort1.BaudRate = Convert.ToInt32("9600");
                serialPort1.DataBits = Convert.ToInt32("8");
                serialPort1.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connector.USID = Convert.ToString(Id);
            j1 = new Jugador("Jugador 1", 'A');
            j2 = new Jugador("Jugador 2", 'B');
            j1.SetMesa(true);
            ptsA = 0;
            ptsB = 0;
            if (Id == 0)
            {
                this.Text = j1.GetNombre();
                mazo = new Mazo();
            }
            if (Id == 1)
            {
                this.Text = j2.GetNombre();
                Escuchar();  //bloquea el juego
            }


        }

        public void Escuchar()
        {
            Card0.Enabled = false;
            Card1.Enabled = false;
            Card2.Enabled = false;
            MazoB.Enabled = false;
            EnvidoB.Enabled = false;
            TrucoB.Enabled = false;
            RendirseB.Enabled = false;
        }

        public void Turno()
        {
            Card0.Enabled = true;
            Card1.Enabled = true;
            Card2.Enabled = true;
            EnvidoB.Enabled = true;
            TrucoB.Enabled = true;
            RendirseB.Enabled = true;
        }

        private void Mazo_Click(object sender, EventArgs e)
        {
            MazoB.Enabled = false;
            ReinicioRonda();
            RepartirCartas();
            if (Id == 0)
            {
                this.Card0.ImageKey = String.Concat(j1.GetCartaMano(0).GetTipo(), "_", j1.GetCartaMano(0).GetPinta(), ".jpg");
                this.Card1.ImageKey = String.Concat(j1.GetCartaMano(1).GetTipo(), "_", j1.GetCartaMano(1).GetPinta(), ".jpg");
                this.Card2.ImageKey = String.Concat(j1.GetCartaMano(2).GetTipo(), "_", j1.GetCartaMano(2).GetPinta(), ".jpg");
                this.Vira.ImageKey = String.Concat(vira.GetTipo(), "_", vira.GetPinta(), ".jpg");
                Card0.Visible = true;
                Card1.Visible = true;
                Card2.Visible = true;
                Vira.Visible = true;
                EnvidoB.Visible = true;
                TrucoB.Visible = true;
                RendirseB.Visible = true;
            }

            if (j1.GetMesa() == false)
                Escuchar();
            else Turno();
        }

        public void ReinicioRonda()
        {
            ptsj1 = 0;
            ptsj2 = 0;
            ptsT = 1;
            ptsE = 1;
            MyTruco.Text = String.Concat(0);
            EnemyTruco.Text = String.Concat(0);
            Enemy.Visible = false;
            Mine.Visible = false;
            j1c.SetCarta(" ", " ");
            j2c.SetCarta(" ", " ");
            this.Card0.Visible = false;
            this.Card1.Visible = false;
            this.Card2.Visible = false;
            this.EnvidoB.Visible = false;
            this.TrucoB.Visible = false;
            this.RendirseB.Visible = false;
        }
        public void ReinicioPartida()
        {
            if (Id == 0)
                MazoB.Enabled = true;
            else
                Escuchar();
            ReinicioRonda();
            j1.ResetPuntos();
            j2.ResetPuntos();
            MyPts.Text = String.Concat(0);
            EnemyPts.Text = String.Concat(0);
        }

        public void RepartirCartas()
        {
            mazo = new Mazo();
            for (int i = 0; i < 3; i++)
            {
                j1.SetUpMano(mazo.deck[i*2 + 0], i);
                j2.SetUpMano(mazo.deck[i*2 + 1], i);

            }
            vira = mazo.deck[39];
            EnviarMano();
        }

        public void EnviarMano()
        {
            TramaOut = String.Concat('0', '1', "110", "00", PintaBit(j1.GetCartaMano(0).GetPinta()), TipoBit(j1.GetCartaMano(0).GetTipo()));
            serialPort1.WriteLine(TramaOut);
            Thread.Sleep(50);
            TramaOut = String.Concat('0', '1', "110", "01", PintaBit(j1.GetCartaMano(1).GetPinta()), TipoBit(j1.GetCartaMano(1).GetTipo()));
            serialPort1.WriteLine(TramaOut);
            Thread.Sleep(50);
            TramaOut = String.Concat('0', '1', "110", "10", PintaBit(j1.GetCartaMano(2).GetPinta()), TipoBit(j1.GetCartaMano(2).GetTipo()));
            serialPort1.WriteLine(TramaOut);
            Thread.Sleep(50);

            TramaOut = String.Concat('0', '1', "101", "00", PintaBit(j2.GetCartaMano(0).GetPinta()), TipoBit(j2.GetCartaMano(0).GetTipo()));
            serialPort1.WriteLine(TramaOut);
            Thread.Sleep(500);
            TramaOut = String.Concat('0', '1', "101", "01", PintaBit(j2.GetCartaMano(1).GetPinta()), TipoBit(j2.GetCartaMano(1).GetTipo()));
            serialPort1.WriteLine(TramaOut);
            Thread.Sleep(500);
            TramaOut = String.Concat('0', '1', "101", "10", PintaBit(j2.GetCartaMano(2).GetPinta()), TipoBit(j2.GetCartaMano(2).GetTipo()));
            serialPort1.WriteLine(TramaOut);
            Thread.Sleep(500);
            TramaOut = String.Concat('0', '1', "101", "11", PintaBit(vira.GetPinta()), TipoBit(vira.GetTipo()));
            serialPort1.WriteLine(TramaOut);
        }


        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            TramaIn = serialPort1.ReadLine();
            this.Invoke(new EventHandler(ShowData));
        }

        private void ShowData(object sender, EventArgs e)
        {
            connector.Control(TramaIn);
            Carta c = new Carta();
            if (TramaIn.Length >= 16)
            {
                if (connector.getDataD() == connector.USID)
                {
                    switch (connector.getDataA())
                    {
                            case "000":       //Lanzaron carta
                            MensajeL.Visible = false;
                            c.SetCarta(connector.Tipo(connector.getDataT()), connector.Pinta(connector.getDataP()));
                                switch (connector.getDataO())
                                { 
                                    case "0":
                                        j1c = c;
                                        this.Enemy.ImageKey = String.Concat(j1c.GetTipo(), "_", j1c.GetPinta(), ".jpg");
                                        this.Enemy.Visible = true;
                                        break;
                                    case "1":
                                        j2c = c;
                                        this.Enemy.ImageKey = String.Concat(j2c.GetTipo(), "_", j2c.GetPinta(), ".jpg");
                                        Enemy.Visible = true;
                                        break;
                                }
                                if (j1c.GetValor() == 0 || j2c.GetValor() == 0) // si el otro jugador no ha tirado, espero a que la tire
                                {
                                    Mine.Visible = false;
                                    Turno();
                                }
                                else
                                {
                                    Boolean final = Combate();
                                    if (final == false)
                                        Escuchar();
                                    else
                                    {
                                        if (Id == 0)
                                            MazoB.Enabled = true;
                                        else
                                            Escuchar();

                                        if (GanadorPartida() == true)
                                        {
                                            ReinicioPartida();
                                            if (ptsA == 2)
                                                Terminar();
                                            if (ptsB == 2)
                                                Terminar();
                                        }
                                    }
                                }
                                break;
                            case "001":       //Recibir apuesta
                                this.MensajeL.Visible = true;
                                this.AceptoB.Visible = true;
                                this.RechazoB.Visible = true;
                                this.ElevoB.Visible = true;
                                switch (connector.getDataN())
                                {
                                    case "00":
                                        this.MensajeL.Text = "Propuesta Envido";
                                        this.EnvidoB.Visible = false;
                                        break;
                                    case "01":
                                        this.MensajeL.Text = "Propuesta Truco";
                                        this.TrucoB.Visible = false;
                                        break;
                                    case "10":
                                        ptsE = ptsE + 1;
                                        this.MensajeL.Text = "Elevar Envido a: 3";
                                        if (ptsE == 3)
                                        {
                                            if (j1.GetPuntos() >= j2.GetPuntos())
                                                this.MensajeL.Text = String.Concat("Elevar Envido a: ", 24 - j1.GetPuntos());
                                            else
                                                this.MensajeL.Text = String.Concat("Elevar Envido a: ", 24 - j2.GetPuntos());
                                            this.ElevoB.Visible = false;
                                        }
                                        break;
                                    case "11":
                                        ptsT = ptsT * 3;
                                        this.MensajeL.Text = "Elevar Truco a: 9";
                                        if (ptsT == 9)
                                        {
                                            this.MensajeL.Text = "Truco vale todo";
                                            this.ElevoB.Visible = false;
                                        }
                                        break;
                                }
                                    break;
                            case "010":       //Aceptaron apuesta
                            switch (connector.getDataN())
                            {
                                case "00":
                                    MensajeL.Visible = true;
                                    if (j1.CalculoMano(vira) > j2.CalculoMano(vira))
                                    {
                                        j1.AddPuntos(ptsE);
                                        MensajeL.Text = String.Concat(j1.CalculoMano(vira), " > ", j2.CalculoMano(vira));
                                    }
                                    else if (j1.CalculoMano(vira) < j2.CalculoMano(vira))
                                    {
                                        j2.AddPuntos(ptsE);
                                        MensajeL.Text = String.Concat(j1.CalculoMano(vira), " < ", j2.CalculoMano(vira));
                                    }
                                    else
                                    {
                                        MensajeL.Text = String.Concat(j1.CalculoMano(vira), " = ", j2.CalculoMano(vira));
                                        if (j1.GetMesa() == true)
                                            j1.AddPuntos(ptsE);
                                        else
                                            j2.AddPuntos(ptsE);
                                    }
                                    if (Id == 0)
                                    {
                                        MyPts.Text = String.Concat(j1.GetPuntos());
                                        EnemyPts.Text = String.Concat(j2.GetPuntos());
                                    }
                                    else
                                    {
                                        MyPts.Text = String.Concat(j2.GetPuntos());
                                        EnemyPts.Text = String.Concat(j1.GetPuntos());
                                    }
                                    if (GanadorPartida() == true)
                                    {
                                        ReinicioPartida();
                                        if (ptsA == 2 || ptsB == 2)
                                            Terminar();
                                    }
                                    Turno();
                                    this.EnvidoB.Visible = false;
                                    break;
                                case "01":
                                    ptsT = ptsT * 3;
                                    this.TrucoB.Visible = false;
                                    Turno();
                                    break;
                                case "10":
                                    if (ptsE == 2)
                                    {
                                        ptsE = ptsE + 1;
                                        Escuchar();
                                    }
                                    else if (ptsE == 3)
                                    {
                                        if (j1.GetPuntos() >= j2.GetPuntos())
                                            ptsE = 24 - j1.GetPuntos();
                                        else
                                            ptsE = 24 - j2.GetPuntos();
                                        Turno();
                                    }

                                    if (j1.CalculoMano(vira) > j2.CalculoMano(vira))
                                    {
                                        j1.AddPuntos(ptsE);
                                        MensajeL.Text = String.Concat(j1.CalculoMano(vira), " > ", j2.CalculoMano(vira));
                                    }
                                    else if (j1.CalculoMano(vira) < j2.CalculoMano(vira))
                                    {
                                        j2.AddPuntos(ptsE);
                                        MensajeL.Text = String.Concat(j1.CalculoMano(vira), " < ", j2.CalculoMano(vira));
                                    }
                                    else
                                    {
                                        MensajeL.Text = String.Concat(j1.CalculoMano(vira), " = ", j2.CalculoMano(vira));
                                        if (j1.GetMesa() == true)
                                            j1.AddPuntos(ptsE);
                                        else
                                            j2.AddPuntos(ptsE);
                                    }

                                    if (Id == 0)
                                    {
                                        MyPts.Text = String.Concat(j1.GetPuntos());
                                        EnemyPts.Text = String.Concat(j2.GetPuntos());
                                    }
                                    else
                                    {
                                        MyPts.Text = String.Concat(j2.GetPuntos());
                                        EnemyPts.Text = String.Concat(j1.GetPuntos());
                                    }

                                    if (GanadorPartida() == true)
                                    {
                                        ReinicioPartida();
                                        if (ptsA == 2 || ptsB == 2)
                                            Terminar();
                                    }
                                    break;
                                case "11":
                                    ptsT = ptsT * 3;
                                    if (ptsT == 9)
                                        Escuchar();
                                    if (ptsT == 27)
                                        Turno();
                                    break;
                            }

                            break;
                            case "011":       //Cancelaron apuesta
                                switch (connector.getDataN())
                                {
                                    case "00":
                                        if (Id == 0)
                                        {
                                            j1.AddPuntos(ptsE);
                                            MyPts.Text = String.Concat(j1.GetPuntos());
                                            EnemyPts.Text = String.Concat(j2.GetPuntos());
                                        }
                                        else
                                        {
                                            j2.AddPuntos(ptsE);
                                            MyPts.Text = String.Concat(j2.GetPuntos());
                                            EnemyPts.Text = String.Concat(j1.GetPuntos());
                                        }
                                        if (GanadorPartida() == true)
                                        {
                                            ReinicioPartida();
                                            if (ptsA == 2 || ptsB == 2)
                                                Terminar();
                                        }
                                    Turno();
                                        break;
                                    case "01":
                                        if (Id == 0)
                                        {
                                            j1.AddPuntos(ptsT);
                                            MyPts.Text = String.Concat(j1.GetPuntos());
                                            EnemyPts.Text = String.Concat(j2.GetPuntos());
                                            MazoB.Enabled = true;
                                        }
                                        if (Id == 1)
                                        {
                                            j2.AddPuntos(ptsT);
                                            MyPts.Text = String.Concat(j2.GetPuntos());
                                            EnemyPts.Text = String.Concat(j1.GetPuntos());
                                            Escuchar();
                                        }
                                        if (GanadorPartida() == true)
                                        {
                                            ReinicioPartida();
                                            if (ptsA == 2 || ptsB == 2)
                                                Terminar();
                                        }
                                        AlterMesa();
                                        ReinicioRonda();
                                        break;
                                    case "10":
                                        if (Id == 0)
                                        {
                                            j1.AddPuntos(ptsE);
                                            MyPts.Text = String.Concat(j1.GetPuntos());
                                            EnemyPts.Text = String.Concat(j2.GetPuntos());
                                        }
                                        else
                                        {
                                            j2.AddPuntos(ptsE);
                                            MyPts.Text = String.Concat(j2.GetPuntos());
                                            EnemyPts.Text = String.Concat(j1.GetPuntos());
                                        }

                                        if (GanadorPartida() == true)
                                        {
                                            ReinicioPartida();
                                            if (ptsA == 2 || ptsB == 2)
                                                Terminar();
                                        }
                                        if (ptsE == 2)
                                            Escuchar();
                                        if (ptsE == 3)
                                            Turno();
                                        break;
                                    case "11":
                                        if (Id == 0)
                                        {
                                            j1.AddPuntos(ptsT);
                                            MyPts.Text = String.Concat(j1.GetPuntos());
                                            EnemyPts.Text = String.Concat(j2.GetPuntos());
                                            MazoB.Enabled = true;
                                        }
                                        if (Id == 1)
                                        {
                                            j2.AddPuntos(ptsT);
                                            MyPts.Text = String.Concat(j2.GetPuntos());
                                            EnemyPts.Text = String.Concat(j1.GetPuntos());
                                            Escuchar();
                                        }
                                        if (GanadorPartida() == true)
                                        {
                                            ReinicioPartida();
                                            if (ptsA == 2 || ptsB == 2)
                                                Terminar();
                                        }
                                        AlterMesa();
                                        ReinicioRonda();
                                        break;
                                }
                                    break;
                            case "100":       //Se fueron al mazo
                                if (Id == 0)
                                {
                                    j1.AddPuntos(ptsT);
                                    MyPts.Text = String.Concat(j1.GetPuntos());
                                    EnemyPts.Text = String.Concat(j2.GetPuntos());
                                    MazoB.Enabled = true;
                                }
                                if (Id == 1)
                                {
                                    j2.AddPuntos(ptsT);
                                    MyPts.Text = String.Concat(j2.GetPuntos());
                                    EnemyPts.Text = String.Concat(j1.GetPuntos());
                                    Escuchar();
                                }

                                if (GanadorPartida() == true)
                                {
                                    ReinicioPartida();
                                    if (ptsA == 2 || ptsB == 2)
                                        Terminar();
                                }

                                AlterMesa();
                                ReinicioRonda();

                                break;
                            case "101":       //Repartir carta para mano
                                c.SetCarta(connector.Tipo(connector.getDataT()), connector.Pinta(connector.getDataP()));
                                switch (connector.getDataN())
                                {
                                    case "00":
                                        ReinicioRonda();
                                        j2.SetUpMano(c, 0);
                                        this.Card0.ImageKey = String.Concat(j2.GetCartaMano(0).GetTipo(), "_", j2.GetCartaMano(0).GetPinta(), ".jpg");
                                        this.Card0.Visible = true;
                                        this.Card0.Enabled = false;
                                        break;
                                    case "01":
                                        j2.SetUpMano(c, 1);
                                        this.Card1.ImageKey = String.Concat(j2.GetCartaMano(1).GetTipo(), "_", j2.GetCartaMano(1).GetPinta(), ".jpg");
                                        this.Card1.Visible = true;
                                        this.Card1.Enabled = false;
                                        break;
                                    case "10":
                                        j2.SetUpMano(c, 2);
                                        this.Card2.ImageKey = String.Concat(j2.GetCartaMano(2).GetTipo(), "_", j2.GetCartaMano(2).GetPinta(), ".jpg");
                                        this.Card2.Visible = true;
                                        this.Card2.Enabled = false;
                                        break;
                                    case "11":
                                        vira = c;
                                        this.Vira.ImageKey = String.Concat(vira.GetTipo(), "_", vira.GetPinta(), ".jpg");
                                        this.Vira.Visible = true;
                                        this.EnvidoB.Visible = true;
                                        this.TrucoB.Visible = true;
                                        this.RendirseB.Visible = true;
                                        if (j2.GetMesa() == false)
                                            Escuchar();
                                        else Turno();
                                        break;
                                }
                                break;
                            case "110":       //Repartir carta para mano J1
                                c.SetCarta(connector.Tipo(connector.getDataT()), connector.Pinta(connector.getDataP()));
                                switch (connector.getDataN())
                                {
                                    case "00":
                                        j1.SetUpMano(c, 0);
                                        break;
                                    case "01":
                                        j1.SetUpMano(c, 1);
                                        break;
                                    case "10":
                                        j1.SetUpMano(c, 2);
                                        break;
                                }
                                break;
                    }
                }
            }
            else
                MessageBox.Show("Trema incompleta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        public String PintaBit(string dataP)
        {
            switch (dataP)
            {
                case "COPA":
                    return "00"; //copa
                case "BASTO":
                    return "01"; //basto
                case "ESPADA":
                    return "10"; //espada
                case "ORO":
                    return "11"; //oro
            }
            return " ";
        }
        public String TipoBit(string dataT)
        {
            switch (dataT)
            {
                case "AS":
                    return "0000000";
                case "DOS":
                    return "0000001";
                case "TRES":
                    return "0000010";
                case "CUATRO":
                    return "0000011";
                case "CINCO":
                    return "0000100";
                case "SEIS":
                    return "0000101";
                case "SIETE":
                    return "0000110";
                case "SOTA":
                    return "0000111";
                case "CABALLO":
                    return "0001000";
                case "REY":
                    return "0001001";
            }
            return " ";
        }

        private void Card0_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                j1c = j1.GetCartaMano(0);
                this.Mine.ImageKey = String.Concat(j1c.GetTipo(), "_", j1c.GetPinta(), ".jpg");
            }
            if (Id == 1)
            {
                j2c = j2.GetCartaMano(0);
                this.Mine.ImageKey = String.Concat(j2c.GetTipo(), "_", j2c.GetPinta(), ".jpg");
            }
            this.Card0.Visible = false;
            this.Mine.Visible = true;
            EnviarCarta();
        }

        private void Card1_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                j1c = j1.GetCartaMano(1);
                this.Mine.ImageKey = String.Concat(j1c.GetTipo(), "_", j1c.GetPinta(), ".jpg");
            }
            if (Id == 1)
            {
                j2c = j2.GetCartaMano(1);
                this.Mine.ImageKey = String.Concat(j2c.GetTipo(), "_", j2c.GetPinta(), ".jpg");
            }
            this.Card1.Visible = false;
            this.Mine.Visible = true;
            EnviarCarta();
        }

        private void Card2_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                j1c = j1.GetCartaMano(2);
                this.Mine.ImageKey = String.Concat(j1c.GetTipo(), "_", j1c.GetPinta(), ".jpg");
            }
            if (Id == 1)
            {
                j2c = j2.GetCartaMano(2);
                this.Mine.ImageKey = String.Concat(j2c.GetTipo(), "_", j2c.GetPinta(), ".jpg");
            }
            this.Card2.Visible = false;
            this.Mine.Visible = true;
            EnviarCarta();
        }

        public void EnviarCarta()
        {
            MensajeL.Visible = false;
            if (Id == 0)
                TramaOut = String.Concat('0', '1', "000", "00", PintaBit(j1c.GetPinta()), TipoBit(j1c.GetTipo()));
            if (Id == 1)
                TramaOut = String.Concat('1', '0', "000", "00", PintaBit(j2c.GetPinta()), TipoBit(j2c.GetTipo()));
            serialPort1.WriteLine(TramaOut);
            if (j1c.GetValor() == 0 || j2c.GetValor() == 0) // si el otro jugador no ha tirado, espero a que la tire
            {
                Enemy.Visible = false;
                Escuchar();
            }
            else
            {
                Boolean final = Combate();
                if (final == false)
                    Turno();
                else
                {
                    if (Id == 0)
                    {
                        MazoB.Enabled = true;
                    }
                    else
                        Escuchar();

                    if (GanadorPartida() == true)
                    {
                        ReinicioPartida();
                        if (ptsA == 2 || ptsB == 2)
                            Terminar();
                    }
                }
            }
        }

        public Boolean Combate()
        {
            int _ValorCartaMesaj1 = j1c.GetValor();
            int _ValorCartaMesaj2 = j2c.GetValor();

            if (j1.Perico(vira, j1c) == true)
                _ValorCartaMesaj1 = 16;
            else if (j2.Perico(vira, j2c) == true)
                _ValorCartaMesaj2 = 16;

            if (j1.Perica(vira, j1c) == true)
                _ValorCartaMesaj1 = 15;
            else if (j2.Perica(vira, j2c) == true)
                _ValorCartaMesaj2 = 15;

            if (_ValorCartaMesaj1 > _ValorCartaMesaj2)
            {
                ptsj1++;
            }
            else if (_ValorCartaMesaj1 < _ValorCartaMesaj2)
            {
                ptsj2++;
            }
            else
            {
                ptsj1++;
                ptsj2++;
            }

            j1c.SetCarta(" ", " ");
            j2c.SetCarta(" ", " ");

            if (Id == 0)
            {
                MyTruco.Text = String.Concat(ptsj1);
                EnemyTruco.Text = String.Concat(ptsj2);
            }
            else
            {
                MyTruco.Text = String.Concat(ptsj2);
                EnemyTruco.Text = String.Concat(ptsj1);
            }

            if (ptsj1 >= 2 && ptsj1 != ptsj2)
            {
                j1.AddPuntos(ptsT);
                if (Id == 0)
                {
                    MyPts.Text = String.Concat(j1.GetPuntos());
                    EnemyPts.Text = String.Concat(j2.GetPuntos());
                }
                else
                {
                    MyPts.Text = String.Concat(j2.GetPuntos());
                    EnemyPts.Text = String.Concat(j1.GetPuntos());
                }
                AlterMesa();
                ReinicioRonda();
                return true;
            }
            else if (ptsj2 >= 2 && ptsj1 != ptsj2)
            {
                j2.AddPuntos(ptsT);
                if (Id == 0)
                {
                    MyPts.Text = String.Concat(j1.GetPuntos());
                    EnemyPts.Text = String.Concat(j2.GetPuntos());
                }
                else
                {
                    MyPts.Text = String.Concat(j2.GetPuntos());
                    EnemyPts.Text = String.Concat(j1.GetPuntos());
                }
                AlterMesa();
                ReinicioRonda();
                return true;
            }
            else if (ptsj1 == 3 && ptsj1 == ptsj2)
            {
                if (j1.GetMesa() == true)
                    j1.AddPuntos(ptsT);
                else
                    j2.AddPuntos(ptsT);

                if (Id == 0)
                {
                    MyPts.Text = String.Concat(j1.GetPuntos());
                    EnemyPts.Text = String.Concat(j2.GetPuntos());
                }
                else
                {
                    MyPts.Text = String.Concat(j2.GetPuntos());
                    EnemyPts.Text = String.Concat(j1.GetPuntos());
                }
                AlterMesa();
                ReinicioRonda();
                return true;
            }
            else if (ptsj1 == 2 && ptsj1 == ptsj2 && Card0.Visible == false && Card1.Visible == false && Card2.Visible == false)
            {
                if (j1.GetMesa() == true)
                    j1.AddPuntos(ptsT);
                else
                    j2.AddPuntos(ptsT);

                if (Id == 0)
                {
                    MyPts.Text = String.Concat(j1.GetPuntos());
                    EnemyPts.Text = String.Concat(j2.GetPuntos());
                }
                else
                {
                    MyPts.Text = String.Concat(j2.GetPuntos());
                    EnemyPts.Text = String.Concat(j1.GetPuntos());
                }
                AlterMesa();
                ReinicioRonda();
                return true;
            }
            return false;
        }

        public void AlterMesa()
        {
            if (j1.GetMesa() == true)
            {
                j1.SetMesa(false);
                j2.SetMesa(true);
            }
            else
            {
                j1.SetMesa(true);
                j2.SetMesa(false);
            }
            if (Id == 0)
                Turno();
            else
                Escuchar();
        }



        public Boolean GanadorPartida()
        {
            if(j1.Ganador() == true)
            {
                ptsA++;
                ReinicioPartida();
                if (Id == 0)
                {
                    MyMarcador.Text = String.Concat(ptsA);
                    EnemyMacarcador.Text = String.Concat(ptsB);
                }
                else
                {
                    EnemyMacarcador.Text = String.Concat(ptsA);
                    MyMarcador.Text = String.Concat(ptsB);
                }
                return true;
            }
            if (j2.Ganador() == true)
            {
                ptsB++;
                ReinicioPartida();
                if (Id == 0)
                {
                    MyMarcador.Text = String.Concat(ptsA);
                    EnemyMacarcador.Text = String.Concat(ptsB);
                }
                else
                {
                    EnemyMacarcador.Text = String.Concat(ptsA);
                    MyMarcador.Text = String.Concat(ptsB);
                }
                return true;
            }
            return false;
        }
        public void Terminar() // termina el juego posterior a tener un ganador
        {
            if (ptsA == 2)
            {
                if (Id == 0)
                {
                    MessageBox.Show("HAZ GANADO", "WON", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("HAZ PERDIDO", "LOOSER", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                this.Close();
            }
            else if(ptsB == 2)
            {
                if (Id == 0)
                {
                    MessageBox.Show("HAZ PERDIDO", "LOOSER", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("HAZ GANADO", "WON", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                this.Close();
            }
        }

        private void RendirseB_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                TramaOut = String.Concat('0', '1', "100", "00", "00", "0000000");
                j2.AddPuntos(ptsT);
                MyPts.Text = String.Concat(j1.GetPuntos());
                EnemyPts.Text = String.Concat(j2.GetPuntos());
                MazoB.Enabled = true;
            }
            if (Id == 1)
            {
                TramaOut = String.Concat('1', '0', "100", "00", "00", "0000000");
                j1.AddPuntos(ptsT);
                MyPts.Text = String.Concat(j2.GetPuntos());
                EnemyPts.Text = String.Concat(j1.GetPuntos());
                Escuchar();
            }
            serialPort1.WriteLine(TramaOut);

            if (GanadorPartida() == true)
            {
                ReinicioPartida();
                if (ptsA == 2 || ptsB == 2)
                    Terminar();
            }

            AlterMesa();
            ReinicioRonda();
        }

        private void EnvidoB_Click(object sender, EventArgs e)
        {
            if (Id == 0)
                TramaOut = String.Concat('0', '1', "001", "00", "00", "0000000");

            if (Id == 1)
                TramaOut = String.Concat('1', '0', "001", "00", "00", "0000000");

            this.EnvidoB.Visible = false;
            serialPort1.WriteLine(TramaOut);
            Escuchar();
        }

        private void TrucoB_Click(object sender, EventArgs e)
        {
            if (Id == 0)
                TramaOut = String.Concat('0', '1', "001", "01", "00", "0000000");

            if (Id == 1)
                TramaOut = String.Concat('1', '0', "001", "01", "00", "0000000");

            this.TrucoB.Visible = false;
            serialPort1.WriteLine(TramaOut);
            Escuchar();
        }

        private void RechazoB_Click(object sender, EventArgs e)
        {
            this.MensajeL.Visible = false;
            this.AceptoB.Visible = false;
            this.ElevoB.Visible = false;
            this.RechazoB.Visible = false;

            switch (connector.getDataN())
            {
                case "00": // rechazo envido
                    if (Id == 0)
                    {
                        TramaOut = String.Concat('0', '1', "011", "00", "00", "0000000");
                        j2.AddPuntos(ptsE);
                        MyPts.Text = String.Concat(j1.GetPuntos());
                        EnemyPts.Text = String.Concat(j2.GetPuntos());
                    }

                    if (Id == 1)
                    {
                        TramaOut = String.Concat('1', '0', "011", "00", "00", "0000000");
                        j1.AddPuntos(ptsE);
                        MyPts.Text = String.Concat(j2.GetPuntos());
                        EnemyPts.Text = String.Concat(j1.GetPuntos());
                    }
                    Escuchar();
                    break;

                case "01": //rechazo truco
                    if (Id == 0)
                    {
                        TramaOut = String.Concat('0', '1', "011", "01", "00", "0000000");
                        j2.AddPuntos(ptsT);
                        MyPts.Text = String.Concat(j1.GetPuntos());
                        EnemyPts.Text = String.Concat(j2.GetPuntos());
                        MazoB.Enabled = true;
                    }
                    if (Id == 1)
                    {
                        TramaOut = String.Concat('1', '0', "011", "01", "00", "0000000");
                        j1.AddPuntos(ptsT);
                        MyPts.Text = String.Concat(j2.GetPuntos());
                        EnemyPts.Text = String.Concat(j1.GetPuntos());
                        Escuchar();
                    }
                    if (GanadorPartida() == true)
                    {
                        ReinicioPartida();
                        if (ptsA == 2 || ptsB == 2)
                            Terminar();
                    }
                    AlterMesa();
                    ReinicioRonda();
                    break; 

                case "10": //rechazo elevar envido
                    if (Id == 0)
                    {
                        TramaOut = String.Concat('0', '1', "011", "10", "00", "0000000");
                        j2.AddPuntos(ptsE);
                        MyPts.Text = String.Concat(j1.GetPuntos());
                        EnemyPts.Text = String.Concat(j2.GetPuntos());
                    }
                    if (Id == 1)
                    {
                        TramaOut = String.Concat('1', '0', "011", "10", "00", "0000000");
                        j1.AddPuntos(ptsE);
                        MyPts.Text = String.Concat(j2.GetPuntos());
                        EnemyPts.Text = String.Concat(j1.GetPuntos());
                    }
                    if (ptsE == 2)
                        Turno();
                    if (ptsE == 3)
                        Escuchar();
                    break;
                case "11": //rechazo elevar truco
                    if (Id == 0)
                    {
                        TramaOut = String.Concat('0', '1', "011", "11", "00", "0000000");
                        j2.AddPuntos(ptsT);
                        MyPts.Text = String.Concat(j1.GetPuntos());
                        EnemyPts.Text = String.Concat(j2.GetPuntos());
                        MazoB.Enabled = true;
                    }
                    if (Id == 1)
                    {
                        TramaOut = String.Concat('1', '0', "011", "11", "00", "0000000");
                        j1.AddPuntos(ptsT);
                        MyPts.Text = String.Concat(j2.GetPuntos());
                        EnemyPts.Text = String.Concat(j1.GetPuntos());
                        Escuchar();
                    }
                    if (GanadorPartida() == true)
                    {
                        ReinicioPartida();
                        if (ptsA == 2 || ptsB == 2)
                            Terminar();
                    }
                    AlterMesa();
                    ReinicioRonda();
                    break;
            }
            serialPort1.WriteLine(TramaOut);

        }

        private void ElevoB_Click(object sender, EventArgs e)
        {
            this.MensajeL.Visible = false;
            this.AceptoB.Visible = false;
            this.ElevoB.Visible = false;
            this.RechazoB.Visible = false;
            switch (connector.getDataN())
            {
                case ("00"): // Elevar propuesta envido
                    ptsE++;
                    if (Id == 0)
                        TramaOut = String.Concat('0', '1', "001", "10", "00", "0000000");

                    if (Id == 1)
                        TramaOut = String.Concat('1', '0', "001", "10", "00", "0000000");
                    Escuchar();
                    break;

                case "01": // Elevar propuesta truco
                    ptsT = ptsT * 3;
                    if (Id == 0)
                        TramaOut = String.Concat('0', '1', "001", "11", "00", "0000000");

                    if (Id == 1)
                        TramaOut = String.Concat('1', '0', "001", "11", "00", "0000000");
                    Escuchar();
                    break;

                case "10": //// Elevar propuesta de elevar envido
                    ptsE = ptsE + 1;
                    if (Id == 0)
                        TramaOut = String.Concat('0', '1', "001", "10", "00", "0000000");
                    if (Id == 1)
                        TramaOut = String.Concat('1', '0', "001", "10", "00", "0000000");
                    Escuchar();
                    break;
                case "11": // Elevar propuesta de elevar envido
                    ptsT = ptsT * 3;
                    if (Id == 0)
                        TramaOut = String.Concat('0', '1', "001", "11", "00", "0000000");

                    if (Id == 1)
                        TramaOut = String.Concat('1', '0', "001", "11", "00", "0000000");
                    Escuchar();
                    break;
            }
            serialPort1.WriteLine(TramaOut);
        }

        private void AceptoB_Click(object sender, EventArgs e)
        {
            this.AceptoB.Visible = false;
            this.ElevoB.Visible = false;
            this.RechazoB.Visible = false;
            switch (connector.getDataN())
            {
                case ("00"): // aceptar propuesta envido
                    if (Id == 0)
                        TramaOut = String.Concat('0', '1', "010", "00", "00", "0000000");
                    if (Id == 1)
                        TramaOut = String.Concat('1', '0', "010", "00", "00", "0000000");
                    if (j1.CalculoMano(vira) > j2.CalculoMano(vira))
                    {
                        j1.AddPuntos(ptsE);
                        MensajeL.Text = String.Concat(j1.CalculoMano(vira), " > ", j2.CalculoMano(vira));
                    }
                    else if (j1.CalculoMano(vira) < j2.CalculoMano(vira))
                    {
                        j2.AddPuntos(ptsE);
                        MensajeL.Text = String.Concat(j1.CalculoMano(vira), " < ", j2.CalculoMano(vira));
                    }
                    else
                    {
                        MensajeL.Text = String.Concat(j1.CalculoMano(vira), " = ", j2.CalculoMano(vira));
                        if (j1.GetMesa() == true)
                            j1.AddPuntos(ptsE);
                        else
                            j2.AddPuntos(ptsE);
                    }
                    if (Id == 0)
                    {
                        MyPts.Text = String.Concat(j1.GetPuntos());
                        EnemyPts.Text = String.Concat(j2.GetPuntos());
                    }
                    else
                    {
                        MyPts.Text = String.Concat(j2.GetPuntos());
                        EnemyPts.Text = String.Concat(j1.GetPuntos());
                    }
                    if (GanadorPartida() == true)
                    {
                        ReinicioPartida();
                        if (ptsA == 2 || ptsB == 2)
                            Terminar();
                    }
                    Escuchar();
                    break;

                case "01": // aceptar propuesta truco
                    ptsT = ptsT * 3;
                    if (Id == 0)
                        TramaOut = String.Concat('0', '1', "010", "01", "00", "0000000");
                    if (Id == 1)
                        TramaOut = String.Concat('1', '0', "010", "01", "00", "0000000");
                    Escuchar();
                    break;

                case "10": //// aceptar propuesta de elevar envido
                    if (ptsE == 2)
                    {
                        ptsE = ptsE + 1;
                        Turno();
                    }
                    else if (ptsE == 3)
                    {
                        if (j1.GetPuntos() >= j2.GetPuntos())
                            ptsE = 24 - j1.GetPuntos();
                        else
                            ptsE = 24 - j2.GetPuntos();
                        Escuchar();
                    }

                    if (Id == 0)
                        TramaOut = String.Concat('0', '1', "010", "10", "00", "0000000");
                    if (Id == 1)
                        TramaOut = String.Concat('1', '0', "010", "10", "00", "0000000");

                    if (j1.CalculoMano(vira) > j2.CalculoMano(vira))
                    {
                        j1.AddPuntos(ptsE);
                        MensajeL.Text = String.Concat(j1.CalculoMano(vira), " > ", j2.CalculoMano(vira));
                    }
                    else if (j1.CalculoMano(vira) < j2.CalculoMano(vira))
                    {
                        j2.AddPuntos(ptsE);
                        MensajeL.Text = String.Concat(j1.CalculoMano(vira), " < ", j2.CalculoMano(vira));
                    }
                    else
                    {
                        MensajeL.Text = String.Concat(j1.CalculoMano(vira), " = ", j2.CalculoMano(vira));
                        if (j1.GetMesa() == true)
                            j1.AddPuntos(ptsE);
                        else
                            j2.AddPuntos(ptsE);
                    }
                    if (Id == 0)
                    {
                        MyPts.Text = String.Concat(j1.GetPuntos());
                        EnemyPts.Text = String.Concat(j2.GetPuntos());
                    }
                    else
                    {
                        MyPts.Text = String.Concat(j2.GetPuntos());
                        EnemyPts.Text = String.Concat(j1.GetPuntos());
                    }
                    if (GanadorPartida() == true)
                    {
                        ReinicioPartida();
                        if (ptsA == 2 || ptsB == 2)
                            Terminar();
                    }
                    break;
                case "11": // aceptar propuesta de elevar envido
                    ptsT = ptsT * 3;
                    if (Id == 0)
                        TramaOut = String.Concat('0', '1', "010", "11", "00", "0000000");
                    if (Id == 1)
                        TramaOut = String.Concat('1', '0', "010", "11", "00", "0000000");
                    if (ptsT == 9)
                        Turno();
                    if (ptsT == 27)
                        Escuchar();
                    break;
            }
            serialPort1.WriteLine(TramaOut);
        }
    }
}