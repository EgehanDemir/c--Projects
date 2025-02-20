﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static Button[,] Buton_Dizi1 = new Button[9, 9];
        static Button[,] Buton_Dizi2 = new Button[9, 9];
        static Button[,] Buton_Dizi3 = new Button[9, 9];
        static Button[,] Buton_Dizi4 = new Button[9, 9];
        static Button[,] Buton_Dizi5 = new Button[9, 9];
        static int[] deneme_array = new int[81];
        public static long[] tablo = new long[5];
        static long saniye = DateTime.Now.Millisecond;
        static String metin;
        public Form1()
        {
            InitializeComponent();
        }

        private static void yazdir(int[,] map, int k)
        {
            Control.CheckForIllegalCrossThreadCalls = false;


            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {



                    Buton_Dizi1[i, j].Text = "" + map[i, j];
                    for (int a = 0; a < 9; a++)
                    {
                        for (int b = 0; b < 9; b++)
                        {
                            if (!Buton_Dizi1[a, b].Text.Equals("0"))
                            {

                            }
                        }
                    }
                }

            }

        }

        private static void yazdır2(int[,] map, int k)
        {
            Control.CheckForIllegalCrossThreadCalls = false; 
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {


                    Buton_Dizi2[i, j].Text = "" + map[i, j];

                }

            }
        }
        private static void yazdir3(int[,] map, int k)
        {
            Control.CheckForIllegalCrossThreadCalls = false; 
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {


                    Buton_Dizi4[i, j].Text = "" + map[i, j];

                }

            }
        }
        private static void yazdir4(int[,] map, int k)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {


                    Buton_Dizi5[i, j].Text = "" + map[i, j];

                }

            }
        }
        private static void yazdir5(int[,] map, int k)
        {
            Control.CheckForIllegalCrossThreadCalls = false; 
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {


                    Buton_Dizi3[i, j].Text = "" + map[i, j];

                }

            }
        }
 

        public static void fonksiyon1(int[,] board)
        {
            int p = board.GetLength(0);
            saniye = DateTime.Now.Millisecond;
            if (KontrolET(board, p))
            {
                tablo[0] = DateTime.Now.Millisecond - saniye;
                yazdir(board, p);
            }
          
        }
        static void fonksiyon12(int[,] board)
        {
            int p = board.GetLength(0);
            saniye = DateTime.Now.Millisecond;
            if (KontrolET(board, p))
            {
                tablo[1] = DateTime.Now.Millisecond - saniye;
            
                yazdır2(board, p);
            }
   
        }
        static void fonksiyon3(int[,] board)
        {
            int p = board.GetLength(0);
            saniye = DateTime.Now.Millisecond;
            if (KontrolET(board, p))
            {
                tablo[2] = DateTime.Now.Millisecond - saniye;
          
                yazdir3(board, p);
            }
          
        }
        static void fonksiyon4(int[,] board)
        {
            int p = board.GetLength(0);
            saniye = DateTime.Now.Millisecond;
            if (KontrolET(board, p))
            {
                tablo[3] = DateTime.Now.Millisecond - saniye;
                yazdir4(board, p);
            }
           
        }
        static void fonksiyon5(int[,] board)
        {
            int p = board.GetLength(0);
            saniye = DateTime.Now.Millisecond;
            if (KontrolET(board, p))
            {
                tablo[4] = DateTime.Now.Millisecond - saniye;
                yazdir4(board, p);
            }
        }
        private static bool olabilirMi(int[,] harita, int satır, int sütun, int num)
        {
            for (int i = 0; i < harita.GetLength(0); i++)
            {
                if (harita[satır, i] == num)
                {
                    return false;
                }
            }
            for (int i = 0; i < harita.GetLength(0); i++)
            {
                if (harita[i, sütun] == num)
                {
                    return false;
                }
            }
            int karekök = (int)Math.Sqrt(harita.GetLength(0));
            int satırBasla = satır - satır % karekök;
            int sütunBasla = sütun - sütun % karekök;
            for (int i = satırBasla; i < satırBasla + karekök; i++)
            {
                for (int j = sütunBasla; j < sütunBasla + karekök; j++)
                {
                    if (harita[i, j] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool KontrolET(int[,] harita, int m)
        {
            int satır = 0;
            int sütun = 0;
            bool bosMu = true;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (harita[i, j] == 0)
                    {
                        satır = i;
                        sütun = j;
                        bosMu = false;
                        break;
                    }
                }
                if (!bosMu)
                {
                    break;
                }
            }
            if (bosMu)
            {
                return true;

            }
            for (int num = 1; num <= m; num++)
            {
                if (olabilirMi(harita, satır, sütun, num))
                {

                    harita[satır, sütun] = num;

                    if (KontrolET(harita, m))
                    {

                        return true;

                    }
                    else
                    {
                        harita[satır, sütun] = 0;
                    }
                }
            }
            return false;
        }
        private void Form_Yükle(object sender, EventArgs e)
        {
            string dosya_yolu = @"C:\oku.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string yazi = sw.ReadLine();
            while (yazi != null)
            {
                metin += yazi;
                yazi = sw.ReadLine();
            }
            sw.Close();
            fs.Close();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Buton_Dizi1[i, j] = new Button();
                    this.Controls.Add(Buton_Dizi1[i, j]);
                    Buton_Dizi1[i, j].Text = "";
                    Buton_Dizi1[i, j].Location = new Point(25 * j, 25 * i);
                    Buton_Dizi1[i, j].Size = new Size(25, 25);

                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Buton_Dizi2[i, j] = new Button();
                    this.Controls.Add(Buton_Dizi2[i, j]);
                    Buton_Dizi2[i, j].Text = "";
                    Buton_Dizi2[i, j].Location = new Point(300 + (25 * j), 25 * i);
                    Buton_Dizi2[i, j].Size = new Size(25, 25);

                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Buton_Dizi4[i, j] = new Button();
                    this.Controls.Add(Buton_Dizi4[i, j]);
                    Buton_Dizi4[i, j].Text = "";
                    Buton_Dizi4[i, j].Location = new Point(150 + (25 * j), 150 + (25 * i));
                    Buton_Dizi4[i, j].Size = new Size(25, 25);

                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Buton_Dizi5[i, j] = new Button();
                    this.Controls.Add(Buton_Dizi5[i, j]);
                    Buton_Dizi5[i, j].Text = "";
                    Buton_Dizi5[i, j].Location = new Point((25 * j), 300 + (25 * i));
                    Buton_Dizi5[i, j].Size = new Size(25, 25);

                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Buton_Dizi3[i, j] = new Button();
                    this.Controls.Add(Buton_Dizi3[i, j]);
                    Buton_Dizi3[i, j].Text = "";
                    Buton_Dizi3[i, j].Location = new Point(300 + (25 * j), 300 + (25 * i));
                    Buton_Dizi3[i, j].Size = new Size(25, 25);

                }
            }

            Buton_Dizi1[0, 0].Text = "" + metin[0];
            Buton_Dizi1[0, 1].Text = "" + metin[1];
            Buton_Dizi1[0, 2].Text = "" + metin[2];
            Buton_Dizi1[0, 3].Text = "" + metin[3];
            Buton_Dizi1[0, 4].Text = "" + metin[4];
            Buton_Dizi1[0, 5].Text = "" + metin[5];
            Buton_Dizi1[0, 6].Text = "" + metin[6];
            Buton_Dizi1[0, 7].Text = "" + metin[7];
            Buton_Dizi1[0, 8].Text = "" + metin[8];

            Buton_Dizi2[0, 0].Text = "" + metin[9];
            Buton_Dizi2[0, 1].Text = "" + metin[10];
            Buton_Dizi2[0, 2].Text = "" + metin[11];
            Buton_Dizi2[0, 3].Text = "" + metin[12];
            Buton_Dizi2[0, 4].Text = "" + metin[13];
            Buton_Dizi2[0, 5].Text = "" + metin[14];
            Buton_Dizi2[0, 6].Text = "" + metin[15];
            Buton_Dizi2[0, 7].Text = "" + metin[16];
            Buton_Dizi2[0, 8].Text = "" + metin[17];

            Buton_Dizi1[1, 0].Text = "" + metin[18];
            Buton_Dizi1[1, 1].Text = "" + metin[19];
            Buton_Dizi1[1, 2].Text = "" + metin[20];
            Buton_Dizi1[1, 3].Text = "" + metin[21];
            Buton_Dizi1[1, 4].Text = "" + metin[22];
            Buton_Dizi1[1, 5].Text = "" + metin[23];
            Buton_Dizi1[1, 6].Text = "" + metin[24];
            Buton_Dizi1[1, 7].Text = "" + metin[25];
            Buton_Dizi1[1, 8].Text = "" + metin[26];

            Buton_Dizi2[1, 0].Text = "" + metin[27];
            Buton_Dizi2[1, 1].Text = "" + metin[28];
            Buton_Dizi2[1, 2].Text = "" + metin[29];
            Buton_Dizi2[1, 3].Text = "" + metin[30];
            Buton_Dizi2[1, 4].Text = "" + metin[31];
            Buton_Dizi2[1, 5].Text = "" + metin[32];
            Buton_Dizi2[1, 6].Text = "" + metin[33];
            Buton_Dizi2[1, 7].Text = "" + metin[34];
            Buton_Dizi2[1, 8].Text = "" + metin[35];

            Buton_Dizi1[2, 0].Text = "" + metin[36];
            Buton_Dizi1[2, 1].Text = "" + metin[37];
            Buton_Dizi1[2, 2].Text = "" + metin[38];
            Buton_Dizi1[2, 3].Text = "" + metin[39];
            Buton_Dizi1[2, 4].Text = "" + metin[40];
            Buton_Dizi1[2, 5].Text = "" + metin[41];
            Buton_Dizi1[2, 6].Text = "" + metin[42];
            Buton_Dizi1[2, 7].Text = "" + metin[43];
            Buton_Dizi1[2, 8].Text = "" + metin[44];

            Buton_Dizi2[2, 0].Text = "" + metin[45];
            Buton_Dizi2[2, 1].Text = "" + metin[46];
            Buton_Dizi2[2, 2].Text = "" + metin[47];
            Buton_Dizi2[2, 3].Text = "" + metin[48];
            Buton_Dizi2[2, 4].Text = "" + metin[49];
            Buton_Dizi2[2, 5].Text = "" + metin[50];
            Buton_Dizi2[2, 6].Text = "" + metin[51];
            Buton_Dizi2[2, 7].Text = "" + metin[52];
            Buton_Dizi2[2, 8].Text = "" + metin[53];

            Buton_Dizi1[3, 0].Text = "" + metin[54];
            Buton_Dizi1[3, 1].Text = "" + metin[55];
            Buton_Dizi1[3, 2].Text = "" + metin[56];
            Buton_Dizi1[3, 3].Text = "" + metin[57];
            Buton_Dizi1[3, 4].Text = "" + metin[58];
            Buton_Dizi1[3, 5].Text = "" + metin[59];
            Buton_Dizi1[3, 6].Text = "" + metin[60];
            Buton_Dizi1[3, 7].Text = "" + metin[61];
            Buton_Dizi1[3, 8].Text = "" + metin[62];

            Buton_Dizi2[3, 0].Text = "" + metin[63];
            Buton_Dizi2[3, 1].Text = "" + metin[64];
            Buton_Dizi2[3, 2].Text = "" + metin[65];
            Buton_Dizi2[3, 3].Text = "" + metin[66];
            Buton_Dizi2[3, 4].Text = "" + metin[67];
            Buton_Dizi2[3, 5].Text = "" + metin[68];
            Buton_Dizi2[3, 6].Text = "" + metin[69];
            Buton_Dizi2[3, 7].Text = "" + metin[70];
            Buton_Dizi2[3, 8].Text = "" + metin[71];

            Buton_Dizi1[4, 0].Text = "" + metin[72];
            Buton_Dizi1[4, 1].Text = "" + metin[73];
            Buton_Dizi1[4, 2].Text = "" + metin[74];
            Buton_Dizi1[4, 3].Text = "" + metin[75];
            Buton_Dizi1[4, 4].Text = "" + metin[76];
            Buton_Dizi1[4, 5].Text = "" + metin[77];
            Buton_Dizi1[4, 6].Text = "" + metin[78];
            Buton_Dizi1[4, 7].Text = "" + metin[79];
            Buton_Dizi1[4, 8].Text = "" + metin[80];

            Buton_Dizi2[4, 0].Text = "" + metin[81];
            Buton_Dizi2[4, 1].Text = "" + metin[82];
            Buton_Dizi2[4, 2].Text = "" + metin[83];
            Buton_Dizi2[4, 3].Text = "" + metin[84];
            Buton_Dizi2[4, 4].Text = "" + metin[85];
            Buton_Dizi2[4, 5].Text = "" + metin[86];
            Buton_Dizi2[4, 6].Text = "" + metin[87];
            Buton_Dizi2[4, 7].Text = "" + metin[88];
            Buton_Dizi2[4, 8].Text = "" + metin[89];

            Buton_Dizi1[5, 0].Text = "" + metin[90];
            Buton_Dizi1[5, 1].Text = "" + metin[91];
            Buton_Dizi1[5, 2].Text = "" + metin[92];
            Buton_Dizi1[5, 3].Text = "" + metin[93];
            Buton_Dizi1[5, 4].Text = "" + metin[94];
            Buton_Dizi1[5, 5].Text = "" + metin[95];
            Buton_Dizi1[5, 6].Text = "" + metin[96];
            Buton_Dizi1[5, 7].Text = "" + metin[97];
            Buton_Dizi1[5, 8].Text = "" + metin[98];

            Buton_Dizi2[5, 0].Text = "" + metin[99];
            Buton_Dizi2[5, 1].Text = "" + metin[100];
            Buton_Dizi2[5, 2].Text = "" + metin[101];
            Buton_Dizi2[5, 3].Text = "" + metin[102];
            Buton_Dizi2[5, 4].Text = "" + metin[103];
            Buton_Dizi2[5, 5].Text = "" + metin[104];
            Buton_Dizi2[5, 6].Text = "" + metin[105];
            Buton_Dizi2[5, 7].Text = "" + metin[106];
            Buton_Dizi2[5, 8].Text = "" + metin[107];

            Buton_Dizi1[6, 0].Text = "" + metin[108];
            Buton_Dizi1[6, 1].Text = "" + metin[109];
            Buton_Dizi1[6, 2].Text = "" + metin[110];
            Buton_Dizi1[6, 3].Text = "" + metin[111];
            Buton_Dizi1[6, 4].Text = "" + metin[112];
            Buton_Dizi1[6, 5].Text = "" + metin[113];
            Buton_Dizi1[6, 6].Text = "" + metin[114];
            Buton_Dizi1[6, 7].Text = "" + metin[115];
            Buton_Dizi1[6, 8].Text = "" + metin[116];

            Buton_Dizi1[6, 0].Text = "" + metin[108];
            Buton_Dizi1[6, 1].Text = "" + metin[109];
            Buton_Dizi1[6, 2].Text = "" + metin[110];
            Buton_Dizi1[6, 3].Text = "" + metin[111];
            Buton_Dizi1[6, 4].Text = "" + metin[112];
            Buton_Dizi1[6, 5].Text = "" + metin[113];
            Buton_Dizi1[6, 6].Text = "" + metin[114];
            Buton_Dizi1[6, 7].Text = "" + metin[115];
            Buton_Dizi1[6, 8].Text = "" + metin[116];

            Buton_Dizi4[0, 0].Text = "" + metin[114];
            Buton_Dizi4[0, 1].Text = "" + metin[115];
            Buton_Dizi4[0, 2].Text = "" + metin[116];
            Buton_Dizi4[0, 3].Text = "" + metin[117];
            Buton_Dizi4[0, 4].Text = "" + metin[118];
            Buton_Dizi4[0, 5].Text = "" + metin[119];
            Buton_Dizi4[0, 6].Text = "" + metin[120];
            Buton_Dizi4[0, 7].Text = "" + metin[121];
            Buton_Dizi4[0, 8].Text = "" + metin[122];

            Buton_Dizi2[6, 0].Text = "" + metin[120];
            Buton_Dizi2[6, 1].Text = "" + metin[121];
            Buton_Dizi2[6, 2].Text = "" + metin[122];
            Buton_Dizi2[6, 3].Text = "" + metin[123];
            Buton_Dizi2[6, 4].Text = "" + metin[124];
            Buton_Dizi2[6, 5].Text = "" + metin[125];
            Buton_Dizi2[6, 6].Text = "" + metin[126];
            Buton_Dizi2[6, 7].Text = "" + metin[127];
            Buton_Dizi2[6, 8].Text = "" + metin[128];

            Buton_Dizi1[7, 0].Text = "" + metin[129];
            Buton_Dizi1[7, 1].Text = "" + metin[130];
            Buton_Dizi1[7, 2].Text = "" + metin[131];
            Buton_Dizi1[7, 3].Text = "" + metin[132];
            Buton_Dizi1[7, 4].Text = "" + metin[133];
            Buton_Dizi1[7, 5].Text = "" + metin[134];
            Buton_Dizi1[7, 6].Text = "" + metin[135];
            Buton_Dizi1[7, 7].Text = "" + metin[136];
            Buton_Dizi1[7, 8].Text = "" + metin[137];

            Buton_Dizi4[1, 0].Text = "" + metin[135];
            Buton_Dizi4[1, 1].Text = "" + metin[136];
            Buton_Dizi4[1, 2].Text = "" + metin[137];
            Buton_Dizi4[1, 3].Text = "" + metin[138];
            Buton_Dizi4[1, 4].Text = "" + metin[139];
            Buton_Dizi4[1, 5].Text = "" + metin[140];
            Buton_Dizi4[1, 6].Text = "" + metin[141];
            Buton_Dizi4[1, 7].Text = "" + metin[142];
            Buton_Dizi4[1, 8].Text = "" + metin[143];

            Buton_Dizi2[7, 0].Text = "" + metin[141];
            Buton_Dizi2[7, 1].Text = "" + metin[142];
            Buton_Dizi2[7, 2].Text = "" + metin[143];
            Buton_Dizi2[7, 3].Text = "" + metin[144];
            Buton_Dizi2[7, 4].Text = "" + metin[145];
            Buton_Dizi2[7, 5].Text = "" + metin[146];
            Buton_Dizi2[7, 6].Text = "" + metin[147];
            Buton_Dizi2[7, 7].Text = "" + metin[148];
            Buton_Dizi2[7, 8].Text = "" + metin[149];

            Buton_Dizi1[8, 0].Text = "" + metin[150];
            Buton_Dizi1[8, 1].Text = "" + metin[151];
            Buton_Dizi1[8, 2].Text = "" + metin[152];
            Buton_Dizi1[8, 3].Text = "" + metin[153];
            Buton_Dizi1[8, 4].Text = "" + metin[154];
            Buton_Dizi1[8, 5].Text = "" + metin[155];
            Buton_Dizi1[8, 6].Text = "" + metin[156];
            Buton_Dizi1[8, 7].Text = "" + metin[157];
            Buton_Dizi1[8, 8].Text = "" + metin[158];

            Buton_Dizi4[2, 0].Text = "" + metin[156];
            Buton_Dizi4[2, 1].Text = "" + metin[157];
            Buton_Dizi4[2, 2].Text = "" + metin[158];
            Buton_Dizi4[2, 3].Text = "" + metin[159];
            Buton_Dizi4[2, 4].Text = "" + metin[160];
            Buton_Dizi4[2, 5].Text = "" + metin[161];
            Buton_Dizi4[2, 6].Text = "" + metin[162];
            Buton_Dizi4[2, 7].Text = "" + metin[163];
            Buton_Dizi4[2, 8].Text = "" + metin[164];

            Buton_Dizi2[8, 0].Text = "" + metin[162];
            Buton_Dizi2[8, 1].Text = "" + metin[163];
            Buton_Dizi2[8, 2].Text = "" + metin[164];
            Buton_Dizi2[8, 3].Text = "" + metin[165];
            Buton_Dizi2[8, 4].Text = "" + metin[166];
            Buton_Dizi2[8, 5].Text = "" + metin[167];
            Buton_Dizi2[8, 6].Text = "" + metin[168];
            Buton_Dizi2[8, 7].Text = "" + metin[169];
            Buton_Dizi2[8, 8].Text = "" + metin[170];

            Buton_Dizi4[3, 0].Text = "" + metin[171];
            Buton_Dizi4[3, 1].Text = "" + metin[172];
            Buton_Dizi4[3, 2].Text = "" + metin[173];
            Buton_Dizi4[3, 3].Text = "" + metin[174];
            Buton_Dizi4[3, 4].Text = "" + metin[175];
            Buton_Dizi4[3, 5].Text = "" + metin[176];
            Buton_Dizi4[3, 6].Text = "" + metin[177];
            Buton_Dizi4[3, 7].Text = "" + metin[178];
            Buton_Dizi4[3, 8].Text = "" + metin[179];

            Buton_Dizi4[4, 0].Text = "" + metin[180];
            Buton_Dizi4[4, 1].Text = "" + metin[181];
            Buton_Dizi4[4, 2].Text = "" + metin[182];
            Buton_Dizi4[4, 3].Text = "" + metin[183];
            Buton_Dizi4[4, 4].Text = "" + metin[184];
            Buton_Dizi4[4, 5].Text = "" + metin[185];
            Buton_Dizi4[4, 6].Text = "" + metin[186];
            Buton_Dizi4[4, 7].Text = "" + metin[187];
            Buton_Dizi4[4, 8].Text = "" + metin[188];

            Buton_Dizi4[5, 0].Text = "" + metin[189];
            Buton_Dizi4[5, 1].Text = "" + metin[190];
            Buton_Dizi4[5, 2].Text = "" + metin[191];
            Buton_Dizi4[5, 3].Text = "" + metin[192];
            Buton_Dizi4[5, 4].Text = "" + metin[193];
            Buton_Dizi4[5, 5].Text = "" + metin[194];
            Buton_Dizi4[5, 6].Text = "" + metin[195];
            Buton_Dizi4[5, 7].Text = "" + metin[196];
            Buton_Dizi4[5, 8].Text = "" + metin[197];


            Buton_Dizi5[0, 0].Text = "" + metin[198];
            Buton_Dizi5[0, 1].Text = "" + metin[199];
            Buton_Dizi5[0, 2].Text = "" + metin[200];
            Buton_Dizi5[0, 3].Text = "" + metin[201];
            Buton_Dizi5[0, 4].Text = "" + metin[202];
            Buton_Dizi5[0, 5].Text = "" + metin[203];
            Buton_Dizi5[0, 6].Text = "" + metin[204];
            Buton_Dizi5[0, 7].Text = "" + metin[205];
            Buton_Dizi5[0, 8].Text = "" + metin[206];

            Buton_Dizi4[6, 0].Text = "" + metin[204];
            Buton_Dizi4[6, 1].Text = "" + metin[205];
            Buton_Dizi4[6, 2].Text = "" + metin[206];
            Buton_Dizi4[6, 3].Text = "" + metin[207];
            Buton_Dizi4[6, 4].Text = "" + metin[208];
            Buton_Dizi4[6, 5].Text = "" + metin[209];
            Buton_Dizi4[6, 6].Text = "" + metin[210];
            Buton_Dizi4[6, 7].Text = "" + metin[211];
            Buton_Dizi4[6, 8].Text = "" + metin[212];

            Buton_Dizi3[0, 0].Text = "" + metin[210];
            Buton_Dizi3[0, 1].Text = "" + metin[211];
            Buton_Dizi3[0, 2].Text = "" + metin[212];
            Buton_Dizi3[0, 3].Text = "" + metin[213];
            Buton_Dizi3[0, 4].Text = "" + metin[214];
            Buton_Dizi3[0, 5].Text = "" + metin[215];
            Buton_Dizi3[0, 6].Text = "" + metin[216];
            Buton_Dizi3[0, 7].Text = "" + metin[217];
            Buton_Dizi3[0, 8].Text = "" + metin[218];

            Buton_Dizi5[1, 0].Text = "" + metin[219];
            Buton_Dizi5[1, 1].Text = "" + metin[220];
            Buton_Dizi5[1, 2].Text = "" + metin[221];
            Buton_Dizi5[1, 3].Text = "" + metin[222];
            Buton_Dizi5[1, 4].Text = "" + metin[223];
            Buton_Dizi5[1, 5].Text = "" + metin[224];
            Buton_Dizi5[1, 6].Text = "" + metin[225];
            Buton_Dizi5[1, 7].Text = "" + metin[226];
            Buton_Dizi5[1, 8].Text = "" + metin[227];

            Buton_Dizi4[7, 0].Text = "" + metin[225];
            Buton_Dizi4[7, 1].Text = "" + metin[226];
            Buton_Dizi4[7, 2].Text = "" + metin[227];
            Buton_Dizi4[7, 3].Text = "" + metin[228];
            Buton_Dizi4[7, 4].Text = "" + metin[229];
            Buton_Dizi4[7, 5].Text = "" + metin[230];
            Buton_Dizi4[7, 6].Text = "" + metin[231];
            Buton_Dizi4[7, 7].Text = "" + metin[232];
            Buton_Dizi4[7, 8].Text = "" + metin[233];

            Buton_Dizi3[1, 0].Text = "" + metin[231];
            Buton_Dizi3[1, 1].Text = "" + metin[232];
            Buton_Dizi3[1, 2].Text = "" + metin[233];
            Buton_Dizi3[1, 3].Text = "" + metin[234];
            Buton_Dizi3[1, 4].Text = "" + metin[235];
            Buton_Dizi3[1, 5].Text = "" + metin[236];
            Buton_Dizi3[1, 6].Text = "" + metin[237];
            Buton_Dizi3[1, 7].Text = "" + metin[238];
            Buton_Dizi3[1, 8].Text = "" + metin[239];

            Buton_Dizi5[2, 0].Text = "" + metin[240];
            Buton_Dizi5[2, 1].Text = "" + metin[241];
            Buton_Dizi5[2, 2].Text = "" + metin[242];
            Buton_Dizi5[2, 3].Text = "" + metin[243];
            Buton_Dizi5[2, 4].Text = "" + metin[244];
            Buton_Dizi5[2, 5].Text = "" + metin[245];
            Buton_Dizi5[2, 6].Text = "" + metin[246];
            Buton_Dizi5[2, 7].Text = "" + metin[247];
            Buton_Dizi5[2, 8].Text = "" + metin[248];

            Buton_Dizi4[8, 0].Text = "" + metin[246];
            Buton_Dizi4[8, 1].Text = "" + metin[247];
            Buton_Dizi4[8, 2].Text = "" + metin[248];
            Buton_Dizi4[8, 3].Text = "" + metin[249];
            Buton_Dizi4[8, 4].Text = "" + metin[250];
            Buton_Dizi4[8, 5].Text = "" + metin[251];
            Buton_Dizi4[8, 6].Text = "" + metin[252];
            Buton_Dizi4[8, 7].Text = "" + metin[253];
            Buton_Dizi4[8, 8].Text = "" + metin[254];

            Buton_Dizi3[2, 0].Text = "" + metin[252];
            Buton_Dizi3[2, 1].Text = "" + metin[253];
            Buton_Dizi3[2, 2].Text = "" + metin[254];
            Buton_Dizi3[2, 3].Text = "" + metin[255];
            Buton_Dizi3[2, 4].Text = "" + metin[256];
            Buton_Dizi3[2, 5].Text = "" + metin[257];
            Buton_Dizi3[2, 6].Text = "" + metin[258];
            Buton_Dizi3[2, 7].Text = "" + metin[259];
            Buton_Dizi3[2, 8].Text = "" + metin[260];

            Buton_Dizi5[3, 0].Text = "" + metin[261];
            Buton_Dizi5[3, 1].Text = "" + metin[262];
            Buton_Dizi5[3, 2].Text = "" + metin[263];
            Buton_Dizi5[3, 3].Text = "" + metin[264];
            Buton_Dizi5[3, 4].Text = "" + metin[265];
            Buton_Dizi5[3, 5].Text = "" + metin[266];
            Buton_Dizi5[3, 6].Text = "" + metin[267];
            Buton_Dizi5[3, 7].Text = "" + metin[268];
            Buton_Dizi5[3, 8].Text = "" + metin[269];

            Buton_Dizi3[3, 0].Text = "" + metin[270];
            Buton_Dizi3[3, 1].Text = "" + metin[271];
            Buton_Dizi3[3, 2].Text = "" + metin[272];
            Buton_Dizi3[3, 3].Text = "" + metin[273];
            Buton_Dizi3[3, 4].Text = "" + metin[274];
            Buton_Dizi3[3, 5].Text = "" + metin[275];
            Buton_Dizi3[3, 6].Text = "" + metin[276];
            Buton_Dizi3[3, 7].Text = "" + metin[277];
            Buton_Dizi3[3, 8].Text = "" + metin[278];

            Buton_Dizi5[4, 0].Text = "" + metin[279];
            Buton_Dizi5[4, 1].Text = "" + metin[280];
            Buton_Dizi5[4, 2].Text = "" + metin[281];
            Buton_Dizi5[4, 3].Text = "" + metin[282];
            Buton_Dizi5[4, 4].Text = "" + metin[283];
            Buton_Dizi5[4, 5].Text = "" + metin[284];
            Buton_Dizi5[4, 6].Text = "" + metin[285];
            Buton_Dizi5[4, 7].Text = "" + metin[286];
            Buton_Dizi5[4, 8].Text = "" + metin[287];

            Buton_Dizi3[4, 0].Text = "" + metin[288];
            Buton_Dizi3[4, 1].Text = "" + metin[289];
            Buton_Dizi3[4, 2].Text = "" + metin[290];
            Buton_Dizi3[4, 3].Text = "" + metin[291];
            Buton_Dizi3[4, 4].Text = "" + metin[292];
            Buton_Dizi3[4, 5].Text = "" + metin[293];
            Buton_Dizi3[4, 6].Text = "" + metin[294];
            Buton_Dizi3[4, 7].Text = "" + metin[295];
            Buton_Dizi3[4, 8].Text = "" + metin[296];

            Buton_Dizi5[5, 0].Text = "" + metin[297];
            Buton_Dizi5[5, 1].Text = "" + metin[298];
            Buton_Dizi5[5, 2].Text = "" + metin[299];
            Buton_Dizi5[5, 3].Text = "" + metin[300];
            Buton_Dizi5[5, 4].Text = "" + metin[301];
            Buton_Dizi5[5, 5].Text = "" + metin[302];
            Buton_Dizi5[5, 6].Text = "" + metin[303];
            Buton_Dizi5[5, 7].Text = "" + metin[304];
            Buton_Dizi5[5, 8].Text = "" + metin[305];

            Buton_Dizi3[5, 0].Text = "" + metin[306];
            Buton_Dizi3[5, 1].Text = "" + metin[307];
            Buton_Dizi3[5, 2].Text = "" + metin[308];
            Buton_Dizi3[5, 3].Text = "" + metin[309];
            Buton_Dizi3[5, 4].Text = "" + metin[310];
            Buton_Dizi3[5, 5].Text = "" + metin[311];
            Buton_Dizi3[5, 6].Text = "" + metin[312];
            Buton_Dizi3[5, 7].Text = "" + metin[313];
            Buton_Dizi3[5, 8].Text = "" + metin[314];

            Buton_Dizi5[6, 0].Text = "" + metin[315];
            Buton_Dizi5[6, 1].Text = "" + metin[316];
            Buton_Dizi5[6, 2].Text = "" + metin[317];
            Buton_Dizi5[6, 3].Text = "" + metin[318];
            Buton_Dizi5[6, 4].Text = "" + metin[319];
            Buton_Dizi5[6, 5].Text = "" + metin[320];
            Buton_Dizi5[6, 6].Text = "" + metin[321];
            Buton_Dizi5[6, 7].Text = "" + metin[322];
            Buton_Dizi5[6, 8].Text = "" + metin[323];

            Buton_Dizi3[6, 0].Text = "" + metin[324];
            Buton_Dizi3[6, 1].Text = "" + metin[325];
            Buton_Dizi3[6, 2].Text = "" + metin[326];
            Buton_Dizi3[6, 3].Text = "" + metin[327];
            Buton_Dizi3[6, 4].Text = "" + metin[328];
            Buton_Dizi3[6, 5].Text = "" + metin[329];
            Buton_Dizi3[6, 6].Text = "" + metin[330];
            Buton_Dizi3[6, 7].Text = "" + metin[331];
            Buton_Dizi3[6, 8].Text = "" + metin[332];

            Buton_Dizi5[7, 0].Text = "" + metin[333];
            Buton_Dizi5[7, 1].Text = "" + metin[334];
            Buton_Dizi5[7, 2].Text = "" + metin[335];
            Buton_Dizi5[7, 3].Text = "" + metin[336];
            Buton_Dizi5[7, 4].Text = "" + metin[337];
            Buton_Dizi5[7, 5].Text = "" + metin[338];
            Buton_Dizi5[7, 6].Text = "" + metin[339];
            Buton_Dizi5[7, 7].Text = "" + metin[340];
            Buton_Dizi5[7, 8].Text = "" + metin[341];

            Buton_Dizi3[7, 0].Text = "" + metin[342];
            Buton_Dizi3[7, 1].Text = "" + metin[343];
            Buton_Dizi3[7, 2].Text = "" + metin[344];
            Buton_Dizi3[7, 3].Text = "" + metin[345];
            Buton_Dizi3[7, 4].Text = "" + metin[346];
            Buton_Dizi3[7, 5].Text = "" + metin[347];
            Buton_Dizi3[7, 6].Text = "" + metin[348];
            Buton_Dizi3[7, 7].Text = "" + metin[349];
            Buton_Dizi3[7, 8].Text = "" + metin[350];

            Buton_Dizi5[8, 0].Text = "" + metin[351];
            Buton_Dizi5[8, 1].Text = "" + metin[352];
            Buton_Dizi5[8, 2].Text = "" + metin[353];
            Buton_Dizi5[8, 3].Text = "" + metin[354];
            Buton_Dizi5[8, 4].Text = "" + metin[355];
            Buton_Dizi5[8, 5].Text = "" + metin[356];
            Buton_Dizi5[8, 6].Text = "" + metin[357];
            Buton_Dizi5[8, 7].Text = "" + metin[358];
            Buton_Dizi5[8, 8].Text = "" + metin[359];

            Buton_Dizi3[8, 0].Text = "" + metin[360];
            Buton_Dizi3[8, 1].Text = "" + metin[361];
            Buton_Dizi3[8, 2].Text = "" + metin[362];
            Buton_Dizi3[8, 3].Text = "" + metin[363];
            Buton_Dizi3[8, 4].Text = "" + metin[364];
            Buton_Dizi3[8, 5].Text = "" + metin[365];
            Buton_Dizi3[8, 6].Text = "" + metin[366];
            Buton_Dizi3[8, 7].Text = "" + metin[367];
            Buton_Dizi3[8, 8].Text = "" + metin[368];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Buton_Dizi1[i, j].Text.Equals("*"))
                    {
                        Buton_Dizi1[i, j].Text = "0";
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Buton_Dizi2[i, j].Text.Equals("*"))
                    {
                        Buton_Dizi2[i, j].Text = "0";
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Buton_Dizi4[i, j].Text.Equals("*"))
                    {
                        Buton_Dizi4[i, j].Text = "0";
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Buton_Dizi5[i, j].Text.Equals("*"))
                    {
                        Buton_Dizi5[i, j].Text = "0";
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Buton_Dizi3[i, j].Text.Equals("*"))
                    {
                        Buton_Dizi3[i, j].Text = "0";
                    }
                }
            }

            int[,] matris1 = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    matris1[i, j] = Convert.ToInt32(Buton_Dizi1[i, j].Text);
                }
            }
            int[,] matris2 = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    matris2[i, j] = Convert.ToInt32(Buton_Dizi2[i, j].Text);
                }
            }
            int[,] matris3 = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    matris3[i, j] = Convert.ToInt32(Buton_Dizi4[i, j].Text);
                }
            }
            int[,] matris4 = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    matris4[i, j] = Convert.ToInt32(Buton_Dizi5[i, j].Text);
                }
            }
            int[,] matris5 = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    matris5[i, j] = Convert.ToInt32(Buton_Dizi3[i, j].Text);
                }
            }
            


            Thread thread1 = new Thread(new ThreadStart(() => fonksiyon1(matris1)));
   
            thread1.Start();

            Thread thread2 = new Thread(new ThreadStart(() => fonksiyon12(matris2)));
  
            thread2.Start();
            Thread thread3 = new Thread(new ThreadStart(() => fonksiyon3(matris3)));
        
            thread3.Start();
            Thread thread4 = new Thread(new ThreadStart(() => fonksiyon4(matris4)));

            thread4.Start();
            Thread thread5 = new Thread(new ThreadStart(() => fonksiyon5(matris5)));
        
            thread5.Start();
            

            Thread.Sleep(3000);

      

            this.chart1.Series["Kutu / MiliSaniye"].Points.AddXY("" + 81, Math.Abs(tablo[0]));
            this.chart1.Series["Kutu / MiliSaniye"].Points.AddXY("" + 81 * 2, Math.Abs(tablo[1]));
            this.chart1.Series["Kutu / MiliSaniye"].Points.AddXY("" + 81 * 3, Math.Abs(tablo[2]));
            this.chart1.Series["Kutu / MiliSaniye"].Points.AddXY("" + 81 * 4, Math.Abs(tablo[3]));
            this.chart1.Series["Kutu / MiliSaniye"].Points.AddXY("" + 81 * 5, Math.Abs(tablo[4]));



        }
    }
}
