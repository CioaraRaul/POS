using System.Data;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace Entitati
{
    [Serializable]
    public class Pachet:ProdusAbstract, IComparer<ProdusAbstract>
    {
        public List<ProdusAbstract> Elemente_pachet { get; set; } = new List<ProdusAbstract>();

        public Pachet() 
        { 

        }
        //Setari pentru nr de produse si servicii din pachet
        public void setTheNumberOfProducts()
        {
            int ProdNumber;
            int ServNumber;
            Console.WriteLine("Seteaza Numarul de produse din pachet: ");
            ProdNumber = int.Parse(Console.ReadLine() ?? string.Empty);
            // serializare date in XML
            DataSet ds = new DataSet();

            // create a new table and add it to the dataset
            DataTable table = new DataTable("Settings");
            table.Columns.Add("Value", typeof(int));
            ds.Tables.Add(table);

            // add the value to the table
            ds.Tables["Settings"].Rows.Add(ProdNumber);

            Console.WriteLine("Seteaza Numarul de servicii din pachet: ");
            ServNumber = int.Parse(Console.ReadLine() ?? string.Empty);
            ds.Tables["settings"].Rows.Add(ServNumber);

            // save the dataset to an XML file
            ds.WriteXml("C:\\All folder\\C# POO\\POS\\ProiectLaboratorPOO1\\XML\\setting.xml");
        }

        public string ElemPachetToString()
        {
            if (Elemente_pachet == null)
            {
                return string.Empty;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach(ProdusAbstract el in this.Elemente_pachet)
                    sb.Append('\t' + el.ToString() + '\n');
                return sb.ToString();
            }
        }

        //Redefinire to string pentru afisare
        public override string ToString()
        {
            return "Pachet: " + base.ToString() + '\n' + ElemPachetToString();
        }


        //Conditie adaugare pachet
        public override bool canAddToPackage(List<ProdusAbstract> prodServ)
        {
            return false;
        }

        //Redefinire CompareTo
        public int CompareTo(ProdusAbstract x)
        {
            return Pret.CompareTo(x.Pret);
        }

        public int Compare(Pachet first, Pachet second)
        {
            if (first != null && second != null)
            {
                
                return first.Pret.CompareTo(second.Pret);
            }

            if (first == null && second == null)
            {
                
                return 0;
            }

            if (first != null)
            {
                
                return -1;
            }

           
            return 1;
        }

        //Serializare & Deserializare
        public void saveListToXML(List<Pachet> listaPachete, string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Pachet>));
            StreamWriter sw = new StreamWriter(fileName + ".xml");
            xs.Serialize(sw, listaPachete);
            sw.Close();
        }


        public List<Pachet> loadFromXML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Pachet>));
            FileStream fs = new FileStream(fileName + ".xml", FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            List<Pachet>? listaPachete = (List<Pachet>?)xs.Deserialize(reader);
            fs.Close();
            return listaPachete;
        }


    }
}
