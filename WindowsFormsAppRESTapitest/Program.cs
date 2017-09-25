using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppRESTapitest
{
    public class GetVariable
    {
        public string code { get; set; }
        public string text { get; set; }
        public List<string> values { get; set; }
        public List<string> valueTexts { get; set; }
        public bool? time { get; set; }
    }

    public class Infoobject
    {
        string values { get; set; }

        string ValueTexts { get; set; }

    }
    public class GetResObject
    {
        public string title { get; set; }
        public List<GetVariable> variables { get; set; }
    }
    public class ListScbData
    {
        public List<Scbdata> data { get; set; }
    }
    public class Index
    {
        public int __invalid_name__6 { get; set; }
    }

    public class Label
    {
        public string __invalid_name__6 { get; set; }
    }

    public class Category
    {
        public Index index { get; set; }
        public Label label { get; set; }
    }

    public class Sektor
    {
        public string label { get; set; }
        public Category category { get; set; }
    }

    public class Index2
    {
        public int AM0401PX { get; set; }
    }

    public class Label2
    {
        public string AM0401PX { get; set; }
    }

    public class AM0401PX
    {
        public string @base { get; set; }
        public int decimals { get; set; }
    }

    public class Unit
    {
        public AM0401PX AM0401PX { get; set; }
    }

    public class Category2
    {
        public Index2 index { get; set; }
        public Label2 label { get; set; }
        public Unit unit { get; set; }
    }

    public class ContentsCode
    {
        public string label { get; set; }
        public Category2 category { get; set; }
    }

    public class Index3
    {
        public int __invalid_name__2017M08 { get; set; }
    }

    public class Label3
    {
        public string __invalid_name__2017M08 { get; set; }
    }

    public class Category3
    {
        public Index3 index { get; set; }
        public Label3 label { get; set; }
    }

    public class Tid
    {
        public string label { get; set; }
        public Category3 category { get; set; }
    }

    public class Role
    {
        public List<string> metric { get; set; }
        public List<string> time { get; set; }
    }

    public class Dimension
    {
        public Sektor Sektor { get; set; }
        public ContentsCode ContentsCode { get; set; }
        public Tid Tid { get; set; }
        public List<string> id { get; set; }
        public List<int> size { get; set; }
        public Role role { get; set; }
    }

    public class Dataset
    {
        public Dimension dimension { get; set; }
        public string label { get; set; }
        public string source { get; set; }
        public DateTime updated { get; set; }
        public List<double> value { get; set; }
    }

    public class ResultatUtObject
    {
        public Dataset dataset { get; set; }
    }


    public class Column
    {
        public string code { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Datum
    {
        public List<string> key { get; set; }
        public List<string> values { get; set; }
    }

    public class Res2Object
    {
        public List<Column> columns { get; set; }
        public List<object> comments { get; set; }
        public List<Datum> data { get; set; }
    }





    public class Scbdata
    {

        public string id { get; set; }
        public string type { get; set; }

        public string text { get; set; }


    }


    public class Variable
    {
        public string code { get; set; }
        public string text { get; set; }
        public List<string> values { get; set; }
        public List<string> valueTexts { get; set; }
        public bool elimination { get; set; }
        public bool? time { get; set; }
    }

    public class ResultatObject
    {
        public string title { get; set; }
        public List<Variable> variables { get; set; }
    }


    

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
