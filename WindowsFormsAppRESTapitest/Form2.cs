using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

//    client.BaseAddress = new Uri("http://api.scb.se/OV0104/v1/doris/sv/ssd/");

//// Add an Accept header for JSON format.
//client.DefaultRequestHeaders.Accept.Add(
//new MediaTypeWithQualityHeaderValue("application/json"));


namespace WindowsFormsAppRESTapitest
{
    public partial class Form2 : Form
    {
        public List<Infoobject> infolista = new List<Infoobject>();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            HttpClient client = new HttpClient();

            string json3 = @"{       
                'query': [],
                'response': {
                    'format': 'json'
                }
            }";

        
            StringContent queryString = new StringContent(json3);
       
            var url2 = new Uri("http://api.scb.se/OV0104/v1/doris/sv/ssd/START/PR/PR0101/PR0101A/KPIFastM2");
            
            var response1 = client.PostAsync(url2, queryString).Result;
            var responseBody = response1.Content.ReadAsStringAsync();
            var res= responseBody.Result;

            var resobject = JsonConvert.DeserializeObject<Res2Object>(res);
            listBox1.Items.Clear();
            textBox1.Text = resobject.columns[0].text + resobject.columns[0].code + Environment.NewLine +
                            resobject.columns[1].text + resobject.columns[1].code + Environment.NewLine;
            foreach (var item in resobject.data)
            {
                listBox1.Items.Add(item.key[0] + " " + item.values[0]);
            }


            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
           
            // List data response.
            var response = client.GetAsync("http://api.scb.se/OV0104/v1/doris/sv/ssd/").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObjects = response.Content;
                var dataString = response.Content.ReadAsStringAsync().Result;
                List<Scbdata> dataut = JsonConvert.DeserializeObject<List<Scbdata>>(dataString.ToString());
                listBox1.Items.Clear();
                textBox1.Text = "";
                foreach (var item in dataut)
                {
                    listBox1.Items.Add(item.id+" "+ item.text + " " + item.type);

                }

            }
            else
            {
                MessageBox.Show(this.Owner,response.StatusCode.ToString(), response.ReasonPhrase);
         
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            HttpClient client = new HttpClient();

            

            string json = @"{
 'query': [
            {
                'code': 'Sektor',
                'selection': {
                    'filter': 'item',
                    'values': [
                    '6'
                        ]
                }
            },
            {
                'code': 'ContentsCode',
                'selection': {
                    'filter': 'item',
                    'values': [
                    'AM0401PX'
                        ]
                }
            },
            {
                'code': 'Tid',
                'selection': {
                    'filter': 'item',
                    'values': [
                    '2017M08'
                        ]
                }
            }
            ],
            'response': {
                'format': 'json'
            }
        }
  ";
            StringContent queryString = new StringContent(json);
            var url1 = new Uri("http://api.scb.se/OV0104/v1/doris/sv/ssd/START/AM/AM0401/AM0401J/NAKUSektAnstM");
        

            var response1 = client.PostAsync(url1, queryString).Result;
            var responseBody = response1.Content.ReadAsStringAsync();
            var res = responseBody.Result;

            var resobject = JsonConvert.DeserializeObject<Res2Object>(res);

            listBox1.Items.Clear();
            textBox1.Text = resobject.columns[0].text + resobject.columns[0].code + Environment.NewLine +
                            resobject.columns[1].text + resobject.columns[1].code + Environment.NewLine +
                            resobject.columns[2].text + resobject.columns[2].code + Environment.NewLine; 
            foreach (var item in resobject.data)
            {
                listBox1.Items.Add(item.key[0] + " " + item.values[0]);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string json = @"{       
                'query': [],
                'response': {
                    'format': 'json'
                }
            }";
            string res = "";
            using (var client2 = new WebClient())
            {
                client2.Headers[HttpRequestHeader.ContentType] = "application/json";
               res = client2.UploadString("http://api.scb.se/OV0104/v1/doris/sv/ssd/START/PR/PR0101/PR0101A/KPIFastM2", "POST", json);
            }
            var resobject = JsonConvert.DeserializeObject<Res2Object>(res);
            listBox1.Items.Clear();
            textBox1.Text = resobject.columns[0].text + resobject.columns[0].code + Environment.NewLine +
                            resobject.columns[1].text + resobject.columns[1].code + Environment.NewLine;
            foreach (var item in resobject.data)
            {
                listBox1.Items.Add(item.key[0] + " " + item.values[0]);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();



            string json1 = textBox3.Text;
            string json = json1.Replace("px", "json");

            StringContent queryString = new StringContent(json);
            var url1 = new Uri(textBox2.Text);


            var response1 = client.PostAsync(url1, queryString).Result;
            var responseBody = response1.Content.ReadAsStringAsync();
            var res = responseBody.Result;

            var resobject = JsonConvert.DeserializeObject<Res2Object>(res);

            listBox1.Items.Clear();
            textBox1.Text = resobject.columns[0].text + resobject.columns[0].code + Environment.NewLine +
                            resobject.columns[1].text + resobject.columns[1].code + Environment.NewLine +
                            resobject.columns[2].text + resobject.columns[2].code + Environment.NewLine;
          
            foreach (var item in resobject.data)
            {
                if (item.key.Count == 1)
                    listBox1.Items.Add(item.key[0] + " " + item.values[0]);
                else
                {
                    if (item.key.Count == 2)
                    {
                        listBox1.Items.Add(item.key[0] + " " + item.key[1] + " " + item.values[0]);
                        
                    }
                   

                }

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var url1 = new Uri(textBox2.Text);
            var response1 = client.GetAsync(url1).Result;
            var responseBody = response1.Content.ReadAsStringAsync();
            var res = responseBody.Result;

            var resobject = JsonConvert.DeserializeObject<GetResObject>(res);

            listBox1.Items.Clear();
            textBox1.Text = resobject.title[0].ToString() + Environment.NewLine +
                            resobject.title[1] + Environment.NewLine;
                         

            foreach (var item in resobject.variables)
            {
                foreach (var item1 in item.values)
                { 
                    var x = new Infoobject();
                    x
               infolista.Add


                if (item.)
                    listBox1.Items.Add(item.key[0] + " " + item.values[0]);
                else
                {
                    if (item.key.Count == 2)
                    {
                        listBox1.Items.Add(item.key[0] + " " + item.key[1] + " " + item.values[0]);

                    }


                }




            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
