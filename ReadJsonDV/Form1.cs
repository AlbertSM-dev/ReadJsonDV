using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.JScript;
using ReadJsonDV.Models;

namespace ReadJsonDV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void button1_Click(object sender, EventArgs e)
        {

            //var line = (@"C:\Users\lokdo\OneDrive\Escritorio\json.json");
            //var lines = System.IO.File.ReadAllLines(line);
            int count1 = 0;
            int count2 = 0;
            //var json = File.ReadAllText("json1.json");
            //var root = JsonConvert.DeserializeObject<RootObject>(line);
            //var ObjOrderList = JsonConvert.DeserializeObject<RootObject>(lines);

            //var jsonList = System.IO.File.ReadAllLines(@"C:\Users\lokdo\OneDrive\Escritorio\json.json");
            //// convert string[] to string
            //string jsonStr = string.Join("", jsonList);

            //var res = JsonConvert.DeserializeObject<List<WeatherForecast>>(jsonStr);

            List<WeatherForecast> objects = File.ReadAllLines(@"C:\Users\lokdo\OneDrive\Escritorio\json.json")
    .Select(line => JsonConvert.DeserializeObject<WeatherForecast>(line))
    .ToList();

            List<string> hot = new List<string>();
            List<string> cold = new List<string>();
            foreach (var p in objects)
            {

                if (p.Summary == "Hot")
                {
                    count1++;
                    textBox1.Text = (count1).ToString();
                    string Summary =  " \"Summary\": ";
                    string x = '{' + "\"Summary\":" + '"' + p.Summary + '"' + "," + '"' +p.Date+","+p.TemperatureCelsius+'}';

                    hot.Add(x);
                }
                else
                {
                    count2++;
                    textBox2.Text = (count2).ToString();
                    cold.Add(p.Summary);
                    
                }
                //rootobjects.Add(JsonConvert.DeserializeObject<WeatherForecast>(row));
            }
            //List<string> jsonhot = JsonConvert.SerializeObject(hot);
            System.IO.File.WriteAllLines(@"C:\Users\lokdo\source\repos\ReadJsonDV\ReadJsonDV\Files\hot.json", hot);
            System.IO.File.WriteAllLines(@"C:\Users\lokdo\source\repos\ReadJsonDV\ReadJsonDV\Files\cold.txt", cold);

        }
    }
 
}
