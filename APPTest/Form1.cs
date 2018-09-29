using ApplicationService;
using Data;
using DomainModel.APIGoogle;
using DomainModel.Entities;
using DomainService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace APPTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }


        public async Task<List<Result>> ListarRestaurantes(string longitude, string latitude)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = string.Format("http://localhost:63651/api/Result/{0}/{1}", longitude, latitude);
                var response = await client.GetStringAsync(url);
                var ListaRestaurantes = JsonConvert.DeserializeObject<List<Result>>(response);
                return ListaRestaurantes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
