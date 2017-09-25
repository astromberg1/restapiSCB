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

namespace WindowsFormsAppRESTapitest
{
    public partial class FormMain : Form
    {
        public Dictionary<string, string> infodictionary = new Dictionary<string, string>();
        public List<Infoobject> infolista = new List<Infoobject>();

        public FormMain()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
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
            var res = responseBody.Result;

            var resobject = JsonConvert.DeserializeObject<Res2Object>(res);
            listBox1.Items.Clear();
            textBox1.Text = resobject.columns[0].text + resobject.columns[0].code + Environment.NewLine +
                            resobject.columns[1].text + resobject.columns[1].code + Environment.NewLine;
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
                res = client2.UploadString("http://api.scb.se/OV0104/v1/doris/sv/ssd/START/PR/PR0101/PR0101A/KPIFastM2",
                    "POST", json);
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
        /// <summary>
        /// Event_procedure för att hämta meta data för tabeller nivå 1
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {           
            HttpClient client = new HttpClient();
            // List data response.
            var response = client.GetAsync("http://api.scb.se/OV0104/v1/doris/sv/ssd/").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataString = response.Content.ReadAsStringAsync().Result;
                List<Scbdata> dataut = JsonConvert.DeserializeObject<List<Scbdata>>(dataString.ToString());
                listBox1.Items.Clear();
                textBox1.Text = "";
                foreach (var item in dataut)
                {
                    listBox1.Items.Add(item.id + " " + item.text + " " + item.type);

                }
            }
            else
            {
                MessageBox.Show(this.Owner, response.StatusCode.ToString(), response.ReasonPhrase);

            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

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
                        listBox1.Items.Add(infodictionary[item.key[0]] + " " + item.key[0] + item.key[1] + " " +
                                           item.values[0]);

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
            textBox1.Text = resobject.title[0] + Environment.NewLine +
                            resobject.title[1] + Environment.NewLine;

            var list = resobject.variables.FirstOrDefault().valueTexts;
            var list2 = resobject.variables.FirstOrDefault().values;
            int i = -1;
            foreach (var item in list2)
            {
                i++;
                infodictionary.Add(item, list[i]);
                listBox1.Items.Add(item + "   " + list[i]);


            }







        }

        private void button7_Click(object sender, EventArgs e)
        {

            string json3 = @"{
  'query': [
            {
                'code': 'Region',
                'selection': {
                    'filter': 'agg:Skåne',
                    'values': [
                    'T3300',
                    'T3304',
                    'TX400',
                    'T3308',
                    'T3312',
                    'T3316',
                    'T3320',
                    'T2800',
                    'TX402',
                    'T3324',
                    'T3328',
                    'T2804',
                    'T2808',
                    'T3332',
                    'T3336',
                    'T3337',
                    'T2812',
                    'T3338',
                    'T2814',
                    'T3340',
                    'T3344',
                    'T3348',
                    'T3352',
                    'T3354',
                    'T2816',
                    'T3356',
                    'T3360',
                    'T2810',
                    'T3364',
                    'TX404',
                    'T2820',
                    'T3368',
                    'T2824',
                    'T2828',
                    'T2832',
                    'T2836',
                    'T3372',
                    'T3374',
                    'T3376',
                    'T2840',
                    'T2844',
                    'T3380',
                    'T2848',
                    'T3384',
                    'T3388',
                    'T2850',
                    'T3392',
                    'T2856',
                    'T2860',
                    'T3396',
                    'T2864',
                    'T2866',
                    'T2868',
                    'T2872',
                    'T2870',
                    'TX408',
                    'T3400',
                    'T3402',
                    'T3408',
                    'T2876',
                    'T2880',
                    'T3412',
                    'T3416',
                    'T3438',
                    'T3420',
                    'TX412',
                    'T3424',
                    'T2884',
                    'T3428',
                    'T2888',
                    'T2818',
                    'T2890',
                    'T2892',
                    'T3432',
                    'T3436',
                    'T2896',
                    'T2900',
                    'T2904',
                    'T2906',
                    'T2908',
                    'T2912',
                    'T3440',
                    'T3444',
                    'T3198',
                    'T3448',
                    'T3452',
                    'T3456',
                    'T2916',
                    'T2920',
                    'T3460',
                    'T3464',
                    'T3466',
                    'T2924',
                    'T3472',
                    'T2928',
                    'TX414',
                    'TX416',
                    'T3476',
                    'T3484',
                    'T2936',
                    'T2940',
                    'T3488',
                    'T2942',
                    'T2944',
                    'T3492',
                    'T3496',
                    'T3500',
                    'T2946',
                    'T3504',
                    'T3506',
                    'T2948',
                    'T3064',
                    'T3508',
                    'T3512',
                    'T2950',
                    'TX418',
                    'TX420',
                    'T2952',
                    'T3516',
                    'T2956',
                    'T2960',
                    'T3528',
                    'T2964',
                    'T2968',
                    'T3532',
                    'T2972',
                    'T3534',
                    'T2980',
                    'T3536',
                    'T3540',
                    'T3538',
                    'T2984',
                    'T3542',
                    'T3543',
                    'T3544',
                    'T3548',
                    'T3552',
                    'T3556',
                    'T3560',
                    'T3564',
                    'T2986',
                    'T3568',
                    'T2988',
                    'T2992',
                    'T3572',
                    'TX422',
                    'T3574',
                    'T3576',
                    'T3580',
                    'T3584',
                    'T2996',
                    'T3588',
                    'T3592',
                    'T3596',
                    'T3000',
                    'T3600',
                    'TX426',
                    'T3008',
                    'T3604',
                    'T3010',
                    'T3608',
                    'TX428',
                    'T3612',
                    'T3012',
                    'T3616',
                    'T3620',
                    'T3520',
                    'T3622',
                    'TX430',
                    'T3016',
                    'T3632',
                    'T3018',
                    'TX432',
                    'TX434',
                    'T3020',
                    'TX436',
                    'T3024',
                    'TX438',
                    'T3028',
                    'T3634',
                    'T3032',
                    'T3636',
                    'T3034',
                    'T3640',
                    'T3036',
                    'T3644',
                    'T3648',
                    'T3040',
                    'T3652',
                    'T3656',
                    'T3138',
                    'T3658',
                    'T3044',
                    'T3660',
                    'T3662',
                    'T3048',
                    'T3718',
                    'T3052',
                    'T3663',
                    'T3056',
                    'T3060',
                    'T3664',
                    'T3714',
                    'T3668',
                    'T3062',
                    'T3672',
                    'T3676',
                    'T3063',
                    'TX440',
                    'T3072',
                    'T3680',
                    'T3682',
                    'T3684',
                    'T3080',
                    'T3074',
                    'TX442',
                    'T3084',
                    'T3688',
                    'T3690',
                    'T3088',
                    'T3696',
                    'T3700',
                    'T3092',
                    'T3096',
                    'T3704',
                    'T3708',
                    'T3100',
                    'T3712',
                    'T3716',
                    'T3720',
                    'T3724',
                    'T3102',
                    'T3728',
                    'T3524',
                    'T3732',
                    'TX444',
                    'T3736',
                    'TX446',
                    'TX448',
                    'T3104',
                    'T3738',
                    'T3740',
                    'T3744',
                    'T3748',
                    'T3750',
                    'T3132',
                    'T3108',
                    'T3112',
                    'T3116',
                    'T3120',
                    'T3480',
                    'T3124',
                    'T3752',
                    'T3754',
                    'T3126',
                    'T3756',
                    'T3128',
                    'T3760',
                    'T3764',
                    'TX450',
                    'T3766',
                    'T3136',
                    'T3768',
                    'T3772',
                    'T3140',
                    'T3142',
                    'T3776',
                    'T3144',
                    'T3780',
                    'T3148',
                    'T3152',
                    'T3784',
                    'T3156',
                    'T3160',
                    'T3788',
                    'T3164',
                    'T3168',
                    'T3170',
                    'T3792',
                    'T3174',
                    'TX452',
                    'T3830',
                    'T3796',
                    'T3800',
                    'T3802',
                    'T3172',
                    'T3804',
                    'T3806',
                    'T3176',
                    'TX454',
                    'T3180',
                    'T3808',
                    'T3184',
                    'T3812',
                    'T3814',
                    'T3188',
                    'T3192',
                    'T3196',
                    'T3816',
                    'T3820',
                    'TX456',
                    'T3834',
                    'T3200',
                    'TX460',
                    'T3208',
                    'T3828',
                    'T3210',
                    'T3212',
                    'T3216',
                    'T3832',
                    'T3220',
                    'T3224',
                    'T3228',
                    'T3232',
                    'T3236',
                    'T3836'
                        ]
                }
            }
            ],
            'response': {
                'format': 'px'
            }
        

        }";
            textBox3.Text = json3;
        }
    }
}

