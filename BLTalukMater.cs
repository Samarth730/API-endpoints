using System.Data;
using TalukMasterInformation.Model;
using TalukMasterInformation.DataBaseLAyer;
using System.Security.Cryptography;


namespace TalukMasterInformation.BissnussLayer
{
    public class BLTalukMater
    {
        String SqlQuery = String.Empty;
        DBTalukLayer dBTalukLayer = new DBTalukLayer();

        public List<BOTalukMaster> GetTalukMasterDetails()
        {
            
            List<BOTalukMaster> bLTalukMater = new List<BOTalukMaster>();
            SqlQuery = "Select * from TalukMaster";

            DBTalukLayer dBTalukLayer = new DBTalukLayer();
            DataTable dataget = dBTalukLayer.GetDataTable(SqlQuery);

            for (int i = 0; i < dataget.Rows.Count; i++) 
            {
                BOTalukMaster bLTalukMater1 = new BOTalukMaster();
                bLTalukMater1.Id = (int)dataget.Rows[i]["Id"];
                bLTalukMater1.TalukName = (string)dataget.Rows[i]["TalukName"];
                bLTalukMater1.DistrictId = (string)dataget.Rows[i]["DistrictId"];
                bLTalukMater.Add(bLTalukMater1);

            }
            return bLTalukMater;



        }


        public List<BOTalukMaster> GetSingalTaluk(string DistrictId)
        {
            String SqlQuery = String.Empty;
            List<BOTalukMaster> bLTalukMater = new List<BOTalukMaster>();
            SqlQuery = "Select * from TalukMaster where DistrictId ='"+ DistrictId + "'";

            DBTalukLayer dBTalukLayer = new DBTalukLayer();
            DataTable dataget = dBTalukLayer.GetDataTable(SqlQuery);

            for (int i = 0; i < dataget.Rows.Count; i++)
            {
                BOTalukMaster bLTalukMater1 = new BOTalukMaster();
                bLTalukMater1.Id = (int)dataget.Rows[i]["Id"];
                bLTalukMater1.TalukName = (string)dataget.Rows[i]["TalukName"];
                bLTalukMater1.DistrictId = (string)dataget.Rows[i]["DistrictId"];
                bLTalukMater.Add(bLTalukMater1);

            }
            return bLTalukMater;



        }


         public bool InsertDeatails(int Id,string TalukName,string DistrictId)
        {
            SqlQuery = "insert into TalukMaster values(" + Id + ",'" + TalukName + "','" + DistrictId + "')";
            int result = dBTalukLayer.ExecuteOnlyQuery(SqlQuery);
            return result > 0 ? true : false;
        }


        public bool UpdateDeatails(int Id,string TalukName,string DistrictId)
        {
            SqlQuery = "Update TalukMaster set TalukName = '" + TalukName + "',DistrictId=" + DistrictId + " where Id=" + Id + "";
            int count = dBTalukLayer.ExecuteOnlyQuery(SqlQuery);
            return count > 0 ? true : false;
        }




        public bool Deletee(int Id)
        {
            SqlQuery = "delete from  TalukMaster  where Id=" + Id + "";
            int count = dBTalukLayer.ExecuteOnlyQuery(SqlQuery);
            return count > 0 ? true : false;
        }

    }
}
