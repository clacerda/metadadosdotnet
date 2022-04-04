using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace readFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        } 
        
        private void button1_Click(object sender, EventArgs e)
        { 
            var arquivo = ConfigurationSettings.AppSettings["Caminho"].ToString();
            var linhas = File.ReadAllLines(arquivo);

            bool quebraLinha = false;

            string corpo = String.Empty;
            string cabecalho1 = String.Empty;
            string cabecalho2 = String.Empty;
            string pipe = String.Empty;
            List<string> rows = new List<string>();
            List<string> arquivo2 = new List<string>();
            for (int i = 0; i < linhas.Count(); i++)
            {
                if (linhas[i] == null || linhas[i] == "")
                {
                    quebraLinha = true;
                } 
                if (linhas[i] != null && linhas[i] != "")
                {
                    pipe = linhas[i].Substring(0, 1);

                    if (pipe != "|")
                    {
                        cabecalho1 = cabecalho2 = linhas[i].Replace("(", "[").Replace(")","]"); 
                    } 

                    else if (linhas[i] != null && linhas[i] != "")
                    {
                        if (pipe == "|")
                        {
                            corpo += linhas[i];
                        }
                    }
                }
                else
                {
                    if (quebraLinha)
                    {
                        rows.Add(cabecalho2 += corpo);
                        corpo = String.Empty;
                        cabecalho2 = cabecalho1;
                    }
                    else
                    {
                        rows.Add(cabecalho2 += corpo);
                        corpo = String.Empty;
                        cabecalho2 = cabecalho1;
                    }                    
                }                 
            }
            foreach (var item in rows)
            {
                if (item != "" && item != null)
                {
                    arquivo2.Add(item);
                }                
            }
            File.WriteAllLines("caminho do arquivo", arquivo2);
        }
    }
}
