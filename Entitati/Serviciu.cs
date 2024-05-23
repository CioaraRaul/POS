using System.Data;
using System.Xml;
using System.Xml.Serialization;
namespace Entitati
{
    [Serializable]
    public class Serviciu : ProdusAbstract
    {
        public int ServiceNumber { get; set; }
        public Serviciu(int id, string? nume, string? codIntern, string? categorie, int pret) : base(nume, codIntern, id, categorie, pret)
        {

        }
        public Serviciu() : base() { }
        /* public override string Descriere()
         {
             return base.Descriere();
         }

         public override string Descriere2()
         {
             return "Serviciul: " + this.Name + "[" + this.CodIntern
             + "] ";
         }*/

        public void setTheNumberOfServices()
        {
            Console.WriteLine("Seteaza Numarul de produse din pachet: ");
            ServiceNumber = int.Parse(Console.ReadLine() ?? string.Empty);

            // serializare date in XML
            DataSet ds = new DataSet();
            ds.Tables[0].Columns.Add("Setting", typeof(int));

            // add a new row to the first table of the DataSet
            DataRow newRow = ds.Tables[0].NewRow();
            newRow["Setting"] = ServiceNumber;
            ds.Tables[0].Rows.Add(newRow);

            ds.WriteXml("setting.xml");
        }
        public override bool CompareObject(ProdusAbstract itemToAdd)
        {
            return base.CompareObject(itemToAdd);
        }


        public static bool operator ==(Serviciu serv1, Serviciu serv2)
            => ((serv1.Name == serv2.Name) && (serv1.CodIntern == serv2.CodIntern));
        public static bool operator !=(Serviciu serv1, Serviciu serv2)
            => ((serv1.Name != serv2.Name) && (serv1.CodIntern != serv2.CodIntern));

        public override bool Equals(object? obj)
        {
            if ((obj is Serviciu) && (this == (Serviciu)obj))
                return true;

            return false;
        }

        public override string ToString()
        {
            return $"Serviciul: {Name}[{CodIntern}] {Categorie} {Pret}";
        }

        public override bool canAddToPackage(List<ProdusAbstract> prodServ)
        {
            foreach (ProdusAbstract e in prodServ)
            {
                if (e.CompareObject(this))
                    return true;
            }
            return false;

        }

       /* public void save2XML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Serviciu));
            StreamWriter sw = new StreamWriter(fileName + ".xml");
            xs.Serialize(sw, this);
            sw.Close();
        }

        public Serviciu? loadFromXML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Serviciu));
            FileStream fs = new FileStream(fileName + ".xml", FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            //deserializare cu crearea de obiect => constructor fara param
            Serviciu? serviciu = (Serviciu?)xs.Deserialize(reader);
            fs.Close();
            return serviciu;
        }*/

    }

}
